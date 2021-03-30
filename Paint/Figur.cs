using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    public class Figur
    {
        public Pen DPen;
        public Color FillDrawColor;
        public Graphics GrapDraw;
        protected Point StartDraw, EndDraw;

        public Figur(Graphics gr, Pen p, Color FColor)
        {
            FillDrawColor = FColor;
            DPen = p;
            GrapDraw = gr;
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
    }
}
