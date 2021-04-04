using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    public abstract class Figur
    {
        public Pen DPen;
        public Color FillDrawColor;
        public Graphics GrapDraw;
        protected Point StartDraw, EndDraw;
        public bool EndManyLine = false;
        public Point RemovePoint = new Point (-1,-1);
        public int Up;
        
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

        public virtual void Draw()
        {
            GrapDraw.DrawLine(DPen, StartDraw.X, StartDraw.Y, EndDraw.X, EndDraw.Y);
        }

    }
}
