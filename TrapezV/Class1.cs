using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;
using InterfesV;

namespace TrapezV
{
    [Serializable]
    public class Trapez : IFigurRemov
    {
        private Point Pounters = new Point(-1, -1);

        public Trapez(Point StartPoin, Point EndPoin, Graphics grap, Pen pen, Color FillColor) 
        {
            StartDraw = StartPoin;
            EndDraw = EndPoin;
            DPen = pen;
            GrapDraw = grap;
            FillDrawColor = FillColor;
        }

        public IFigurRemov Clone()
        {
            Trapez NewF = new Trapez(StartDraw, EndDraw, GrapDraw, (Pen)DPen.Clone(), FillDrawColor);
            NewF.EndFigur = true;
            return NewF;
        }

        public void Draw()
        {
            if (EndPoint != Pounters)
            {
                this.Redraw();
            }
        }

        public void Redraw()
        {

            Point[] points = new Point[4];
            int r = (int)(EndDraw.X - StartDraw.X) / 2;

            var center = new PointF(StartDraw.X + r, StartDraw.Y + r);
            points[0] = StartDraw;
            points[1] = new Point(StartDraw.X + r, StartDraw.Y);
            points[2] = EndDraw;
            points[3] = new Point(EndDraw.X - r - (int)(2 * r), EndDraw.Y);


            var brush = new SolidBrush(FillDrawColor);

            GrapDraw.DrawPolygon(DPen, points);
            GrapDraw.FillPolygon(brush, points);

            //  brush.Dispose();

        }

        // protected Pen DPen;
        protected Pen DrPen;
        protected Point StartDraw, EndDraw;
        public bool EndManyLine = false;
        protected Graphics DrPcael;
        protected float penWidth = -1;
        protected Color penColor;
        bool EndDrawFigur = false;
        public Color FillColor { get; set; }
        //  public Point RemovePoint = new Point(-1, -1);
        // public int Up;


        public Color FillDrawColor { get; set; }

        [JsonIgnore]
        public Graphics GrapDraw
        {
            get
            { return DrPcael; }
            set
            { DrPcael = value; }
        }

        public float PenWidth
        {
            get
            { return penWidth; }
            set
            {
                if (value < 0)
                    return;
                penWidth = value;
                if (DPen != null)
                    DPen.Width = value;
            }
        }

        public Color PenColor
        {
            get
            { return penColor; }
            set
            {
                penColor = value;
                if (DPen != null)
                    DPen.Color = value;
            }

        }

        [JsonIgnore]
        public Pen DPen
        {
            get
            {
                if ((DrPen == null) && (PenWidth >= 0))
                {
                    DrPen = new Pen(PenColor, PenWidth);
                    DrPen.StartCap = DrPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                }
                return DrPen;
            }
            set
            {
                if (value != null)
                {
                    penWidth = value.Width;
                    penColor = value.Color;
                }
                DrPen = value;
            }

        }

        public virtual bool OnePointBack() { return false; }


        public virtual Point StartPoint
        {
            get { return StartDraw; }
            set { StartDraw = value; }
        }

        public virtual Point EndPoint
        {
            get { return EndDraw; }
            set { EndDraw = value; }
        }

        public bool EndFigur
        {
            get { return EndDrawFigur; }
            set { EndDrawFigur = value; }
        }

    }

    public class Creator : IFigur
    {
        public  IFigurRemov Cread(Point Star, Point Endin, Graphics gr, Pen pen, Color Fc)
        {
            return new Trapez(Star, Endin, gr, pen, Fc);
        }
    }
}
