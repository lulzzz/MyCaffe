﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCaffe.param;
using MyCaffe.basecode;
using System.Threading;
using MyCaffe.common;
using System.Drawing;
using System.Diagnostics;
using MyCaffe.imagedb;
using MyCaffe.basecode.descriptors;
using MyCaffe.gym;
using MyCaffe.trainers;

namespace MyCaffe.test
{
    [TestClass]
    public class TestMyCaffeCustomTrainer
    {
        [TestMethod]
        public void TrainA2CCartPoleWithUi()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    t.TrainCartPole(true, TRAINING_MODE.SINGLE_INSTANCE);
                }
            }
            finally
            {
                test.Dispose();
            }
        }

        [TestMethod]
        public void TrainA2CCartPoleWithOutUi()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    t.TrainCartPole(false, TRAINING_MODE.SINGLE_INSTANCE);
                }
            }
            finally
            {
                test.Dispose();
            }
        }

        [TestMethod]
        public void TrainA3CCartPoleWithUi()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    t.TrainCartPole(true, TRAINING_MODE.MULTI_INSTANCE);
                }
            }
            finally
            {
                test.Dispose();
            }
        }

        [TestMethod]
        public void TrainA3CCartPoleWithOutUi()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    t.TrainCartPole(false, TRAINING_MODE.MULTI_INSTANCE);
                }
            }
            finally
            {
                test.Dispose();
            }
        }
    }


    interface IMyCaffeCustomTrainerTest : ITest
    {
        void TrainCartPole(bool bShowUi, TRAINING_MODE mode);
    }

    class MyCaffeCustomTrainerTest : TestBase
    {
        public MyCaffeCustomTrainerTest(EngineParameter.Engine engine = EngineParameter.Engine.DEFAULT)
            : base("MyCaffe Custom Trainer Test", TestBase.DEFAULT_DEVICE_ID, engine)
        {
        }

        protected override ITest create(common.DataType dt, string strName, int nDeviceID, EngineParameter.Engine engine)
        {
            if (dt == common.DataType.DOUBLE)
                return new MyCaffeCustomTrainerTest<double>(strName, nDeviceID, engine);
            else
                return new MyCaffeCustomTrainerTest<float>(strName, nDeviceID, engine);
        }
    }

    class MyCaffeCustomTrainerTest<T> : TestEx<T>, IMyCaffeCustomTrainerTest
    {
        SettingsCaffe m_settings = new SettingsCaffe();
        CancelEvent m_evtCancel = new CancelEvent();

        public MyCaffeCustomTrainerTest(string strName, int nDeviceID, EngineParameter.Engine engine)
            : base(strName, null, nDeviceID)
        {
            m_settings.ImageDbLoadMethod = IMAGEDB_LOAD_METHOD.LOAD_ALL;
            m_settings.GpuIds = nDeviceID.ToString();
        }

        protected override void dispose()
        {
            base.dispose();
        }

        public void TrainCartPole(bool bShowUi, TRAINING_MODE mode)
        {
            int nIterations = 100000;
            m_log.WriteHeader("Test Training Cart-Pole for " + nIterations.ToString("N0") + " iterations.");
            MyCaffeGymClient gym = new MyCaffeGymClient();
            MyCaffeControl<float> mycaffe = new MyCaffeControl<float>(m_settings, m_log, m_evtCancel);
            MyCaffeCartPoleTrainer trainer = new MyCaffeCartPoleTrainer(gym);
            ProjectEx project = getReinforcementProject(gym, nIterations);
            DatasetDescriptor ds = trainer.DatasetOverride;

            m_log.CHECK(ds != null, "The MyCaffeCartPoleTrainer should return its dataset override returned by the Gym that it uses.");

            // load the project to train (note the project must use the MemoryDataLayer for input).
            mycaffe.Load(Phase.TRAIN, project, IMGDB_LABEL_SELECTION_METHOD.NONE, IMGDB_IMAGE_SELECTION_METHOD.NONE, false, null, (ds == null) ? true : false);

            // Open the Cart-Pole gym.
            gym.Open("Cart Pole", true, bShowUi);
            // Train the network using the custom trainer
            //  - Iterations (max global episodes) = 100000 (this is the count for the main episode processing loop)
            //  - enable log during training = false (only show custom trainer output)
            //  - max episode steps = 200 (this is the count for the inner episode building loop)
            //     NOTE: the mini-batch size specifed in the project memory data layer as 'batch_size' must be
            //           less than or equal to the episode steps.
            //  - initial random exploration 30% of the time to select actions at random.
            //  - number of episodes (100) before stepping down the random exploration rate.
            //  - the step-down factor (0.75) multiplied by the random exploration rate on each step down.
            //  - gamma for discount factor
            //  - beta for percentage of entropy to use.
            //  - GPUID - only the first GPUID is used when in A2C mode.
            trainer.Initialize("EnableLogOnTraining=False;MaxEpisodeSteps=200;ExplorationPercent=0.0;GlobalExplorationStep=100;ExplorationStepDownFactor=0.75;Gamma=0.9;Beta=0.01;GPUID=0", mode);
            trainer.Train(mycaffe, m_log, m_evtCancel, nIterations);
            trainer.CleanUp();
            // Close the gym.
            gym.Close();

            // Release the mycaffe resources.
            mycaffe.Dispose();
        }

        private ProjectEx getReinforcementProject(MyCaffeGymClient gym, int nIterations)
        {
            ProjectEx p = new ProjectEx("test");

            string strModelFile = getTestPath("\\MyCaffe\\test_data\\models\\reinforcement\\cartpole\\train_val.prototxt");
            string strSolverFile = getTestPath("\\MyCaffe\\test_data\\models\\reinforcement\\cartpole\\solver.prototxt");

            RawProto protoM = RawProtoFile.LoadFromFile(strModelFile);
            p.ModelDescription = protoM.ToString();

            RawProto protoS = RawProtoFile.LoadFromFile(strSolverFile);
            RawProto iter = protoS.FindChild("max_iter");
            iter.Value = nIterations.ToString();

            p.SolverDescription = protoS.ToString();

            p.SetDataset(gym.GetDataset("Cart Pole"));

            return p;
        }
    }

    class MyCaffeCartPoleTrainer : MyCaffeCustomTrainer
    {
        MyCaffeGymClient m_gym;
        Stopwatch m_sw = new Stopwatch();

        public MyCaffeCartPoleTrainer(MyCaffeGymClient gym) 
            : base()
        {
            m_gym = gym;
        }

        protected override string name
        {
            get { return "Cart Pole Trainer"; }
        }

        protected override DatasetDescriptor dataset_override
        {
            get { return m_gym.GetDataset("Cart Pole"); }
        }

        protected override void initialize(InitializeArgs e)
        {
            m_sw.Start();
        }

        protected override void dispose()
        {
            base.dispose();
        }

        protected override void getData(GetDataArgs e)
        {
            if (e.Reset)
                m_gym.Reset();

            if (e.Action >= 0)
            {
                m_gym.Run(e.Action);
                Thread.Sleep(10);
            }

            Observation obs = m_gym.GetObservation();

            e.State = new StateBase(m_gym.GetActionSpace().Count());
            e.State.Reward = obs.Reward;
            e.State.Data = new SimpleDatum(true, obs.State.Count(), 1, 1, -1, DateTime.Now, null, obs.State.ToList(), 0, false, 0);
            e.State.Done = obs.Done;
            e.State.IsValid = true;

            if (m_sw.Elapsed.TotalMilliseconds > 1000)
            {
                double dfPct = (double)m_nGlobalEpisodeCount / (double)m_nMaxGlobalEpisodes;
                Trace.WriteLine("(" + dfPct.ToString("P") + ") Global Episode #" + m_nGlobalEpisodeCount.ToString() + "  Global Reward = " + m_dfGlobalRewards.ToString());
                m_sw.Restart();
            }
        }
    }
}