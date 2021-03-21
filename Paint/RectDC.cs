using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    public class RectDC
    {
        public RectDC() { }

        public void DRec(Pen PenRec, Brush RecBrut, Graphics graphics, PointF StartDraw, PointF EndDraw)
        {
            Rectangle RectRect = new Rectangle((int)StartDraw.X, (int)StartDraw.Y, (int)EndDraw.X, (int)EndDraw.Y);
            graphics.DrawRectangle(PenRec, RectRect);
            graphics.FillRectangle(RecBrut, RectRect);
        }
    }
}
