using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    public class LineDC : Figur
    {
        public LineDC(Graphics grap, Pen pen, Color FillColor) : base(grap, pen, FillColor) { }

        public void Draw()
        {
            GrapDraw.DrawLine(DPen, StartDraw.X, StartDraw.Y, EndDraw.X, EndDraw.Y);
        }
    }
}
