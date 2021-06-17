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
    public class LineDC : Figur
    {
        private Point Pounters = new Point(-1,-1);

        public LineDC(Point StartPoin, Point EndPoin, Graphics grap, Pen pen, Color FillColor) : base(StartPoin, EndPoin, grap, pen, FillColor) { }

        public override void Draw()
        {
            if (EndPoint != Pounters)
            {
                this.Redraw();
            }
        }

        public override void Redraw()
        {
            GrapDraw.DrawLine(DPen, StartDraw.X, StartDraw.Y, EndDraw.X, EndDraw.Y);
        }

        public override IFigurRemov Clone()
        {
            LineDC NewFigur = new LineDC(StartDraw, EndDraw, GrapDraw, (Pen)DPen.Clone(), FillDrawColor);
            NewFigur.EndFigur = true;
            return NewFigur;
        }

    }

    public class LineCread : IFigur
    {
        public IFigurRemov Cread(Point Star,Point Endin, Graphics gr, Pen pen, Color FBrush)
        {
            return new LineDC(Star, Endin, gr, pen, FBrush);
        }
    }
    
}
