using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    public class RectDC:Figur
    {
        private Point Start = new Point(440, 200);
        private Point End = new Point(700, 300);

        public RectDC(Graphics grap, Pen pen, Color FillColor) : base(grap, pen, FillColor) { }

        public void Draw()
        {
            SolidBrush Brush = new SolidBrush(FillDrawColor);
            StartPoint = Start;
            EndPoint = End;
            Rectangle RectRect = new Rectangle((int)StartDraw.X, (int)StartDraw.Y, (int)EndDraw.X, (int)EndDraw.Y);
            GrapDraw.DrawRectangle(DPen, RectRect);
            GrapDraw.FillRectangle(Brush, RectRect);
        }
    }
}
