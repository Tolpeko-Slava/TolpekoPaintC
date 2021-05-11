﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    public class ManyLineDC : Figur
    {
        public ManyLineDC(Point StartPoin, Point EndPoin, Graphics grap, Pen pen, Color FillColor) : base(StartPoin, EndPoin, grap, pen, FillColor) { }
        private int Num=0;
        private int n = 0;
        public LinkedList<Point> points = new LinkedList<Point>();

        public override void Draw()
        {
            if (EndDraw != RemovePoint)
            {
                if (n == 0)
                {
                    points = new LinkedList<Point>();
                    points.AddLast(StartDraw);
                    n = n + 1;
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

                GrapDraw.DrawLine(DPen, points.ElementAt<Point>(n - 1), points.ElementAt<Point>(n));
                n = n + 1;

                Num = Num + 1;

                if (EndManyLine)
                {
                    EndManyLine = false;
                    Num = 0;
                    n = 0;
                    StartDraw = EndDraw = RemovePoint;
                }
            }
        }
    }

    public class ManyLineCread : IFigur
    {
        public Figur Cread(Point Star, Point Endin, Graphics gr, Pen pen, Color FBrush)
        {
            return new ManyLineDC(Star, Endin, gr, pen, FBrush);
        }
    }
}
