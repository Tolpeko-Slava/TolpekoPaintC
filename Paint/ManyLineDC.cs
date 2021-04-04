using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    public class ManyLineDC : Figur
    {
        public ManyLineDC(Point StartPoin, Point EndPoin, Graphics grap, Pen pen, Color FillColor) : base(StartPoin, EndPoin, grap, pen, FillColor) { }
        private int Num=0;
        

        public override void Draw()
        {
            if (EndDraw != RemovePoint)
            {
                GrapDraw.DrawLine(DPen, StartDraw.X, StartDraw.Y, EndDraw.X, EndDraw.Y);

                if ((!EndManyLine) && (Num > 0))
                {
                    EndDraw = StartDraw;
                }

                Num = Num + 1;

                if (EndManyLine)
                {
                    EndManyLine = false;
                    Num = 0;

                    StartDraw = EndDraw = RemovePoint;
                }
            }
        }
    }

    public class ManyLineCread : IFigur
    {
        public Figur Cread(Point Star, Point Endin, Graphics gr, Pen pen, Color FBrush)
        {
            return new ManyLineDC(Star, Endin, gr, pen, FBrush);
        }
    }
}
