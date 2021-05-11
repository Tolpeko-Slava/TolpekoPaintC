using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    public interface IFigurRemov
    {
        Point StartPoint { get; set; }
        Point EndPoint { get; set; }
        Color FillColor { get; set; }
        Graphics GrapDraw { get; set; }
        Pen DPen { get; set; }
      //  Color PenColor { get; set; }
      //  float PenWidth { get; set; }
       // bool EndOfCurrentFigure { get; set; }
       // IFigurRemov Clone();
       // void Redraw();
    }

    public interface IRemov
    {
        IFigurRemov Clone();
    }
}
