using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using InterfesV;

namespace Paint
{
    [Serializable]
    class ManyRectDC:Figur
    {
        private Point Pounters = new Point(-1, -1);

        public ManyRectDC(Point StartPoin, Point EndPoin, Graphics grap, Pen pen, Color FillColor) : base(StartPoin, EndPoin, grap, pen, FillColor) { }
        //private Point RemovePoint = new Point(-1, -1);
        private int KolUp = 3;
        public int Kol
        {
            get { return KolUp; }
            set { KolUp=value; } 
        }

        public override void Draw()
        {
            if (EndPoint != Pounters)
            {
                this.Redraw();
            }
        }

        public override void Redraw()
        {
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

        public override IFigurRemov Clone()
        {
            ManyRectDC NewFigur = new ManyRectDC(StartDraw, EndDraw, GrapDraw, (Pen)DPen.Clone(), FillDrawColor);
            NewFigur.KolUp = KolUp;
            NewFigur.EndFigur = true;
            return NewFigur;
        }

    }

    public class ManyRectCraed: IFigur
    {
        public IFigurRemov Cread(Point Star, Point Endin, Graphics gr, Pen pen, Color FBrush)
        {
            return new ManyRectDC(Star, Endin, gr, pen, FBrush);
        }
    }
}
