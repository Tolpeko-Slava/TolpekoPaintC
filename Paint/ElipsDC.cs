using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    public class ElipsDC : Figur
    {
        public ElipsDC(Point StartPoin,Point EndPoin,Graphics grap, Pen pen, Color FillColor) : base(StartPoin,EndPoin,grap, pen, FillColor) { }

        public override void Draw()
        {
            if (EndDraw != RemovePoint)
            {
                SolidBrush Brush = new SolidBrush(FillDrawColor);
                Rectangle EllipRect = new Rectangle(StartPoint.X, StartPoint.Y, EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y);
                GrapDraw.DrawEllipse(DPen, EllipRect);
                GrapDraw.FillEllipse(Brush, EllipRect);
            }
            StartDraw = EndDraw = RemovePoint;
        }
    }

    public class ElipsCread: IFigur
    {
        public Figur Cread(Point Star, Point Endin, Graphics gr, Pen pen, Color FBrush)
        {
            return new ElipsDC(Star, Endin, gr, pen, FBrush);
        }
    }
}
