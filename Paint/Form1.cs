using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        private Color MyColor = Color.Black;
        private Color MyFullColor = Color.White;
        private float MyWenPen { get; set; }
        private Point StartP, EndP;
        //private Pen DrawPed;
        // private SolidBrush DrawBrush;

        public Form1()
        {
            InitializeComponent();
            //PenAndBrush();
        }

        // private void PenAndBrush()
        // {
        //     Pen Ped = new Pen(MyColor, MyWenPen);
        //     SolidBrush Brush = new SolidBrush(MyFullColor);
        //     DrawPed = Ped;
        //     DrawBrush = Brush;
        // }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics grap = e.Graphics;
            grap.ScaleTransform(1.0f,1.0f);
            grap.TranslateTransform(0, 0);
        }

        private void LineButt_Click(object sender, EventArgs e)
        {
            StartP.X = 100;
            StartP.Y = 50;
            EndP.X = 500;
            EndP.Y = 300;
            Pen Ped = new Pen(MyColor, MyWenPen);
            Figur figura = new Figur(pictureBox1.CreateGraphics(), Ped, MyFullColor,StartP,EndP);
            LineDC Line = new LineDC(pictureBox1.CreateGraphics(), Ped, MyFullColor);
            Line.Draw();
        }

        private void RectButt_Click(object sender, EventArgs e)
        {
            Pen Ped = new Pen(MyColor, MyWenPen);
            RectDC Rect = new RectDC(pictureBox1.CreateGraphics(), Ped, MyFullColor);
            Rect.Draw();
        }

        private void ElipsButt_Click(object sender, EventArgs e)
        {
            Pen Ped = new Pen(MyColor, MyWenPen);
            ElipsDC Elip = new ElipsDC(pictureBox1.CreateGraphics(), Ped, MyFullColor);
            Elip.Draw();
        }

        private void ManyLineButt_Click(object sender, EventArgs e)
        {
            Pen Ped = new Pen(MyColor, MyWenPen);
            LineDC Line = new LineDC(pictureBox1.CreateGraphics(), Ped, MyFullColor);
            StartP.X = 50;
            StartP.Y = 50;
            Figura.StartPoint = StartP;
            EndP.X = 500;
            EndP.Y = 100;
            Figura.EndPoint = EndP;
            int i = 1;
            while (i < 3)
            {
                Line.Draw();
                StartP.X = 500;
                StartP.Y = 100;
                EndP.X = 700;
                EndP.Y = 300;
                Figura.StartPoint = StartP;
                Figura.EndPoint = EndP;
                i = i + 1;
            }
        }

        private void ManyRectButt_Click(object sender, EventArgs e)
        {
            Pen Ped = new Pen(MyColor, MyWenPen);
            ManyRectDC ManRec = new ManyRectDC(pictureBox1.CreateGraphics(), Ped, MyFullColor);
            ManRec.Draw();
        }



        private void ColorButt_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.FullOpen = true;
            if (MyDialog.ShowDialog() == DialogResult.Cancel)
                return;
            MyColor = MyDialog.Color;
        }

        private void NumInputUser_ValueChanged(object sender, EventArgs e)
        {
            MyWenPen = (float)NumInputUser.Value;
        }

        private void ClearButt_Click(object sender, EventArgs e)
        {
                
        }

        private void FullUserButt_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.FullOpen = true;
            if (MyDialog.ShowDialog() == DialogResult.Cancel)
                return;
            MyFullColor = MyDialog.Color;
        }
    }

}
