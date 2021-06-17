using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;

namespace InterfesV
{
    public interface IFigurRemov
    {
        Point StartPoint { get; set; }
        Point EndPoint { get; set; }
        Color FillColor { get; set; }
        Graphics GrapDraw { get; set; }
        Pen DPen { get; set; }
        Color PenColor { get; set; }
        float PenWidth { get; set; }
        bool EndFigur { get; set; }
        IFigurRemov Clone();
        void Redraw();
        void Draw();
    }

    public interface IFigur
    {
        IFigurRemov Cread(Point Star, Point Endin, Graphics gr, Pen pen, Color FBrush);
    }

    [Serializable]
    public abstract class Figur : IFigurRemov
    {
        // protected Pen DPen;
        protected Pen DrPen;
        protected Point StartDraw, EndDraw;
        public bool EndManyLine = false;
        protected Graphics DrPcael;
        protected float penWidth = -1;
        protected Color penColor;
        bool EndDrawFigur = false;
        public Color FillColor { get; set; }
        public Point RemovePoint = new Point(-1, -1);
        public int Up;


        public Color FillDrawColor { get; set; }

        [JsonIgnore]
        public Graphics GrapDraw
        {
            get
            { return DrPcael; }
            set
            { DrPcael = value; }
        }

        public Figur(Point Start, Point End, Graphics gr, Pen p, Color FColor)
        {
            FillDrawColor = FColor;
            DPen = p;
            GrapDraw = gr;
            StartPoint = Start;
            EndPoint = End;
        }

        public float PenWidth
        {
            get
            { return penWidth; }
            set
            {
                if (value < 0)
                    return;
                penWidth = value;
                if (DPen != null)
                    DPen.Width = value;
            }
        }

        public Color PenColor
        {
            get
            { return penColor; }
            set
            {
                penColor = value;
                if (DPen != null)
                    DPen.Color = value;
            }

        }

        [JsonIgnore]
        public Pen DPen
        {
            get
            {
                if ((DrPen == null) && (PenWidth >= 0))
                {
                    DrPen = new Pen(PenColor, PenWidth);
                    DrPen.StartCap = DrPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                }
                return DrPen;
            }
            set
            {
                if (value != null)
                {
                    penWidth = value.Width;
                    penColor = value.Color;
                }
                DrPen = value;
            }

        }

        public virtual IFigurRemov Clone()
        {
            return null;

        }

        public virtual bool OnePointBack() { return false; }
        public virtual void Redraw()
        { }


        public virtual Point StartPoint
        {
            get { return StartDraw; }
            set { StartDraw = value; }
        }

        public virtual Point EndPoint
        {
            get { return EndDraw; }
            set { EndDraw = value; }
        }

        public virtual void Draw()
        {
            GrapDraw.DrawLine(DPen, StartDraw.X, StartDraw.Y, EndDraw.X, EndDraw.Y);
        }

        public bool EndFigur
        {
            get { return EndDrawFigur; }
            set { EndDrawFigur = value; }
        }
    }
}