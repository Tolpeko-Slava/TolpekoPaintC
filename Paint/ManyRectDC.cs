using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    class ManyRectDC:Figur
    {
        private Point Start = new Point(400, 100);
        private Point End = new Point(700, 500);
        public ManyRectDC(Graphics grap, Pen pen, Color FillColor) : base(grap, pen, FillColor) { }

        public void Draw()
        {
            StartPoint = Start;
            EndPoint = End;
            int LinX, LinY, CenterX, CenterY;
            LinX = (int)(Math.Abs(EndPoint.X - StartPoint.X)) / 2;
            LinY = (int)(Math.Abs(EndPoint.Y - StartPoint.Y)) / 2;
            CenterX = (int)(StartPoint.X + LinX);
            CenterY = (int)(StartPoint.Y + LinY);
            int Kol = 5;
            double Mout = Math.PI * 2 / Kol;

            Point[] PolygPointer = new Point[3];
            PolygPointer = new Point[Kol];

            for (int i = 0; i < Kol; i++)
            {
                PolygPointer[i].X = (int)(CenterX + Math.Cos(i * Mout) * LinX);
                PolygPointer[i].Y = (int)(CenterY + Math.Sin(i * Mout) * LinY);

            }
            SolidBrush Brush = new SolidBrush(FillDrawColor);

            GrapDraw.DrawPolygon(DPen, PolygPointer);
            GrapDraw.FillPolygon(Brush, PolygPointer);
        }

    }
}
