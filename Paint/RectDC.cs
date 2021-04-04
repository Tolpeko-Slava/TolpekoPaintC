using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    public class RectDC : Figur
    {
        public RectDC(Point StartPoin, Point EndPoin, Graphics grap, Pen pen, Color FillColor) : base(StartPoin, EndPoin, grap, pen, FillColor) { }

        public override void Draw()
        {
            if (EndDraw != RemovePoint)
            {
                Point Repun = new Point(0, 0);
                if (EndDraw.X < StartDraw.X)
                {
                    Repun.X = StartDraw.X;
                    StartDraw.X = EndDraw.X;
                    EndDraw.X = Repun.X;
                }
                if (EndDraw.Y < StartDraw.Y)
                {
                    Repun.Y = StartDraw.Y;
                    StartDraw.Y = EndDraw.Y;
                    EndDraw.Y = Repun.Y;
                }
                SolidBrush Brush = new SolidBrush(FillDrawColor);
                Rectangle RectRect = new Rectangle(StartDraw.X, StartDraw.Y, EndDraw.X - StartDraw.X, EndDraw.Y - StartDraw.Y);
                GrapDraw.DrawRectangle(DPen, RectRect);
                GrapDraw.FillRectangle(Brush, RectRect);
            }
            StartDraw = EndDraw = RemovePoint;
        }
    }

    public class RectCread : IFigur
    {
        public Figur Cread(Point Star,Point Endin, Graphics gr, Pen pen, Color FBrush)
        {
            return new RectDC(Star, Endin, gr, pen, FBrush);
        }
    }
}
