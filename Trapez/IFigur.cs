using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Trapez
{
    public interface IFigur
    {
        IFigurRemov Cread(Point Star, Point Endin, Graphics gr, Pen pen, Color FBrush);
    }
}
