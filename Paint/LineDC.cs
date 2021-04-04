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
        public LineDC(Point StartPoin, Point EndPoin, Graphics grap, Pen pen, Color FillColor) : base(StartPoin, EndPoin, grap, pen, FillColor) { }

        public override void Draw()
        {
            if (EndDraw != RemovePoint)
            {
                GrapDraw.DrawLine(DPen, StartDraw.X, StartDraw.Y, EndDraw.X, EndDraw.Y);
            }
            StartDraw = EndDraw = RemovePoint;
        }
    }

    public class LineCread : IFigur
    {
        public Figur Cread(Point Star,Point Endin, Graphics gr, Pen pen, Color FBrush)
        {
            return new LineDC(Star, Endin, gr, pen, FBrush);
        }
    }
    
}
