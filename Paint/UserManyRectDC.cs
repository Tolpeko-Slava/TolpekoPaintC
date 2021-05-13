using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    [Serializable]
    class UserManyRectDC : Figur
    {
        public UserManyRectDC(Point StartPoin, Point EndPoin, Graphics grap, Pen pen, Color FillColor) : base(StartPoin, EndPoin, grap, pen, FillColor) { }
        private int Num = 0;
        private int i = 0;
        protected bool flag = false;
        private Point Cycle = new Point(-1, -1);
        public LinkedList<Point> points = new LinkedList<Point>();

        public override void Draw()
        {
            if (EndDraw != RemovePoint)
            {
                SolidBrush Brush = new SolidBrush(FillDrawColor);
                if (i == 0)
                {
                    points = new LinkedList<Point>();
                    points.AddLast(StartDraw);
                    Cycle = StartDraw;
                    i = i + 1;
                    points.AddLast(EndDraw);
                    points.AddLast(Cycle);
                }

                if (Num > 0)
                {
                    EndDraw = StartDraw;
                    points.RemoveLast();
                    points.AddLast(EndDraw);
                    points.AddLast(Cycle);
                }

                GrapDraw.DrawLine(DPen, points.ElementAt<Point>(i - 1), points.ElementAt<Point>(i));
                i = i + 1;
                flag = false;
                Num = Num + 1;

                if (EndManyLine)
                {
                    GrapDraw.DrawPolygon(DPen, points.ToArray());
                    GrapDraw.FillPolygon(Brush, points.ToArray());
                    EndManyLine = false;
                    Num = 0;
                    i = 0;
                    StartDraw = EndDraw = RemovePoint;
                    Brush.Dispose();
                    StartDraw = EndDraw = RemovePoint;
                    flag = true;
                }
            }
        }

        public override IFigurRemov Clone()
        {
            UserManyRectDC NewFigur = new UserManyRectDC(StartDraw, EndDraw, GrapDraw, (Pen)DPen.Clone(), FillDrawColor);
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
           var brush = new SolidBrush(FillDrawColor);
           GrapDraw.DrawPolygon(DPen, points.ToArray());
           GrapDraw.FillPolygon(brush, points.ToArray());
           brush.Dispose();
        }
    }

    public class UserManyRectCread : IFigur
    {
        public Figur Cread(Point Star, Point Endin, Graphics gr, Pen pen, Color FBrush)
        {
            return new UserManyRectDC(Star, Endin, gr, pen, FBrush);
        }
    }

}
