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
        public ManyRectDC(Point StartPoin, Point EndPoin, Graphics grap, Pen pen, Color FillColor) : base(StartPoin, EndPoin, grap, pen, FillColor) { }

        private int KolUp;
        public int Kol
        {
            get { return KolUp; }
            set { KolUp=value; } 
        }

        public override void Draw()
        {
            //int Kol=3;
           // Kol = NumberUp;
            if (EndDraw != RemovePoint)
            {
                //Uper = Up;
                int LinX, LinY, CenterX, CenterY;
                double Mout = Math.PI * 2 / Kol;

                Point[] PolygPointer = new Point[3];
                PolygPointer = new Point[Kol];
                SolidBrush Brush = new SolidBrush(FillDrawColor);

                LinX = (int)(EndPoint.X - StartPoint.X) / 2;
                LinY = (int)(EndPoint.Y - StartPoint.Y) / 2;
                CenterX = (int)(StartPoint.X + LinX);
                CenterY = (int)(StartPoint.Y + LinY);

                for (int i = 0; i < Kol; i++)
                {
                    PolygPointer[i].X = (int)(CenterX + Math.Cos(i * Mout) * LinX);
                    PolygPointer[i].Y = (int)(CenterY + Math.Sin(i * Mout) * LinY);

                }

                GrapDraw.DrawPolygon(DPen, PolygPointer);
                GrapDraw.FillPolygon(Brush, PolygPointer);
            }
            StartDraw = EndDraw = RemovePoint;
        }

    }

    public class ManyRectCraed: IFigur
    {
        public Figur Cread(Point Star, Point Endin, Graphics gr, Pen pen, Color FBrush)
        {
            return new ManyRectDC(Star, Endin, gr, pen, FBrush);
        }
    }
}
