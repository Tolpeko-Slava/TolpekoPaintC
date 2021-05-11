using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//using Newtonsoft.Json;

namespace Paint
{
    [Serializable]
    public abstract class Figur
    {
        public Pen DPen;
        public Color FillDrawColor;
        public Graphics GrapDraw;
        protected Point StartDraw, EndDraw;
        public bool EndManyLine = false;
        protected Graphics DrPcael;
        protected bool endOfCurrentFigure = false;
        public Point RemovePoint = new Point (-1,-1);
        public int Up;
        protected Pen drPen = null;
        protected float penWidth = -1;
        protected Color penColor;

        public Figur(Point Start,Point End,Graphics gr, Pen p, Color FColor)
        {
            FillDrawColor = FColor;
            DPen = p;
            GrapDraw = gr;
            StartPoint = Start;
            EndPoint = End;
        }

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

        public virtual void Redraw(){ }

        public float PenWidth
        {
            get{return penWidth;}
            set
            {
                if (value < 0)
                    return;
                penWidth = value;
                if (drPen != null)
                    drPen.Width = value;
            }
        }
        public Color PenColor
        {
            get{return penColor;}
            set
            {
                penColor = value;
                if (drPen != null)
                    drPen.Color = value;
            }

        }

        public virtual IFigurRemov Clone()
        {
            return null;
        }

        // [JsonIgnore]
        public Pen DrPen
        {
            get
            {
                if ((drPen == null) && (PenWidth >= 0))
                {
                    drPen = new Pen(PenColor, PenWidth);
                    drPen.StartCap = drPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
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

        public bool EndOfCurrentFigure
        {
            get{return endOfCurrentFigure;}
            set{endOfCurrentFigure = value;}
        }

       // [JsonIgnore]
        public Graphics DrSpace  
        {
            get {return DrPcael;}
            set{ DrPcael = value;}
        }

        public virtual void Draw()
        {
            GrapDraw.DrawLine(DPen, StartDraw.X, StartDraw.Y, EndDraw.X, EndDraw.Y);
        }

    }
}
