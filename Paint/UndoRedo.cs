using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    public class UndoRedo
    {
        private Stack<IFigurRemov> Remov;
        private int n = 0;
        public int KolElem { get { return n; } }
        private Graphics gr;


        public UndoRedo(){
            Remov = new Stack<IFigurRemov>();
        }

        public IFigurRemov Element(int k)
        {
            if (k < n)
                return Remov.ElementAt<IFigurRemov>(k);
            else
                return null;
        }

        public bool Push(IFigurRemov F)
        {
            try
            {
         //       Remov.Push(F.Clone());
                n++;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IFigurRemov Pop()
        {
            if (n == 0)
                return null;
            else
            {
                IFigurRemov ret = Remov.Pop();
                n--;
                return ret;
            }
        }

        public bool DrawRemov(Graphics gr)
        {
            if (this.KolElem < 1)
                return false;
            IFigurRemov ObjRem;
            for (int k = this.KolElem - 1; k >= 0; k--)
            {
                ObjRem = this.Element(k);
                ObjRem.GrapDraw = gr;
               // ObjRem.Redraw();
            }
            return true;
        }

        public bool LastEnd()
        {
            if (Remov.Count <= 0)
                return false;
            bool res;
            res = Remov.ElementAt<IFigurRemov>(0).EndOfCurrentFigure;
            return res;

        }
    }
}
