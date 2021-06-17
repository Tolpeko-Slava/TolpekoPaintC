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
    public class ManyLineDC : Figur
    {
        public ManyLineDC(Point StartPoin, Point EndPoin, Graphics grap, Pen pen, Color FillColor) : base(StartPoin, EndPoin, grap, pen, FillColor) { }
        private int Num=0;
        private int i = 0;
        protected bool flag = false;
        public LinkedList<Point> points = new LinkedList<Point>();

        public override void Draw()
        {
            if (EndDraw != RemovePoint)
            {
                if (i == 0)
                {
                    points = new LinkedList<Point>();
                    points.AddLast(StartDraw);
                    i = i + 1;
                    points.AddLast(EndDraw);
                }

                if ((!EndManyLine) && (Num > 0))
                {
                    EndDraw = StartDraw;
                    points.AddLast(EndDraw);
                }
                if (EndManyLine)
                {
                    EndDraw = StartDraw;
                    points.AddLast(EndDraw);
                }

                GrapDraw.DrawLine(DPen, points.ElementAt<Point>(i - 1), points.ElementAt<Point>(i));
                i = i + 1;
                flag = false;

                Num = Num + 1;

                if (EndFigur)
                {
                    EndManyLine = false;
                    Num = 0;
                    i = 0;
                    StartDraw = EndDraw = RemovePoint;
                    flag = true;
                }
            }
        }

        public override IFigurRemov Clone()
        {
            ManyLineDC NewFigur = new ManyLineDC(StartDraw, EndDraw, GrapDraw, (Pen)DPen.Clone(), FillDrawColor);
            for (int num = 0; num < points.Count; num++)
            {
                NewFigur.points.AddLast(points.ElementAt<Point>(num));
            }
            NewFigur.EndFigur = this.flag;
            NewFigur.i = this.i;
            return NewFigur;
        }

        public override void Redraw()
        {

                int N = points.Count;
                if (N > 1)
                {
                    for (int i = 0; i < N - 1; i++)
                    {
                        GrapDraw.DrawLine(DrPen, points.ElementAt<Point>(i), points.ElementAt<Point>(i + 1));
                    }

                }
        }

    }

    public class ManyLineCread : IFigur
    {
        public IFigurRemov Cread(Point Star, Point Endin, Graphics gr, Pen pen, Color FBrush)
        {
            return new ManyLineDC(Star, Endin, gr, pen, FBrush);
        }
    }
}
