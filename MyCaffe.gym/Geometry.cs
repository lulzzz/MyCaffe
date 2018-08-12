﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCaffe.gym
{

    abstract class GeomObj
    {
        protected PointF m_location = new PointF(0, 0);
        protected List<PointF> m_rgPoints = new List<PointF>();
        protected Color m_clrFill = Color.LightGray;
        protected Color m_clrBorder = Color.Black;
        protected float m_fRotation = 0;
        System.Drawing.Drawing2D.GraphicsState m_gstate = null;

        public GeomObj(float fL, float fR, float fT, float fB, Color clrFill, Color clrBorder)
        {
            m_rgPoints.Add(new PointF(fL, fB));
            m_rgPoints.Add(new PointF(fL, fT));
            m_rgPoints.Add(new PointF(fR, fT));
            m_rgPoints.Add(new PointF(fR, fB));
            m_rgPoints.Add(new PointF(fL, fB));
            m_clrFill = clrFill;
            m_clrBorder = clrBorder;
        }

        protected void prerender(Graphics g)
        {
            m_gstate = g.Save();
            g.TranslateTransform(m_location.X, m_location.Y);
            g.RotateTransform(m_fRotation);
        }

        protected void postrender(Graphics g)
        {
            if (m_gstate != null)
            {
                g.Restore(m_gstate);
                m_gstate = null;
            }
        }

        public float Width(PointF[] rg)
        {
            if (rg == null)
                rg = m_rgPoints.ToArray();

            return rg[2].X - rg[0].X;
        }

        public float Height(PointF[] rg)
        {
            if (rg == null)
                rg = m_rgPoints.ToArray();

            return rg[0].Y - rg[1].Y;
        }

        public PointF LeftBottom(PointF[] rg = null)
        {
            if (rg == null)
                rg = m_rgPoints.ToArray();

            return rg[0];
        }

        public PointF LeftTop(PointF[] rg = null)
        {
            if (rg == null)
                rg = m_rgPoints.ToArray();

            return rg[1];
        }

        public PointF RightTop(PointF[] rg = null)
        {
            if (rg == null)
                rg = m_rgPoints.ToArray();

            return rg[2];
        }

        public PointF RightBottom(PointF[] rg = null)
        {
            if (rg == null)
                rg = m_rgPoints.ToArray();

            return rg[3];
        }

        public PointF Location
        {
            get { return m_location; }
        }

        public float Rotation
        {
            get { return m_fRotation; }
        }

        public virtual void SetLocation(float fX, float fY)
        {
            m_location = new PointF(fX, fY);
        }

        public virtual void SetRotation(float fR)
        {
            m_fRotation = fR;
        }

        public List<PointF> Polygon
        {
            get { return m_rgPoints; }
        }

        public Color FillColor
        {
            get { return m_clrFill; }
        }

        public Color BorderColor
        {
            get { return m_clrBorder; }
        }

        public abstract void Render(Graphics g);
    }


    class GeomLine : GeomObj
    {
        public GeomLine(float fL, float fR, float fT, float fB, Color clrFill, Color clrBorder)
            : base(fL, fR, fT, fB, clrFill, clrBorder)
        {
        }

        public override void Render(Graphics g)
        {
            prerender(g);
            PointF[] rg = m_rgPoints.ToArray();
            Pen p = new Pen(m_clrBorder, 1.0f);
            g.DrawLine(p, LeftBottom(rg), RightBottom(rg));
            p.Dispose();
            postrender(g);
        }
    }

    class GeomEllipse : GeomObj
    {
        public GeomEllipse(float fL, float fR, float fT, float fB, Color clrFill, Color clrBorder)
            : base(fL, fR, fT, fB, clrFill, clrBorder)
        {
        }

        public override void Render(Graphics g)
        {
            prerender(g);
            PointF[] rg = m_rgPoints.ToArray();
            RectangleF rc = new RectangleF(LeftTop(rg).X, LeftTop(rg).Y, Width(rg), Height(rg));
            Brush br = new SolidBrush(m_clrFill);
            Pen p = new Pen(m_clrBorder, 1.0f);
            g.FillEllipse(br, rc);
            g.DrawEllipse(p, rc);
            p.Dispose();
            br.Dispose();
            postrender(g);
        }
    }

    class GeomPolygon : GeomObj
    {
        public GeomPolygon(float fL, float fR, float fT, float fB, Color clrFill, Color clrBorder)
            : base(fL, fR, fT, fB, clrFill, clrBorder)
        {
        }

        public override void Render(Graphics g)
        {
            prerender(g);
            PointF[] rg = m_rgPoints.ToArray();
            Brush br = new SolidBrush(m_clrFill);
            Pen p = new Pen(m_clrBorder, 1.0f);
            g.FillPolygon(br, rg);
            g.DrawPolygon(p, rg);
            p.Dispose();
            br.Dispose();
            postrender(g);
        }
    }

    class GeomView
    {
        List<GeomObj> m_rgObj = new List<GeomObj>();

        public GeomView()
        {
        }

        public void AddObject(GeomObj obj)
        {
            m_rgObj.Add(obj);
        }

        public void Render(Graphics g)
        {
            System.Drawing.Drawing2D.GraphicsState gstate = g.Save();

            g.TranslateTransform(0, -g.VisibleClipBounds.Height);
            g.ScaleTransform(1, -1, System.Drawing.Drawing2D.MatrixOrder.Append);

            g.DrawRectangle(Pens.SteelBlue, 1, 1, 2, 2);
            g.DrawLine(Pens.SteelBlue, 1, 3, 1, 4);
            g.DrawLine(Pens.SteelBlue, 3, 3, 4, 4);
            g.DrawLine(Pens.SteelBlue, 3, 1, 4, 1);

            foreach (GeomObj obj in m_rgObj)
            {
                obj.Render(g);
            }

            g.Restore(gstate);
        }
    }
}