using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;

namespace Trapez
{
    [Serializable]
    class TrapezDC : IFigurRemov
    {
        protected Pen drPen = null;
        protected float penWidth = -1;
        protected Point startPoint;
        protected bool EndDrawFigur = false;
        protected Point endPoint = new Point(-1, -1);
        protected Color penColor;

        public virtual Point StartPoint
        {
            get{return startPoint;}
            set{startPoint = value;}
        }

        public bool EndFigur
        {
            get { return EndDrawFigur; }
            set { EndDrawFigur = value; }
        }

        public Point EndPoint
        {
            get{return endPoint;}
            set{endPoint = value;}
        }

        public TrapezDC(int x0, int y0, Graphics gr, Pen pen, Color Fc)
        {
            startPoint = new Point(x0, y0);
            GrapDraw = gr;
            DPen = pen;
            FillColor = Fc;

        }

        public Color PenColor
        {
            get
            {
                return penColor;
            }

            set
            {
                penColor = value;
                if (drPen != null)
                    drPen.Color = value;
            }

        }

        [JsonIgnore]
        public Pen DPen
        {
            get
            {
                if ((drPen == null) && (PenWidth >= 0))
                {
                    drPen = new Pen(PenColor, PenWidth);
                    drPen.StartCap = drPen.EndCap = new Point(-1, -1);
                }
                return drPen;
            }
            set
            {
                if (value != null)
                {
                    penWidth = value.Width;
                    penColor = value.Color;
                }
                drPen = value;
            }

        }
        [JsonIgnore]
        public Graphics GrapDraw { get; set; }
        public Color FillColor { get; set; }
        public float PenWidth
        {
            get
            {
                return penWidth;
            }
            set
            {
                if (value < 0)
                    return;
                penWidth = value;
                if (drPen != null)
                    drPen.Width = value;
            }
        }



        public IFigurRemov Clone()
        {
            TrapezDC NewF = new TrapezDC(StartPoint, EndPoint, GrapDraw, (Pen)DPen.Clone(), FillColor);
            return NewF;
        }

        public virtual void Draw()
        {
            this.Redraw();
        }

        public void Redraw()
        {

            Point[] points = new Point[4];
            int r = (int)(endPoint.X - startPoint.X) / 2;

            var center = new PointF(StartPoint.X + r, startPoint.Y + r);
            points[0] = startPoint;
            points[1] = new Point(startPoint.X + r, startPoint.Y);
            points[2] = endPoint;
            points[3] = new Point(endPoint.X - r - (int)(2 * r), endPoint.Y);


            var brush = new SolidBrush(FillColor);

            GrapDraw.DrawPolygon(DPen, points);
            GrapDraw.FillPolygon(brush, points);

            brush.Dispose();

        }

    }


    public class TrapezeCreator : IFigur
    {
        public IFigurRemov Cread(int x0, int y0, Graphics gr, Pen pen, Color Fc)
        {
            return new TrapezDC(x0, y0, gr, pen, Fc);
        }
    }
}
