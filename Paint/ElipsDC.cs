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
        private Point Start = new Point(440, 200);
        private Point End = new Point(700, 300);

        public ElipsDC(Graphics grap, Pen pen, Color FillColor) : base(grap, pen, FillColor) { }

        public void Draw()
        {
            SolidBrush Brush = new SolidBrush(FillDrawColor);
            StartPoint = Start;
            EndPoint = End;
            Rectangle EllipRect = new Rectangle((int)StartPoint.X, (int)StartPoint.Y, (int)(EndPoint.X - StartPoint.X), (int)(EndPoint.Y - StartPoint.Y));
            GrapDraw.DrawEllipse(DPen, EllipRect);
            GrapDraw.FillEllipse(Brush, EllipRect);
        }
    }
}
