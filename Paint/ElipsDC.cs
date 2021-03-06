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
    public class ElipsDC : Figur
    {
        private Point Pounters = new Point(-1, -1);

        public ElipsDC(Point StartPoin,Point EndPoin,Graphics grap, Pen pen, Color FillColor) : base(StartPoin,EndPoin,grap, pen, FillColor) { }

        public override void Draw()
        {
            if (EndPoint != Pounters)
            {
                this.Redraw();
            }
        }

        public override void Redraw()
        {
            SolidBrush Brush = new SolidBrush(FillDrawColor);
            Rectangle EllipRect = new Rectangle(StartPoint.X, StartPoint.Y, EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y);
            GrapDraw.DrawEllipse(DPen, EllipRect);
            GrapDraw.FillEllipse(Brush, EllipRect);
        }

        public override IFigurRemov Clone()
        {
            ElipsDC NewF = new ElipsDC(StartDraw, EndDraw, GrapDraw, (Pen)DPen.Clone(), FillDrawColor);
            NewF.EndFigur = true;
            return NewF;
        }

    }

    public class ElipsCread: IFigur
    {
        public IFigurRemov Cread(Point Star, Point Endin, Graphics gr, Pen pen, Color FBrush)
        {
            return new ElipsDC(Star, Endin, gr, pen, FBrush);
        }
    }
}
