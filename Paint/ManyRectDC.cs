using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    class ManyRectDC
    {
        public ManyRectDC() { }

        public void DManyRect(Pen PenManRec, Brush ManRecBrut, Graphics graphics, PointF StartDraw, PointF EndDraw)
        {
            int LinX,LinY,CenterX,CenterY;
            LinX = (int)(Math.Abs(EndDraw.X - StartDraw.X)) / 2;
            LinY = (int)(Math.Abs(EndDraw.Y - StartDraw.Y)) / 2;
            CenterX = (int)(StartDraw.X + LinX);
            CenterY = (int)(StartDraw.Y + LinY);
            int Kol = 5;
            double Mout = Math.PI * 2 / Kol;

            Point[] PolygPointer = new Point[3];
            PolygPointer = new Point[Kol];

            for (int i = 0; i < Kol; i++)
            {
                PolygPointer[i].X = (int)(CenterX + Math.Cos(i * Mout) * LinX);
                PolygPointer[i].Y = (int)(CenterY + Math.Sin(i * Mout) * LinY);

            }

            graphics.DrawPolygon(PenManRec, PolygPointer);
            graphics.FillPolygon(ManRecBrut, PolygPointer);
        }

    }
}
