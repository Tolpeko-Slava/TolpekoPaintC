using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    public class ElipsDC
    {
        public ElipsDC() { }

        public void DElips(Pen PenElip, Brush ElipBrut, Graphics graphics, PointF StartDraw, PointF EndDraw)
        {
            Rectangle EllipRect = new Rectangle((int)StartDraw.X, (int)StartDraw.Y, (int)(EndDraw.X-StartDraw.X), (int)(EndDraw.Y-StartDraw.Y));
            graphics.DrawEllipse(PenElip, EllipRect);
            graphics.FillEllipse(ElipBrut, EllipRect);
        }
    }
}
