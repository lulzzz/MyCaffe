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
using MyCaffe.db.image;
using MyCaffe.basecode.descriptors;
using MyCaffe.gym;
using MyCaffe.trainers;
using System.ServiceModel;
using MyCaffe.db.stream;
using System.IO;

namespace MyCaffe.test
{
    [TestClass]
    public class TestMyCaffeCustomTrainer
    {
        [TestMethod]
        public void Train_PGSIMPLE_CartPoleWithOutUi()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    t.TrainCartPolePG(false, false, "PG.SIMPLE", 100);
                }
            }
            finally
            {
                test.Dispose();
            }
        }

        [TestMethod]
        public void Train_PGST_CartPoleWithOutUi()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    t.TrainCartPolePG(false, false, "PG.ST", 100);
                }
            }
            finally
            {
                test.Dispose();
            }
        }

        [TestMethod]
        public void Train_PGST_CartPoleWithOutUi_Dual()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    t.TrainCartPolePG(true, false, "PG.ST", 100);
                }
            }
            finally
            {
                test.Dispose();
            }
        }

        [TestMethod]
        public void Train_PGMT_CartPoleWithOutUi()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    t.TrainCartPolePG(false, false, "PG.MT", 100);
                }
            }
            finally
            {
                test.Dispose();
            }
        }

        [TestMethod]
        public void Train_PGMT_AtariWithOutUi()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    t.TrainAtariPG(false, false, "PG.MT", 10);
                }
            }
            finally
            {
                test.Dispose();
            }
        }

        [TestMethod]
        public void Train_PGST_AtariWithOutUi()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    t.TrainAtariPG(false, false, "PG.ST", 10);
                }
            }
            finally
            {
                test.Dispose();
            }
        }
        [TestMethod]
        public void Train_PGST_AtariWithOutUi_Dual()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    t.TrainAtariPG(true, false, "PG.ST", 10);
                }
            }
            finally
            {
                test.Dispose();
            }
        }

        [TestMethod]
        public void Train_PGSIMPLE_AtariWithOutUi()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    t.TrainAtariPG(false, false, "PG.SIMPLE", 10);
                }
            }
            finally
            {
                test.Dispose();
            }
        }

        [TestMethod]
        public void Train_RNNSIMPLE_CharRNN_LSTM()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    // NOTE: 1000 iterations is quite short and may not produce results,
                    // for real training 100,000+ is a more common iteration to use.
                    t.TrainCharRNN(false, false, "RNN.SIMPLE", LayerParameter.LayerType.LSTM, 1000);
                }
            }
            finally
            {
                test.Dispose();
            }
        }

        [TestMethod]
        public void Train_RNNSIMPLE_CharRNN_LSTM_cuDnn()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest(EngineParameter.Engine.CUDNN);

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    // NOTE: 1000 iterations is quite short and may not produce results,
                    // for real training 100,000+ is a more common iteration to use.
                    t.TrainCharRNN(false, false, "RNN.SIMPLE", LayerParameter.LayerType.LSTM, 1000);
                }
            }
            finally
            {
                test.Dispose();
            }
        }

        [TestMethod]
        public void Train_RNNSIMPLE_CharRNN_LSTM_cuDnn_Dual()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest(EngineParameter.Engine.CUDNN);

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    // NOTE: 1000 iterations is quite short and may not produce results,
                    // for real training 100,000+ is a more common iteration to use.
                    t.TrainCharRNN(true, false, "RNN.SIMPLE", LayerParameter.LayerType.LSTM, 1000);
                }
            }
            finally
            {
                test.Dispose();
            }
        }

        [TestMethod]
        public void Train_RNNSIMPLE_CharRNN_LSTMSIMPLE()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    // NOTE: 1000 iterations is quite short and may not produce results,
                    // for real training 100,000+ is a more common iteration to use.
                    t.TrainCharRNN(false, false, "RNN.SIMPLE", LayerParameter.LayerType.LSTM_SIMPLE, 1000);
                }
            }
            finally
            {
                test.Dispose();
            }
        }

        [TestMethod]
        public void Train_RNNSIMPLE_WavRNN_LSTM()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    // NOTE: 1000 iterations is quite short and may not produce results,
                    // for real training 100,000+ is a more common iteration to use.
                    t.TrainWavRNN(false, false, "RNN.SIMPLE", LayerParameter.LayerType.LSTM, 1000);
                }
            }
            finally
            {
                test.Dispose();
            }
        }

        [TestMethod]
        public void Train_RNNSIMPLE_WavRNN_LSTMSIMPLE()
        {
            MyCaffeCustomTrainerTest test = new MyCaffeCustomTrainerTest();

            try
            {
                foreach (IMyCaffeCustomTrainerTest t in test.Tests)
                {
                    // NOTE: 1000 iterations is quite short and may not produce results,
                    // for real training 100,000+ is a more common iteration to use.
                    t.TrainWavRNN(false, false, "RNN.SIMPLE", LayerParameter.LayerType.LSTM_SIMPLE, 1000);
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
        void TrainCartPolePG(bool bDual, bool bShowUi, string strTrainerType, int nIterations = 1000, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false);
        void TrainAtariPG(bool bDual, bool bShowUi, string strTrainerType, int nIterations = 1000, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false);
        void TrainCharRNN(bool bDual, bool bShowUi, string strTrainerType, LayerParameter.LayerType lstm, int nIterations = 1000, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false);
        void TrainWavRNN(bool bDual, bool bShowUi, string strTrainerType, LayerParameter.LayerType lstm, int nIterations = 1000, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false);
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

    public class MyCaffeCustomTrainerTest<T> : TestEx<T>, IMyCaffeCustomTrainerTest, IXMyCaffeCustomTrainerCallbackRNN
    {
        SettingsCaffe m_settings = new SettingsCaffe();
        CancelEvent m_evtCancel = new CancelEvent();
        string m_strModelPath;
        TestingProgressSet m_progress = new TestingProgressSet();
        int m_nMaxIteration = 0;


        public MyCaffeCustomTrainerTest(string strName, int nDeviceID, EngineParameter.Engine engine)
            : base(strName, null, nDeviceID)
        {
            m_engine = engine;
            m_settings.ImageDbLoadMethod = IMAGEDB_LOAD_METHOD.LOAD_ALL;
            m_settings.GpuIds = nDeviceID.ToString();
        }

        protected override void dispose()
        {
            m_progress.Dispose();
            base.dispose();
        }

        public CancelEvent CancelEvent
        {
            get { return m_evtCancel; }
        }


        public void TrainCartPolePG(bool bDual, bool bShowUi, string strTrainerType, int nIterations = 1000, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false)
        {
            if (bDual)
                TrainCartPolePGDual(bShowUi, strTrainerType, nIterations, bUseAcceleratedTraining, bAllowDiscountReset);
            else
                TrainCartPolePG(bShowUi, strTrainerType, nIterations, bUseAcceleratedTraining, bAllowDiscountReset);
        }

        public void TrainCartPolePG(bool bShowUi, string strTrainerType, int nIterations = 1000, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false)
        {
            m_evtCancel.Reset();

            GymCollection col = new GymCollection();
            col.Load();
            IXMyCaffeGym igym = col.Find("Cart-Pole");
            string strAccelTrain = (bUseAcceleratedTraining) ? "ON" : "OFF";
            string strAllowReset = (bAllowDiscountReset) ? "YES" : "NO";

            if (strTrainerType != "PG.MT")
                strAccelTrain = "NOT SUPPORTED";

            m_log.WriteHeader("Test Training Cart-Pole for " + nIterations.ToString("N0") + " iterations.");
            m_log.WriteLine("Using trainer = " + strTrainerType + ", Accelerated Training = " + strAccelTrain + ", AllowDiscountReset = " + strAllowReset);
            MyCaffeControl<T> mycaffe = new MyCaffeControl<T>(m_settings, m_log, m_evtCancel);
            MyCaffeCartPoleTrainer trainer = new MyCaffeCartPoleTrainer();
            ProjectEx project = getReinforcementProject(igym, nIterations, DATA_TYPE.VALUES, strTrainerType.Contains("SIMPLE"));
            DatasetDescriptor ds = trainer.GetDatasetOverride(0);

            m_log.CHECK(ds != null, "The MyCaffeCartPoleTrainer should return its dataset override returned by the Gym that it uses.");

            // load the project to train (note the project must use the MemoryDataLayer for input).
            mycaffe.Load(Phase.TRAIN, project, IMGDB_LABEL_SELECTION_METHOD.NONE, IMGDB_IMAGE_SELECTION_METHOD.NONE, false, null, false);

            // Train the network using the custom trainer
            //  - Iterations (maximum frames cumulative across all threads) = 1000 (normally this would be much higher such as 500,000)
            //  - Learning rate = 0.001 (defined in solver.prototxt)
            //  - Mini Batch Size = 10 (defined in train_val.prototxt for MemoryDataLayer)
            //
            //  - TraingerType = 'strTrainerType' ('PG.MT' = use multi-threaded Policy Gradient trainer, 'PG.ST' = single-threaded trainer, 'PG.SIMPLE' = basic trainer with Sigmoid output support only)
            //  - RewardType = MAX (display the maximum rewards received, a setting of VAL displays the actual reward received)
            //  - Gamma = 0.99 (discounting factor)
            //  - Init1 = default force of 10.
            //  - Init2 = do not use additive force.                    
            //  - Threads = 1 (only use 1 thread if multi-threading is supported)
            trainer.Initialize("TrainerType=" + strTrainerType + ";RewardType=VAL;UseAcceleratedTraining=" + bUseAcceleratedTraining.ToString() + ";AllowDiscountReset=" + bAllowDiscountReset.ToString() + ";Gamma=0.99;Init1=10;Init2=0;Threads=1", this);

            if (bShowUi)
                trainer.OpenUi();

            m_nMaxIteration = nIterations;
            trainer.Train(mycaffe, nIterations);
            trainer.CleanUp();

            // Release the mycaffe resources.
            mycaffe.Dispose();
        }

        public void TrainCartPolePGDual(bool bShowUi, string strTrainerType, int nIterations = 1000, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false)
        {
            m_evtCancel.Reset();

            GymCollection col = new GymCollection();
            col.Load();
            IXMyCaffeGym igym = col.Find("Cart-Pole");
            string strAccelTrain = (bUseAcceleratedTraining) ? "ON" : "OFF";
            string strAllowReset = (bAllowDiscountReset) ? "YES" : "NO";

            if (strTrainerType != "PG.MT")
                strAccelTrain = "NOT SUPPORTED";

            m_log.WriteHeader("Test Training Cart-Pole for " + nIterations.ToString("N0") + " iterations.");
            m_log.WriteLine("Using trainer = " + strTrainerType + ", Accelerated Training = " + strAccelTrain + ", AllowDiscountReset = " + strAllowReset);
            MyCaffeControl<T> mycaffe = new MyCaffeControl<T>(m_settings, m_log, m_evtCancel);
            MyCaffeCartPoleTrainerDual trainerX = new MyCaffeCartPoleTrainerDual();

            IXMyCaffeCustomTrainerRL itrainer = trainerX as IXMyCaffeCustomTrainerRL;
            if (itrainer == null)
                throw new Exception("The trainer must implement the IXMyCaffeCustomTrainerRL interface!");

            ProjectEx project = getReinforcementProject(igym, nIterations, DATA_TYPE.VALUES, strTrainerType.Contains("SIMPLE"));
            DatasetDescriptor ds = itrainer.GetDatasetOverride(0);

            m_log.CHECK(ds != null, "The MyCaffeCartPoleTrainer should return its dataset override returned by the Gym that it uses.");

            // Train the network using the custom trainer
            //  - Iterations (maximum frames cumulative across all threads) = 1000 (normally this would be much higher such as 500,000)
            //  - Learning rate = 0.001 (defined in solver.prototxt)
            //  - Mini Batch Size = 10 (defined in train_val.prototxt for MemoryDataLayer)
            //
            //  - TraingerType = 'strTrainerType' ('PG.MT' = use multi-threaded Policy Gradient trainer, 'PG.ST' = single-threaded trainer, 'PG.SIMPLE' = basic trainer with Sigmoid output support only)
            //  - RewardType = MAX (display the maximum rewards received, a setting of VAL displays the actual reward received)
            //  - Gamma = 0.99 (discounting factor)
            //  - Init1 = default force of 10.
            //  - Init2 = do not use additive force.                    
            //  - Threads = 1 (only use 1 thread if multi-threading is supported)
            itrainer.Initialize("TrainerType=" + strTrainerType + ";RewardType=VAL;UseAcceleratedTraining=" + bUseAcceleratedTraining.ToString() + ";AllowDiscountReset=" + bAllowDiscountReset.ToString() + ";Gamma=0.99;Init1=10;Init2=0;Threads=1", this);

            // load the project to train (note the project must use the MemoryDataLayer for input).
            mycaffe.Load(Phase.TRAIN, project, IMGDB_LABEL_SELECTION_METHOD.NONE, IMGDB_IMAGE_SELECTION_METHOD.NONE, false, null, false, true, itrainer.Stage.ToString());

            if (bShowUi)
                itrainer.OpenUi();

            m_nMaxIteration = nIterations;
            itrainer.Train(mycaffe, nIterations, TRAIN_STEP.NONE);
            itrainer.CleanUp();

            // Release the mycaffe resources.
            mycaffe.Dispose();
        }


        public void TrainAtariPG(bool bDual, bool bShowUi, string strTrainerType, int nIterations = 1000, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false)
        {
            if (bDual)
                TrainAtariPGDual(bShowUi, strTrainerType, nIterations, bUseAcceleratedTraining, bAllowDiscountReset);
            else
                TrainAtariPG(bShowUi, strTrainerType, nIterations, bUseAcceleratedTraining, bAllowDiscountReset);
        }

        public void TrainAtariPG(bool bShowUi, string strTrainerType, int nIterations = 100, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false)
        {
            m_evtCancel.Reset();

            GymCollection col = new GymCollection();
            col.Load();
            IXMyCaffeGym igym = col.Find("ATARI");
            DATA_TYPE dt = DATA_TYPE.BLOB;
            string strAccelTrain = (bUseAcceleratedTraining) ? "ON" : "OFF";
            string strAllowReset = (bAllowDiscountReset) ? "YES" : "NO";

            if (strTrainerType != "PG.MT")
                strAccelTrain = "NOT SUPPORTED";

            m_log.WriteHeader("Test Training ATARI for " + nIterations.ToString("N0") + " iterations.");
            m_log.WriteLine("Using trainer = " + strTrainerType + ", Accelerated Training = " + strAccelTrain + ", AllowDiscountReset = " + strAllowReset);
            MyCaffeControl<T> mycaffe = new MyCaffeControl<T>(m_settings, m_log, m_evtCancel);
            MyCaffeAtariTrainer trainer = new MyCaffeAtariTrainer();
            ProjectEx project = getReinforcementProject(igym, nIterations, dt);
            DatasetDescriptor ds = trainer.GetDatasetOverride(0);
            string strRom = getRomPath("pong.bin");

            m_log.CHECK(ds != null, "The MyCaffeAtariTrainer should return its dataset override returned by the Gym that it uses.");

            // load the project to train (note the project must use the MemoryDataLayer for input).
            mycaffe.Load(Phase.TRAIN, project, IMGDB_LABEL_SELECTION_METHOD.NONE, IMGDB_IMAGE_SELECTION_METHOD.NONE, false, null, false);

            // Train the network using the custom trainer
            //  - Iterations (maximum frames cumulative across all threads) = 1000 (normally this would be much higher such as 500,000)
            //  - Learning rate = 0.001 (defined in solver.prototxt)
            //  - Mini Batch Size = 10 (defined in train_val.prototxt for MemoryDataLayer)
            //
            //  - TrainerType = 'PG.MT' ('PG.MT' = use multi-threaded Policy Gradient trainer)
            //  - RewardType = MAX (display the maximum rewards received, a setting of VAL displays the actual reward received)
            //  - Gamma = 0.99 (discounting factor)
            //  - Threads = 1 (only use 1 thread if multi-threading is supported)
            //  - UseAcceleratedTraining = False (disable accelerated training).
            //  - GameROM = 'path to game ROM'
            trainer.Initialize("TrainerType=" + strTrainerType + ";RewardType=VAL;UseAcceleratedTraining=" + bUseAcceleratedTraining.ToString() + ";AllowDiscountReset=" + bAllowDiscountReset.ToString() + ";Gamma=0.99;GameROM=" + strRom, this);

            if (bShowUi)
                trainer.OpenUi();

            m_nMaxIteration = nIterations;
            trainer.Train(mycaffe, nIterations);
            trainer.CleanUp();

            // Release the mycaffe resources.
            mycaffe.Dispose();
        }

        public void TrainAtariPGDual(bool bShowUi, string strTrainerType, int nIterations = 100, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false)
        {
            m_evtCancel.Reset();

            GymCollection col = new GymCollection();
            col.Load();
            IXMyCaffeGym igym = col.Find("ATARI");
            DATA_TYPE dt = DATA_TYPE.BLOB;
            string strAccelTrain = (bUseAcceleratedTraining) ? "ON" : "OFF";
            string strAllowReset = (bAllowDiscountReset) ? "YES" : "NO";

            if (strTrainerType != "PG.MT")
                strAccelTrain = "NOT SUPPORTED";

            m_log.WriteHeader("Test Training ATARI for " + nIterations.ToString("N0") + " iterations.");
            m_log.WriteLine("Using trainer = " + strTrainerType + ", Accelerated Training = " + strAccelTrain + ", AllowDiscountReset = " + strAllowReset);
            MyCaffeControl<T> mycaffe = new MyCaffeControl<T>(m_settings, m_log, m_evtCancel);
            MyCaffeAtariTrainerDual trainerX = new MyCaffeAtariTrainerDual();

            IXMyCaffeCustomTrainerRL itrainer = trainerX as IXMyCaffeCustomTrainerRL;
            if (itrainer == null)
                throw new Exception("The trainer must implement the IXMyCaffeCustomTrainerRL interface!");

            ProjectEx project = getReinforcementProject(igym, nIterations, dt);
            DatasetDescriptor ds = itrainer.GetDatasetOverride(0);
            string strRom = getRomPath("pong.bin");

            m_log.CHECK(ds != null, "The MyCaffeAtariTrainer should return its dataset override returned by the Gym that it uses.");

            // Train the network using the custom trainer
            //  - Iterations (maximum frames cumulative across all threads) = 1000 (normally this would be much higher such as 500,000)
            //  - Learning rate = 0.001 (defined in solver.prototxt)
            //  - Mini Batch Size = 10 (defined in train_val.prototxt for MemoryDataLayer)
            //
            //  - TrainerType = 'PG.MT' ('PG.MT' = use multi-threaded Policy Gradient trainer)
            //  - RewardType = MAX (display the maximum rewards received, a setting of VAL displays the actual reward received)
            //  - Gamma = 0.99 (discounting factor)
            //  - Threads = 1 (only use 1 thread if multi-threading is supported)
            //  - UseAcceleratedTraining = False (disable accelerated training).
            //  - GameROM = 'path to game ROM'
            itrainer.Initialize("TrainerType=" + strTrainerType + ";RewardType=VAL;UseAcceleratedTraining=" + bUseAcceleratedTraining.ToString() + ";AllowDiscountReset=" + bAllowDiscountReset.ToString() + ";Gamma=0.99;GameROM=" + strRom, this);

            // load the project to train (note the project must use the MemoryDataLayer for input).
            mycaffe.Load(Phase.TRAIN, project, IMGDB_LABEL_SELECTION_METHOD.NONE, IMGDB_IMAGE_SELECTION_METHOD.NONE, false, null, false, true, itrainer.Stage.ToString());

            if (bShowUi)
                itrainer.OpenUi();

            m_nMaxIteration = nIterations;
            itrainer.Train(mycaffe, nIterations, TRAIN_STEP.NONE);
            itrainer.CleanUp();

            // Release the mycaffe resources.
            mycaffe.Dispose();
        }


        public void TrainCharRNN(bool bDual, bool bShowUi, string strTrainerType, LayerParameter.LayerType lstm, int nIterations = 100, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false)
        {
            if (bDual)
                TrainCharRNNDual(bShowUi, strTrainerType, lstm, nIterations, bUseAcceleratedTraining, bAllowDiscountReset);
            else
                TrainCharRNN(bShowUi, strTrainerType, lstm, nIterations, bUseAcceleratedTraining, bAllowDiscountReset);
        }

        public void TrainCharRNN(bool bShowUi, string strTrainerType, LayerParameter.LayerType lstm, int nIterations = 100, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false)
        {
            m_evtCancel.Reset();

            GymCollection col = new GymCollection();
            col.Load();
            IXMyCaffeGymData igym = col.Find("DataGeneral") as IXMyCaffeGymData;
            m_log.CHECK(igym != null, "The 'DataGeneral' gym should implement the IXMyCaffeGymData interface.");

            string strAccelTrain = (bUseAcceleratedTraining) ? "ON" : "OFF";

            if (strTrainerType != "RNN.SIMPLE")
                throw new Exception("Currently, only the RNN.SIMPLE is supported.");

            m_log.WriteHeader("Test Training CharRNN for " + nIterations.ToString("N0") + " iterations.");
            m_log.WriteLine("Using trainer = " + strTrainerType + ", Accelerated Training = " + strAccelTrain);
            MyCaffeControl<T> mycaffe = new MyCaffeControl<T>(m_settings, m_log, m_evtCancel);
            mycaffe.OnSnapshot += Mycaffe_OnSnapshot;

            string strModelPath = getTestPath("\\MyCaffe\\test_data\\models\\rnn\\char_rnn\\" + lstm.ToString().ToLower(), true);

            MyCaffeDataGeneralTrainer trainer = new MyCaffeDataGeneralTrainer();
            ProjectEx project = getCharRNNProject(igym, nIterations, strModelPath, m_engine);
            DatasetDescriptor ds = trainer.GetDatasetOverride(0);

            m_log.CHECK(ds != null, "The MyCaffeDataTrainer should return its dataset override returned by the Gym that it uses.");

            string strEngine = m_engine.ToString();
            string strWeights = strModelPath + "\\weights." + strEngine + ".mycaffemodel";
            if (File.Exists(strWeights))
            {
                using (FileStream fs = File.OpenRead(strWeights))
                using (BinaryReader bw = new BinaryReader(fs))
                {
                    if (fs.Length > 0)
                    {
                        byte[] rgWeights = new byte[fs.Length];
                        bw.Read(rgWeights, 0, (int)fs.Length);
                        project.WeightsState = rgWeights;
                    }
                }
            }
            m_strModelPath = strModelPath;

            // Train the network using the custom trainer
            //  - Iterations (maximum frames cumulative across all threads) = 1000 (normally this would be much higher such as 500,000)
            //  - Learning rate = 0.05 (defined in solver.prototxt)
            //  - Mini Batch Size = 25 for LSTM, 1 for LSTM_SIMPLE (defined in train_val.prototxt for InputLayer)
            //
            //  - TrainerType = 'RNN.SIMPLE' (currently only one supported)
            //  - UseAcceleratedTraining = False (disable accelerated training).
            //  - ConnectionCount=1 (using one query)
            //  - Connection0_CustomQueryName=StdTextFileQuery (using standard text file query to read the text files)
            //  - Connection0_CustomQueryParam=params (set the custom query parameters to the packed parameters containing the FilePath where the text files are to be loaded).
            string strSchema = "ConnectionCount=1;";
            string strDataPath = getTestPath("\\MyCaffe\\test_data\\data\\char-rnn", true);
            string strParam = "FilePath=" + strDataPath + ";";

            strParam = ParamPacker.Pack(strParam);
            strSchema += "Connection0_CustomQueryName=StdTextFileQuery;";
            strSchema += "Connection0_CustomQueryParam=" + strParam + ";";

            string strProp = "TrainerType=" + strTrainerType + ";UseAcceleratedTraining=" + bUseAcceleratedTraining.ToString() + ";" + strSchema;
            trainer.Initialize(strProp, this);

            BucketCollection rgVocabulary = trainer.PreloadData(m_log, m_evtCancel, 0);
            project.ModelDescription = trainer.ResizeModel(project.ModelDescription, rgVocabulary);

            // load the project to train (note the project must use the InputLayer for input).
            mycaffe.Load(Phase.TRAIN, project, IMGDB_LABEL_SELECTION_METHOD.NONE, IMGDB_IMAGE_SELECTION_METHOD.NONE, false, null, false);

            if (bShowUi)
                trainer.OpenUi();

            m_nMaxIteration = nIterations;
            trainer.Train(mycaffe, nIterations);

            string type;
            int nN = 1000; // Note: see iterations used, for real training the iterations should be 100,000+
            byte[] rgOutput = trainer.Run(mycaffe, nN, out type); // For Run Parameters, see GetRunProperties() callback below.
            m_log.CHECK(type == "String", "The output type should be a string type!");
            string strOut;

            using (MemoryStream ms = new MemoryStream(rgOutput))
            {
                strOut = Encoding.ASCII.GetString(ms.ToArray());
            }

            m_log.WriteLine(strOut);

            string strOutputFile = strModelPath + "\\output" + ((typeof(T) == typeof(float)) ? "F" : "D") + ".txt";
            if (File.Exists(strOutputFile))
                File.Delete(strOutputFile);

            using (StreamWriter sw = new StreamWriter(strOutputFile))
            {
                sw.Write(strOut);
            }

            trainer.CleanUp();

            // Release the mycaffe resources.
            mycaffe.Dispose();
        }

        public void TrainCharRNNDual(bool bShowUi, string strTrainerType, LayerParameter.LayerType lstm, int nIterations = 100, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false)
        {
            m_evtCancel.Reset();

            GymCollection col = new GymCollection();
            col.Load();
            IXMyCaffeGymData igym = col.Find("DataGeneral") as IXMyCaffeGymData;
            m_log.CHECK(igym != null, "The 'DataGeneral' gym should implement the IXMyCaffeGymData interface.");

            string strAccelTrain = (bUseAcceleratedTraining) ? "ON" : "OFF";

            if (strTrainerType != "RNN.SIMPLE")
                throw new Exception("Currently, only the RNN.SIMPLE is supported.");

            m_log.WriteHeader("Test Training CharRNN for " + nIterations.ToString("N0") + " iterations.");
            m_log.WriteLine("Using trainer = " + strTrainerType + ", Accelerated Training = " + strAccelTrain);
            MyCaffeControl<T> mycaffe = new MyCaffeControl<T>(m_settings, m_log, m_evtCancel);
            mycaffe.OnSnapshot += Mycaffe_OnSnapshot;

            string strModelPath = getTestPath("\\MyCaffe\\test_data\\models\\rnn\\char_rnn\\" + lstm.ToString().ToLower(), true);

            MyCaffeDataGeneralTrainerDual trainerX = new MyCaffeDataGeneralTrainerDual();
            ProjectEx project = getCharRNNProject(igym, nIterations, strModelPath, m_engine);

            IXMyCaffeCustomTrainerRNN itrainer = trainerX as IXMyCaffeCustomTrainerRNN;
            if (itrainer == null)
                throw new Exception("The trainer must implement the IXMyCaffeCustomTrainerRNN interface!");

            DatasetDescriptor ds = itrainer.GetDatasetOverride(0);

            m_log.CHECK(ds != null, "The MyCaffeDataTrainer should return its dataset override returned by the Gym that it uses.");

            string strEngine = m_engine.ToString();
            string strWeights = strModelPath + "\\weights." + strEngine + ".mycaffemodel";
            if (File.Exists(strWeights))
            {
                using (FileStream fs = File.OpenRead(strWeights))
                using (BinaryReader bw = new BinaryReader(fs))
                {
                    if (fs.Length > 0)
                    {
                        byte[] rgWeights = new byte[fs.Length];
                        bw.Read(rgWeights, 0, (int)fs.Length);
                        project.WeightsState = rgWeights;
                    }
                }
            }
            m_strModelPath = strModelPath;

            // Train the network using the custom trainer
            //  - Iterations (maximum frames cumulative across all threads) = 1000 (normally this would be much higher such as 500,000)
            //  - Learning rate = 0.05 (defined in solver.prototxt)
            //  - Mini Batch Size = 25 for LSTM, 1 for LSTM_SIMPLE (defined in train_val.prototxt for InputLayer)
            //
            //  - TrainerType = 'RNN.SIMPLE' (currently only one supported)
            //  - UseAcceleratedTraining = False (disable accelerated training).
            //  - ConnectionCount=1 (using one query)
            //  - Connection0_CustomQueryName=StdTextFileQuery (using standard text file query to read the text files)
            //  - Connection0_CustomQueryParam=params (set the custom query parameters to the packed parameters containing the FilePath where the text files are to be loaded).
            string strSchema = "ConnectionCount=1;";
            string strDataPath = getTestPath("\\MyCaffe\\test_data\\data\\char-rnn", true);
            string strParam = "FilePath=" + strDataPath + ";";

            strParam = ParamPacker.Pack(strParam);
            strSchema += "Connection0_CustomQueryName=StdTextFileQuery;";
            strSchema += "Connection0_CustomQueryParam=" + strParam + ";";

            string strProp = "TrainerType=" + strTrainerType + ";UseAcceleratedTraining=" + bUseAcceleratedTraining.ToString() + ";" + strSchema;
            itrainer.Initialize(strProp, this);

            BucketCollection rgVocabulary = itrainer.PreloadData(m_log, m_evtCancel, 0);
            project.ModelDescription = itrainer.ResizeModel(project.ModelDescription, rgVocabulary);

            // load the project to train (note the project must use the InputLayer for input).
            mycaffe.Load(Phase.TRAIN, project, IMGDB_LABEL_SELECTION_METHOD.NONE, IMGDB_IMAGE_SELECTION_METHOD.NONE, false, null, false, true, itrainer.Stage.ToString());

            if (bShowUi)
                itrainer.OpenUi();

            m_nMaxIteration = nIterations;
            itrainer.Train(mycaffe, nIterations, TRAIN_STEP.NONE);

            string type;
            int nN = 1000; // Note: see iterations used, for real training the iterations should be 100,000+
            byte[] rgOutput = itrainer.Run(mycaffe, nN, out type); // For Run Parameters, see GetRunProperties() callback below.
            m_log.CHECK(type == "String", "The output type should be a string type!");
            string strOut;

            using (MemoryStream ms = new MemoryStream(rgOutput))
            {
                strOut = Encoding.ASCII.GetString(ms.ToArray());
            }

            m_log.WriteLine(strOut);

            string strOutputFile = strModelPath + "\\output" + ((typeof(T) == typeof(float)) ? "F" : "D") + ".txt";
            if (File.Exists(strOutputFile))
                File.Delete(strOutputFile);

            using (StreamWriter sw = new StreamWriter(strOutputFile))
            {
                sw.Write(strOut);
            }

            itrainer.CleanUp();

            // Release the mycaffe resources.
            mycaffe.Dispose();
        }


        public void TrainWavRNN(bool bDual, bool bShowUi, string strTrainerType, LayerParameter.LayerType lstm, int nIterations = 100, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false)
        {
            if (bDual)
                TrainWavRNNDual(bShowUi, strTrainerType, lstm, nIterations, bUseAcceleratedTraining, bAllowDiscountReset);
            else
                TrainWavRNN(bShowUi, strTrainerType, lstm, nIterations, bUseAcceleratedTraining, bAllowDiscountReset);
        }

        public void TrainWavRNN(bool bShowUi, string strTrainerType, LayerParameter.LayerType lstm, int nIterations = 100, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false)
        {
            m_evtCancel.Reset();

            GymCollection col = new GymCollection();
            col.Load();
            IXMyCaffeGymData igym = col.Find("DataGeneral") as IXMyCaffeGymData;
            m_log.CHECK(igym != null, "The 'DataGeneral' gym should implement the IXMyCaffeGymData interface.");

            string strAccelTrain = (bUseAcceleratedTraining) ? "ON" : "OFF";

            if (strTrainerType != "RNN.SIMPLE")
                throw new Exception("Currently, only the RNN.SIMPLE is supported.");

            m_log.WriteHeader("Test Training CharRNN for " + nIterations.ToString("N0") + " iterations.");
            m_log.WriteLine("Using trainer = " + strTrainerType + ", Accelerated Training = " + strAccelTrain);
            MyCaffeControl<T> mycaffe = new MyCaffeControl<T>(m_settings, m_log, m_evtCancel);
            mycaffe.OnSnapshot += Mycaffe_OnSnapshot;

            string strModelPath = getTestPath("\\MyCaffe\\test_data\\models\\rnn\\wav\\" + lstm.ToString().ToLower(), true);

            MyCaffeDataGeneralTrainer trainer = new MyCaffeDataGeneralTrainer();
            ProjectEx project = getCharRNNProject(igym, nIterations, strModelPath, EngineParameter.Engine.DEFAULT);
            DatasetDescriptor ds = trainer.GetDatasetOverride(0);

            m_log.CHECK(ds != null, "The MyCaffeDataTrainer should return its dataset override returned by the Gym that it uses.");

            string strEngine = m_engine.ToString();
            string strWeights = strModelPath + "\\weights." + strEngine + ".mycaffemodel";
            if (File.Exists(strWeights))
            {
                using (FileStream fs = File.OpenRead(strWeights))
                using (BinaryReader bw = new BinaryReader(fs))
                {
                    if (fs.Length > 0)
                    {
                        byte[] rgWeights = new byte[fs.Length];
                        bw.Read(rgWeights, 0, (int)fs.Length);
                        project.WeightsState = rgWeights;
                    }
                }
            }
            m_strModelPath = strModelPath;

            // Train the network using the custom trainer
            //  - Iterations (maximum frames cumulative across all threads) = 1000 (normally this would be much higher such as 500,000)
            //  - Learning rate = 0.05 (defined in solver.prototxt)
            //  - Mini Batch Size = 25 for LSTM, 1 for LSTM_SIMPLE (defined in train_val.prototxt for InputLayer)
            //
            //  - TrainerType = 'RNN.SIMPLE' (currently only one supported)
            //  - UseAcceleratedTraining = False (disable accelerated training).
            //  - ConnectionCount=1 (using one query)
            //  - Connection0_CustomQueryName=StdWAVFileQuery (using standard text file query to read the text files)
            //  - Connection0_CustomQueryParam=params (set the custom query parameters to the packed parameters containing the FilePath where the text files are to be loaded).
            string strSchema = "ConnectionCount=1;";
            string strDataPath = getTestPath("\\MyCaffe\\test_data\\data\\wav", true);
            string strParam = "FilePath=" + strDataPath + ";";

            strParam = ParamPacker.Pack(strParam);
            strSchema += "Connection0_CustomQueryName=StdWAVFileQuery;";
            strSchema += "Connection0_CustomQueryParam=" + strParam + ";";

            string strProp = "TrainerType=" + strTrainerType + ";UseAcceleratedTraining=" + bUseAcceleratedTraining.ToString() + ";Temperature=0.5;" + strSchema;
            trainer.Initialize(strProp, this);

            BucketCollection rgVocabulary = trainer.PreloadData(m_log, m_evtCancel, 0);
            project.ModelDescription = trainer.ResizeModel(project.ModelDescription, rgVocabulary);

            // load the project to train (note the project must use the InputLayer for input).
            mycaffe.Load(Phase.TRAIN, project, IMGDB_LABEL_SELECTION_METHOD.NONE, IMGDB_IMAGE_SELECTION_METHOD.NONE, false, null, false);

            if (bShowUi)
                trainer.OpenUi();

            m_nMaxIteration = nIterations;
            trainer.Train(mycaffe, nIterations);

            string type;
            int nN = 1000; // Note: see iterations used, for real training the iterations should be 100,000+
            byte[] rgOutput = trainer.Run(mycaffe, nN, out type);  // For Run Parameters, see GetRunProperties() callback below.
            m_log.CHECK(type == "WAV", "The output type should be a WAV type!");

            WaveFormat fmt;
            List<double[]> rgrgSamples = StandardQueryWAVFile.UnPackBytes(rgOutput, out fmt);

            string strOutputFile = strModelPath + "\\output.wav";
            using (FileStream fs = File.OpenWrite(strOutputFile))
            using (WAVWriter wav = new WAVWriter(fs))
            {
                wav.Format = fmt;
                wav.Samples = rgrgSamples;
                wav.WriteAll();
            }

            trainer.CleanUp();

            // Release the mycaffe resources.
            mycaffe.Dispose();
        }

        public void TrainWavRNNDual(bool bShowUi, string strTrainerType, LayerParameter.LayerType lstm, int nIterations = 100, bool bUseAcceleratedTraining = false, bool bAllowDiscountReset = false)
        {
            m_evtCancel.Reset();

            GymCollection col = new GymCollection();
            col.Load();
            IXMyCaffeGymData igym = col.Find("DataGeneral") as IXMyCaffeGymData;
            m_log.CHECK(igym != null, "The 'DataGeneral' gym should implement the IXMyCaffeGymData interface.");

            string strAccelTrain = (bUseAcceleratedTraining) ? "ON" : "OFF";

            if (strTrainerType != "RNN.SIMPLE")
                throw new Exception("Currently, only the RNN.SIMPLE is supported.");

            m_log.WriteHeader("Test Training CharRNN for " + nIterations.ToString("N0") + " iterations.");
            m_log.WriteLine("Using trainer = " + strTrainerType + ", Accelerated Training = " + strAccelTrain);
            MyCaffeControl<T> mycaffe = new MyCaffeControl<T>(m_settings, m_log, m_evtCancel);
            mycaffe.OnSnapshot += Mycaffe_OnSnapshot;

            string strModelPath = getTestPath("\\MyCaffe\\test_data\\models\\rnn\\wav\\" + lstm.ToString().ToLower(), true);

            MyCaffeDataGeneralTrainerDual trainerX = new MyCaffeDataGeneralTrainerDual();
            ProjectEx project = getCharRNNProject(igym, nIterations, strModelPath, EngineParameter.Engine.DEFAULT);

            IXMyCaffeCustomTrainerRNN itrainer = trainerX as IXMyCaffeCustomTrainerRNN;
            if (itrainer == null)
                throw new Exception("The trainer must implement the IXMyCaffeCustomTrainerRNN interface!");

            DatasetDescriptor ds = itrainer.GetDatasetOverride(0);

            m_log.CHECK(ds != null, "The MyCaffeDataTrainer should return its dataset override returned by the Gym that it uses.");

            string strEngine = m_engine.ToString();
            string strWeights = strModelPath + "\\weights." + strEngine + ".mycaffemodel";
            if (File.Exists(strWeights))
            {
                using (FileStream fs = File.OpenRead(strWeights))
                using (BinaryReader bw = new BinaryReader(fs))
                {
                    if (fs.Length > 0)
                    {
                        byte[] rgWeights = new byte[fs.Length];
                        bw.Read(rgWeights, 0, (int)fs.Length);
                        project.WeightsState = rgWeights;
                    }
                }
            }
            m_strModelPath = strModelPath;

            // Train the network using the custom trainer
            //  - Iterations (maximum frames cumulative across all threads) = 1000 (normally this would be much higher such as 500,000)
            //  - Learning rate = 0.05 (defined in solver.prototxt)
            //  - Mini Batch Size = 25 for LSTM, 1 for LSTM_SIMPLE (defined in train_val.prototxt for InputLayer)
            //
            //  - TrainerType = 'RNN.SIMPLE' (currently only one supported)
            //  - UseAcceleratedTraining = False (disable accelerated training).
            //  - ConnectionCount=1 (using one query)
            //  - Connection0_CustomQueryName=StdWAVFileQuery (using standard text file query to read the text files)
            //  - Connection0_CustomQueryParam=params (set the custom query parameters to the packed parameters containing the FilePath where the text files are to be loaded).
            string strSchema = "ConnectionCount=1;";
            string strDataPath = getTestPath("\\MyCaffe\\test_data\\data\\wav", true);
            string strParam = "FilePath=" + strDataPath + ";";

            strParam = ParamPacker.Pack(strParam);
            strSchema += "Connection0_CustomQueryName=StdWAVFileQuery;";
            strSchema += "Connection0_CustomQueryParam=" + strParam + ";";

            string strProp = "TrainerType=" + strTrainerType + ";UseAcceleratedTraining=" + bUseAcceleratedTraining.ToString() + ";Temperature=0.5;" + strSchema;
            itrainer.Initialize(strProp, this);

            BucketCollection rgVocabulary = itrainer.PreloadData(m_log, m_evtCancel, 0);
            project.ModelDescription = itrainer.ResizeModel(project.ModelDescription, rgVocabulary);

            // load the project to train (note the project must use the InputLayer for input).
            mycaffe.Load(Phase.TRAIN, project, IMGDB_LABEL_SELECTION_METHOD.NONE, IMGDB_IMAGE_SELECTION_METHOD.NONE, false, null, false, true, itrainer.Stage.ToString());

            if (bShowUi)
                itrainer.OpenUi();

            m_nMaxIteration = nIterations;
            itrainer.Train(mycaffe, nIterations, TRAIN_STEP.NONE);

            string type;
            int nN = 1000; // Note: see iterations used, for real training the iterations should be 100,000+
            byte[] rgOutput = itrainer.Run(mycaffe, nN, out type);  // For Run Parameters, see GetRunProperties() callback below.
            m_log.CHECK(type == "WAV", "The output type should be a WAV type!");

            WaveFormat fmt;
            List<double[]> rgrgSamples = StandardQueryWAVFile.UnPackBytes(rgOutput, out fmt);

            string strOutputFile = strModelPath + "\\output.wav";
            using (FileStream fs = File.OpenWrite(strOutputFile))
            using (WAVWriter wav = new WAVWriter(fs))
            {
                wav.Format = fmt;
                wav.Samples = rgrgSamples;
                wav.WriteAll();
            }

            itrainer.CleanUp();

            // Release the mycaffe resources.
            mycaffe.Dispose();
        }



        private void Mycaffe_OnSnapshot(object sender, SnapshotArgs e)
        {
            byte[] rgWeights = e.UpdateWeights();

            string strWeights = m_strModelPath + "\\weights." + m_engine.ToString() + ".mycaffemodel";

            if (File.Exists(strWeights))
                File.Delete(strWeights);

            using (FileStream fs = File.Open(strWeights, FileMode.OpenOrCreate))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(rgWeights);
            }
        }

        private ProjectEx getReinforcementProject(IXMyCaffeGym igym, int nIterations, DATA_TYPE dt = DATA_TYPE.VALUES, bool bForceSimple = false)
        {
            ProjectEx p = new ProjectEx("test");

            string strModelFile = getTestPath("\\MyCaffe\\test_data\\models\\reinforcement\\cartpole\\train_val.prototxt");
            string strSolverFile = getTestPath("\\MyCaffe\\test_data\\models\\reinforcement\\cartpole\\solver.prototxt");

            if (bForceSimple)
                strModelFile = getTestPath("\\MyCaffe\\test_data\\models\\reinforcement\\cartpole\\train_val_sigmoid.prototxt");

            if (dt == DATA_TYPE.BLOB)
            {
                strModelFile = getTestPath("\\MyCaffe\\test_data\\models\\reinforcement\\atari\\train_val.prototxt");
                strSolverFile = getTestPath("\\MyCaffe\\test_data\\models\\reinforcement\\atari\\solver.prototxt");
            }

            RawProto protoM = RawProtoFile.LoadFromFile(strModelFile);
            p.ModelDescription = protoM.ToString();

            RawProto protoS = RawProtoFile.LoadFromFile(strSolverFile);
            RawProto iter = protoS.FindChild("max_iter");
            iter.Value = nIterations.ToString();

            p.SolverDescription = protoS.ToString();
            p.SetDataset(igym.GetDataset(dt));

            return p;
        }

        private string getRomPath(string strRom)
        {
            return getTestPath("\\MyCaffe\\test_data\\roms\\" + strRom);
        }

        private ProjectEx getCharRNNProject(IXMyCaffeGym igym, int nIterations, string strPath, EngineParameter.Engine engine)
        {
            ProjectEx p = new ProjectEx("test");

            string strModelFile = strPath + "\\train_val.prototxt";
            string strSolverFile = strPath + "\\solver.prototxt";

            RawProto protoM = RawProtoFile.LoadFromFile(strModelFile);

            if (engine == EngineParameter.Engine.CUDNN)
            {
                NetParameter net_param = NetParameter.FromProto(protoM);

                for (int i = 0; i < net_param.layer.Count; i++)
                {
                    if (net_param.layer[i].type == LayerParameter.LayerType.LSTM)
                    {
                        net_param.layer[i].recurrent_param.engine = engine;
                    }
                }

                protoM = net_param.ToProto("root");
            }

            p.ModelDescription = protoM.ToString();

            RawProto protoS = RawProtoFile.LoadFromFile(strSolverFile);
            RawProto iter = protoS.FindChild("max_iter");
            iter.Value = nIterations.ToString();

            p.SolverDescription = protoS.ToString();
            p.SetDataset(igym.GetDataset(DATA_TYPE.BLOB));

            return p;
        }

        /// <summary>
        /// Get the properties to use during each call to Run.
        /// </summary>
        /// <returns>The properties are returned as a set of key=value pairs.</returns>
        /// <remarks>
        /// For now, the TRAIN phase is used during the Run (e.g. the TRAIN network)
        /// due to a bug in sharing the weights between the TRAIN and TEST/RUN networks.
        /// </remarks>
        public string GetRunProperties()
        {
            return "";
        }

        public void Update(TRAINING_CATEGORY cat, Dictionary<string, double> rgValues)
        {
            if (rgValues.ContainsKey("GlobalIteration"))
            {
                int nIteration = (int)rgValues["GlobalIteration"];

                if (m_nMaxIteration > 0)
                {
                    double dfProgress = (int)nIteration / (double)m_nMaxIteration;
                    m_progress.SetProgress(dfProgress);
                }
            }
        }
    }

    class MyCaffeCartPoleTrainer : MyCaffeTrainerRL, IXMyCaffeGymUiCallback
    {
        Stopwatch m_sw = new Stopwatch();        
        IXMyCaffeGym m_igym;
        Log m_log;
        bool m_bNormalizeInput = false;
        int m_nUiId = -1;
        MyCaffeGymUiProxy m_gymui = null;
        string m_strName = "Cart-Pole";
        GymCollection m_colGyms = new GymCollection();

        public MyCaffeCartPoleTrainer() 
            : base()
        {
            m_colGyms.Load();
        }

        protected override void initialize(InitializeArgs e)
        {
            m_igym = m_colGyms.Find(m_strName);
            m_log = e.OutputLog;

            m_bNormalizeInput = m_properties.GetPropertyAsBool("NormalizeInput", false);
            m_igym.Initialize(m_log, m_properties);

            m_sw.Start();
        }

        protected override void shutdown()
        {
            if (m_igym != null)
            {
                m_igym.Close();
                m_igym = null;
            }
        }

        protected override void dispose()
        {
            base.dispose();
        }

        protected override string name
        {
            get { return "RL.Trainer"; }
        }

        protected override DatasetDescriptor get_dataset_override(int nProjectID)
        {
            if (m_igym == null)
                m_igym = m_colGyms.Find(m_strName);

            return m_igym.GetDataset(DATA_TYPE.VALUES);
        }

        protected override bool getData(GetDataArgs e)
        {
            Tuple<State, double, bool> state = null;

            if (e.Reset)
                state = m_igym.Reset();

            if (e.Action >= 0)
                state = m_igym.Step(e.Action);

            bool bIsOpen = (m_nUiId >= 0) ? true : false;
            Tuple<Bitmap, SimpleDatum> data = m_igym.Render(bIsOpen, 512, 512, true);
            int nDataLen = 0;
            SimpleDatum stateData = state.Item1.GetData(m_bNormalizeInput, out nDataLen);
            Observation obs = new Observation(null, ImageData.GetImage(data.Item2), m_igym.RequiresDisplayImage, stateData.RealData, state.Item2, state.Item3);

            e.State = new StateBase(m_igym.GetActionSpace().Count());
            e.State.Reward = obs.Reward;
            e.State.Data = new SimpleDatum(true, nDataLen, 1, 1, -1, DateTime.Now, null, stateData.RealData.ToList(), 0, false, 0);
            e.State.Done = obs.Done;
            e.State.IsValid = true;

            if (m_gymui != null && m_nUiId >= 0)
            {
                m_gymui.Render(m_nUiId, obs);
                Thread.Sleep(m_igym.UiDelay);
            }

            if (m_sw.Elapsed.TotalMilliseconds > 1000)
            {
                double dfPct = (GlobalEpisodeMax == 0) ? 0 : (double)GlobalEpisodeCount / (double)GlobalEpisodeMax;
                e.OutputLog.Progress = dfPct;
                e.OutputLog.WriteLine("(" + dfPct.ToString("P") + ") Global Episode #" + GlobalEpisodeCount.ToString() + "  Global Reward = " + GlobalRewards.ToString() + " Exploration Rate = " + ExplorationRate.ToString("P") + " Optimal Selection Rate = " + OptimalSelectionRate.ToString("P"));
                m_sw.Restart();
            }

            return true;
        }

        protected override void openUi()
        {
            m_gymui = new MyCaffeGymUiProxy(new InstanceContext(this));
            m_gymui.Open();
            m_nUiId = m_gymui.OpenUi(m_strName, m_nUiId);
        }

        public void Closing()
        {
            m_nUiId = -1;
            m_gymui.Close();
            m_gymui = null;
        }
    }

    class MyCaffeAtariTrainer : MyCaffeTrainerRL, IXMyCaffeGymUiCallback
    {
        Stopwatch m_sw = new Stopwatch();
        IXMyCaffeGym m_igym;
        Log m_log;
        int m_nUiId = -1;
        MyCaffeGymUiProxy m_gymui = null;
        string m_strName = "ATARI";
        GymCollection m_colGyms = new GymCollection();
        DatasetDescriptor m_ds;

        public MyCaffeAtariTrainer()
            : base()
        {
            m_colGyms.Load();
        }

        protected override void initialize(InitializeArgs e)
        {
            m_igym = m_colGyms.Find(m_strName);
            m_log = e.OutputLog;

            m_igym.Initialize(m_log, m_properties);

            m_sw.Start();
        }

        protected override void shutdown()
        {
            if (m_igym != null)
            {
                m_igym.Close();
                m_igym = null;
            }
        }

        protected override void dispose()
        {
            base.dispose();
        }

        protected override string name
        {
            get { return "RL.Trainer"; }
        }

        protected override DatasetDescriptor get_dataset_override(int nProjectID)
        {
            if (m_igym == null)
                m_igym = m_colGyms.Find(m_strName);

            m_ds = m_igym.GetDataset(DATA_TYPE.BLOB);

            return m_ds;
        }

        protected override bool getData(GetDataArgs e)
        {
            Tuple<State, double, bool> state = null;

            if (e.Reset)
                state = m_igym.Reset();

            if (e.Action >= 0)
                state = m_igym.Step(e.Action);

            bool bIsOpen = (m_nUiId >= 0) ? true : false;
            Tuple<Bitmap, SimpleDatum> data = m_igym.Render(bIsOpen, 512, 512, true);
            int nDataLen = 0;
            SimpleDatum stateData = state.Item1.GetData(false, out nDataLen);
            Observation obs = new Observation(data.Item1, ImageData.GetImage(data.Item2), m_igym.RequiresDisplayImage, stateData.RealData, state.Item2, state.Item3);

            e.State = new StateBase(m_igym.GetActionSpace().Count());
            e.State.Reward = obs.Reward;
            e.State.Data = data.Item2;
            e.State.Done = obs.Done;
            e.State.IsValid = true;

            if (m_gymui != null && m_nUiId >= 0)
            {
                m_gymui.Render(m_nUiId, obs);
                Thread.Sleep(m_igym.UiDelay);
            }

            if (m_sw.Elapsed.TotalMilliseconds > 1000)
            {
                double dfPct = (GlobalEpisodeMax == 0) ? 0 : (double)GlobalEpisodeCount / (double)GlobalEpisodeMax;
                e.OutputLog.Progress = dfPct;
                e.OutputLog.WriteLine("(" + dfPct.ToString("P") + ") Global Episode #" + GlobalEpisodeCount.ToString() + "  Global Reward = " + GlobalRewards.ToString() + " Exploration Rate = " + ExplorationRate.ToString("P") + " Optimal Selection Rate = " + OptimalSelectionRate.ToString("P"));
                m_sw.Restart();
            }

            return true;
        }

        protected override void openUi()
        {
            m_gymui = new MyCaffeGymUiProxy(new InstanceContext(this));
            m_gymui.Open();
            m_nUiId = m_gymui.OpenUi(m_strName, m_nUiId);
        }

        public void Closing()
        {
            m_nUiId = -1;
            m_gymui.Close();
            m_gymui = null;
        }
    }

    class MyCaffeDataGeneralTrainer : MyCaffeTrainerRNN, IXMyCaffeGymUiCallback
    {
        Stopwatch m_sw = new Stopwatch();
        IXMyCaffeGym m_igym;
        Log m_log;
        int m_nUiId = -1;
        string m_strName = "DataGeneral";
        GymCollection m_colGyms = new GymCollection();
        DatasetDescriptor m_ds;
        Tuple<State, double, bool> m_firststate = null;

        public MyCaffeDataGeneralTrainer()
            : base()
        {
            m_colGyms.Load();
        }

        protected override void initialize(InitializeArgs e)
        {
            initialize(e.OutputLog);
            m_sw.Start();
        }

        private void initialize(Log log)
        {
            if (m_igym == null)
            {
                m_log = log;
                m_igym = m_colGyms.Find(m_strName);
                m_igym.Initialize(m_log, m_properties);
            }
        }

        protected override void shutdown()
        {
            if (m_igym != null)
            {
                m_igym.Close();
                m_igym = null;
            }
        }

        protected override void dispose()
        {
            base.dispose();
        }

        protected override string name
        {
            get { return "RNN.Trainer"; }
        }

        protected override DatasetDescriptor get_dataset_override(int nProjectID)
        {
            IXMyCaffeGym igym = m_igym;

            if (igym == null)
                igym = m_colGyms.Find(m_strName);

            m_ds = igym.GetDataset(DATA_TYPE.BLOB);

            return m_ds;
        }

        protected override bool getData(GetDataArgs e)
        {
            Tuple<State, double, bool> state = null;

            if (e.Reset)
            {
                if (m_firststate != null)
                {
                    state = m_firststate;
                    m_firststate = null;
                }
                else
                {
                    state = m_igym.Reset();
                }
            }

            if (e.Action >= 0)
                state = m_igym.Step(e.Action);

            bool bIsOpen = (m_nUiId >= 0) ? true : false;
            int nDataLen = 0;
            SimpleDatum stateData = state.Item1.GetData(false, out nDataLen);

            e.State = new StateBase(m_igym.GetActionSpace().Count());
            e.State.Reward = 0;
            e.State.Data = stateData;
            e.State.Done = state.Item3;
            e.State.IsValid = true;

            if (m_sw.Elapsed.TotalMilliseconds > 1000)
            {
                int nMax = (int)GetProperty("GlobalMaxIterations");
                int nIteration = (int)GetProperty("GlobalIteration");
                double dfPct = (nMax == 0) ? 0 : (double)nIteration / (double)nMax;
                e.OutputLog.Progress = dfPct;
                e.OutputLog.WriteLine("(" + dfPct.ToString("P") + ") Global Iteration #" + nIteration.ToString());
                m_sw.Restart();
            }

            return true;
        }

        protected override bool convertOutput(ConvertOutputArgs e)
        {
            IXMyCaffeGymData igym = m_igym as IXMyCaffeGymData;
            if (igym == null)
                throw new Exception("Output data conversion requires a gym that implements the IXMyCaffeGymData interface.");

            string type;
            byte[] rgOutput = igym.ConvertOutput(e.Output.Length, e.Output, out type);
            e.SetRawOutput(rgOutput, type);

            return true;
        }

        protected override void openUi()
        {
        }

        protected override BucketCollection preloaddata(Log log, CancelEvent evtCancel, int nProjectID)
        {
            initialize(log);
            IXMyCaffeGymData igym = m_igym as IXMyCaffeGymData;
            Tuple<State, double, bool> state = igym.Reset();
            int nDataLen;
            SimpleDatum sd = state.Item1.GetData(false, out nDataLen);
            BucketCollection rgBucketCollection = null;

            if (sd.IsRealData)
            {
                // Create the vocabulary bucket collection.
                rgBucketCollection = BucketCollection.Bucketize("Building vocabulary", 128, sd, log, evtCancel);
                if (rgBucketCollection == null)
                    return null;
            }
            else
            {
                List<int> rgVocabulary = new List<int>();

                for (int i = 0; i < sd.ByteData.Length; i++)
                {
                    int nVal = (int)sd.ByteData[i];

                    if (!rgVocabulary.Contains(nVal))
                        rgVocabulary.Add(nVal);
                }

                rgBucketCollection = new BucketCollection(rgVocabulary);
            }

            m_firststate = state;

            return rgBucketCollection;
        }

        public void Closing()
        {
        }
    }

    class MyCaffeCartPoleTrainerDual : MyCaffeTrainerDual, IXMyCaffeGymUiCallback
    {
        Stopwatch m_sw = new Stopwatch();
        IXMyCaffeGym m_igym;
        Log m_log;
        bool m_bNormalizeInput = false;
        int m_nUiId = -1;
        MyCaffeGymUiProxy m_gymui = null;
        string m_strName = "Cart-Pole";
        GymCollection m_colGyms = new GymCollection();

        public MyCaffeCartPoleTrainerDual()
            : base()
        {
            m_colGyms.Load();
        }

        protected override void initialize(InitializeArgs e)
        {
            m_igym = m_colGyms.Find(m_strName);
            m_log = e.OutputLog;

            m_bNormalizeInput = m_properties.GetPropertyAsBool("NormalizeInput", false);
            m_igym.Initialize(m_log, m_properties);

            m_sw.Start();
        }

        protected override void shutdown()
        {
            if (m_igym != null)
            {
                m_igym.Close();
                m_igym = null;
            }
        }

        protected override void dispose()
        {
            base.dispose();
        }

        protected override string name
        {
            get { return "RL.Trainer.Dual"; }
        }

        protected override DatasetDescriptor get_dataset_override(int nProjectID)
        {
            if (m_igym == null)
                m_igym = m_colGyms.Find(m_strName);

            return m_igym.GetDataset(DATA_TYPE.VALUES);
        }

        protected override bool getData(GetDataArgs e)
        {
            Tuple<State, double, bool> state = null;

            if (e.Reset)
                state = m_igym.Reset();

            if (e.Action >= 0)
                state = m_igym.Step(e.Action);

            bool bIsOpen = (m_nUiId >= 0) ? true : false;
            Tuple<Bitmap, SimpleDatum> data = m_igym.Render(bIsOpen, 512, 512, true);
            int nDataLen = 0;
            SimpleDatum stateData = state.Item1.GetData(m_bNormalizeInput, out nDataLen);
            Observation obs = new Observation(null, ImageData.GetImage(data.Item2), m_igym.RequiresDisplayImage, stateData.RealData, state.Item2, state.Item3);

            e.State = new StateBase(m_igym.GetActionSpace().Count());
            e.State.Reward = obs.Reward;
            e.State.Data = new SimpleDatum(true, nDataLen, 1, 1, -1, DateTime.Now, null, stateData.RealData.ToList(), 0, false, 0);
            e.State.Done = obs.Done;
            e.State.IsValid = true;

            if (m_gymui != null && m_nUiId >= 0)
            {
                m_gymui.Render(m_nUiId, obs);
                Thread.Sleep(m_igym.UiDelay);
            }

            if (m_sw.Elapsed.TotalMilliseconds > 1000)
            {
                double dfPct = (GlobalEpisodeMax == 0) ? 0 : (double)GlobalEpisodeCount / (double)GlobalEpisodeMax;
                e.OutputLog.Progress = dfPct;
                e.OutputLog.WriteLine("(" + dfPct.ToString("P") + ") Global Episode #" + GlobalEpisodeCount.ToString() + "  Global Reward = " + GlobalRewards.ToString() + " Exploration Rate = " + ExplorationRate.ToString("P") + " Optimal Selection Rate = " + OptimalSelectionRate.ToString("P"));
                m_sw.Restart();
            }

            return true;
        }

        protected override void openUi()
        {
            m_gymui = new MyCaffeGymUiProxy(new InstanceContext(this));
            m_gymui.Open();
            m_nUiId = m_gymui.OpenUi(m_strName, m_nUiId);
        }

        public void Closing()
        {
            m_nUiId = -1;
            m_gymui.Close();
            m_gymui = null;
        }
    }

    class MyCaffeAtariTrainerDual : MyCaffeTrainerDual, IXMyCaffeGymUiCallback
    {
        Stopwatch m_sw = new Stopwatch();
        IXMyCaffeGym m_igym;
        Log m_log;
        int m_nUiId = -1;
        MyCaffeGymUiProxy m_gymui = null;
        string m_strName = "ATARI";
        GymCollection m_colGyms = new GymCollection();
        DatasetDescriptor m_ds;

        public MyCaffeAtariTrainerDual()
            : base()
        {
            m_colGyms.Load();
        }

        protected override void initialize(InitializeArgs e)
        {
            m_igym = m_colGyms.Find(m_strName);
            m_log = e.OutputLog;

            m_igym.Initialize(m_log, m_properties);

            m_sw.Start();
        }

        protected override void shutdown()
        {
            if (m_igym != null)
            {
                m_igym.Close();
                m_igym = null;
            }
        }

        protected override void dispose()
        {
            base.dispose();
        }

        protected override string name
        {
            get { return "RL.Trainer"; }
        }

        protected override DatasetDescriptor get_dataset_override(int nProjectID)
        {
            if (m_igym == null)
                m_igym = m_colGyms.Find(m_strName);

            m_ds = m_igym.GetDataset(DATA_TYPE.BLOB);

            return m_ds;
        }

        protected override bool getData(GetDataArgs e)
        {
            Tuple<State, double, bool> state = null;

            if (e.Reset)
                state = m_igym.Reset();

            if (e.Action >= 0)
                state = m_igym.Step(e.Action);

            bool bIsOpen = (m_nUiId >= 0) ? true : false;
            Tuple<Bitmap, SimpleDatum> data = m_igym.Render(bIsOpen, 512, 512, true);
            int nDataLen = 0;
            SimpleDatum stateData = state.Item1.GetData(false, out nDataLen);
            Observation obs = new Observation(data.Item1, ImageData.GetImage(data.Item2), m_igym.RequiresDisplayImage, stateData.RealData, state.Item2, state.Item3);

            e.State = new StateBase(m_igym.GetActionSpace().Count());
            e.State.Reward = obs.Reward;
            e.State.Data = data.Item2;
            e.State.Done = obs.Done;
            e.State.IsValid = true;

            if (m_gymui != null && m_nUiId >= 0)
            {
                m_gymui.Render(m_nUiId, obs);
                Thread.Sleep(m_igym.UiDelay);
            }

            if (m_sw.Elapsed.TotalMilliseconds > 1000)
            {
                double dfPct = (GlobalEpisodeMax == 0) ? 0 : (double)GlobalEpisodeCount / (double)GlobalEpisodeMax;
                e.OutputLog.Progress = dfPct;
                e.OutputLog.WriteLine("(" + dfPct.ToString("P") + ") Global Episode #" + GlobalEpisodeCount.ToString() + "  Global Reward = " + GlobalRewards.ToString() + " Exploration Rate = " + ExplorationRate.ToString("P") + " Optimal Selection Rate = " + OptimalSelectionRate.ToString("P"));
                m_sw.Restart();
            }

            return true;
        }

        protected override void openUi()
        {
            m_gymui = new MyCaffeGymUiProxy(new InstanceContext(this));
            m_gymui.Open();
            m_nUiId = m_gymui.OpenUi(m_strName, m_nUiId);
        }

        public void Closing()
        {
            m_nUiId = -1;
            m_gymui.Close();
            m_gymui = null;
        }
    }

    class MyCaffeDataGeneralTrainerDual : MyCaffeTrainerDual, IXMyCaffeGymUiCallback
    {
        Stopwatch m_sw = new Stopwatch();
        IXMyCaffeGym m_igym;
        Log m_log;
        int m_nUiId = -1;
        string m_strName = "DataGeneral";
        GymCollection m_colGyms = new GymCollection();
        DatasetDescriptor m_ds;
        Tuple<State, double, bool> m_firststate = null;

        public MyCaffeDataGeneralTrainerDual()
            : base()
        {
            m_colGyms.Load();
        }

        protected override void initialize(InitializeArgs e)
        {
            initialize(e.OutputLog);
            m_sw.Start();
        }

        private void initialize(Log log)
        {
            if (m_igym == null)
            {
                m_log = log;
                m_igym = m_colGyms.Find(m_strName);
                m_igym.Initialize(m_log, m_properties);
            }
        }

        protected override void shutdown()
        {
            if (m_igym != null)
            {
                m_igym.Close();
                m_igym = null;
            }
        }

        protected override void dispose()
        {
            base.dispose();
        }

        protected override string name
        {
            get { return "RNN.Trainer.Dual"; }
        }

        protected override DatasetDescriptor get_dataset_override(int nProjectID)
        {
            IXMyCaffeGym igym = m_igym;

            if (igym == null)
                igym = m_colGyms.Find(m_strName);

            m_ds = igym.GetDataset(DATA_TYPE.BLOB);

            return m_ds;
        }

        protected override bool getData(GetDataArgs e)
        {
            Tuple<State, double, bool> state = null;

            if (e.Reset)
            {
                if (m_firststate != null)
                {
                    state = m_firststate;
                    m_firststate = null;
                }
                else
                {
                    state = m_igym.Reset();
                }
            }

            if (e.Action >= 0)
                state = m_igym.Step(e.Action);

            bool bIsOpen = (m_nUiId >= 0) ? true : false;
            int nDataLen = 0;
            SimpleDatum stateData = state.Item1.GetData(false, out nDataLen);

            e.State = new StateBase(m_igym.GetActionSpace().Count());
            e.State.Reward = 0;
            e.State.Data = stateData;
            e.State.Done = state.Item3;
            e.State.IsValid = true;

            if (m_sw.Elapsed.TotalMilliseconds > 1000)
            {
                int nMax = (int)GetProperty("GlobalMaxIterations");
                int nIteration = (int)GetProperty("GlobalIteration");
                double dfPct = (nMax == 0) ? 0 : (double)nIteration / (double)nMax;
                e.OutputLog.Progress = dfPct;
                e.OutputLog.WriteLine("(" + dfPct.ToString("P") + ") Global Iteration #" + nIteration.ToString());
                m_sw.Restart();
            }

            return true;
        }

        protected override bool convertOutput(ConvertOutputArgs e)
        {
            IXMyCaffeGymData igym = m_igym as IXMyCaffeGymData;
            if (igym == null)
                throw new Exception("Output data conversion requires a gym that implements the IXMyCaffeGymData interface.");

            string type;
            byte[] rgOutput = igym.ConvertOutput(e.Output.Length, e.Output, out type);
            e.SetRawOutput(rgOutput, type);

            return true;
        }

        protected override void openUi()
        {
        }

        protected override BucketCollection preloaddata(Log log, CancelEvent evtCancel, int nProjectID, out bool bUsePreloadData)
        {
            initialize(log);
            IXMyCaffeGymData igym = m_igym as IXMyCaffeGymData;
            Tuple<State, double, bool> state = igym.Reset();
            int nDataLen;
            SimpleDatum sd = state.Item1.GetData(false, out nDataLen);
            BucketCollection rgBucketCollection = null;

            bUsePreloadData = true;

            if (sd.IsRealData)
            {
                // Create the vocabulary bucket collection.
                rgBucketCollection = BucketCollection.Bucketize("Building vocabulary", 128, sd, log, evtCancel);
                if (rgBucketCollection == null)
                    return null;
            }
            else
            {
                List<int> rgVocabulary = new List<int>();

                for (int i = 0; i < sd.ByteData.Length; i++)
                {
                    int nVal = (int)sd.ByteData[i];

                    if (!rgVocabulary.Contains(nVal))
                        rgVocabulary.Add(nVal);
                }

                rgBucketCollection = new BucketCollection(rgVocabulary);
            }

            m_firststate = state;

            return rgBucketCollection;
        }

        public void Closing()
        {
        }
    }

}
