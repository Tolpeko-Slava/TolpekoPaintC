using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    class UserManyRectDC : Figur
    {
        public UserManyRectDC(Point StartPoin, Point EndPoin, Graphics grap, Pen pen, Color FillColor) : base(StartPoin, EndPoin, grap, pen, FillColor) { }
        private int Num = 0;
        private int n = 0;
        private Point Cycle = new Point(-1, -1);
        public LinkedList<Point> points = new LinkedList<Point>();

        public override void Draw()
        {
            if (EndDraw != RemovePoint)
            {
                SolidBrush Brush = new SolidBrush(FillDrawColor);
                if (n == 0)
                {
                    points = new LinkedList<Point>();
                    points.AddLast(StartDraw);
                    Cycle = StartDraw;
                    n = n + 1;
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

                GrapDraw.DrawLine(DPen, points.ElementAt<Point>(n - 1), points.ElementAt<Point>(n));

                n = n + 1;

                Num = Num + 1;

                if (EndManyLine)
                {
                    GrapDraw.DrawPolygon(DPen, points.ToArray());
                    GrapDraw.FillPolygon(Brush, points.ToArray());
                    EndManyLine = false;
                    Num = 0;
                    n = 0;
                    StartDraw = EndDraw = RemovePoint;
                    Brush.Dispose();
                    StartDraw = EndDraw = RemovePoint;
                }
            }
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
