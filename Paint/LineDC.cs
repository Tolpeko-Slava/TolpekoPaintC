using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    public class LineDC
    {
        public LineDC() { }

        public  void DLine(Pen PedLin, Graphics graphics, PointF StartDraw, PointF EndDraw) 
        {
            graphics.DrawLine(PedLin, StartDraw.X, StartDraw.Y, EndDraw.X, EndDraw.Y);
        }
    }
}
