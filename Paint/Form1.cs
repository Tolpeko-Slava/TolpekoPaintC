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
        private PointF StartPoint, EndPoint;
        private float MyWenPen { get; set; }
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

    

        private void LineButt_Click(object sender, EventArgs e)
        {
            LineDC lin = new LineDC();
            Pen Ped = new Pen(MyColor, MyWenPen);
            StartPoint.X = 100;
            StartPoint.Y = 200;
            EndPoint.X = 500;
            EndPoint.Y = 100;
            lin.DLine(Ped, pictureBox1.CreateGraphics(), StartPoint,EndPoint);
        }

        private void RectButt_Click(object sender, EventArgs e)
        {
            RectDC Rec = new RectDC();
            Pen Ped = new Pen(MyColor, MyWenPen);
            SolidBrush Brush = new SolidBrush(MyFullColor);
            StartPoint.X = 100;
            StartPoint.Y = 200;
            EndPoint.X = 500;
            EndPoint.Y = 700;
            Rec.DRec(Ped, Brush, pictureBox1.CreateGraphics(), StartPoint, EndPoint);
        }

        private void ElipsButt_Click(object sender, EventArgs e)
        {
            ElipsDC Elip = new ElipsDC();
            Pen Ped = new Pen(MyColor, MyWenPen);
            SolidBrush Brush = new SolidBrush(MyFullColor);
            StartPoint.X = 400;
            StartPoint.Y = 200;
            EndPoint.X = 700;
            EndPoint.Y = 300;
            Elip.DElips(Ped, Brush, pictureBox1.CreateGraphics(), StartPoint, EndPoint);
        }

        private void ManyLineButt_Click(object sender, EventArgs e)
        {
            LineDC lin = new LineDC();
            Pen Ped = new Pen(MyColor, MyWenPen);

            StartPoint.X = 50;
            StartPoint.Y = 50;
            EndPoint.X = 500;
            EndPoint.Y = 100;
            int i = 1;
            while (i < 3)
            {
                lin.DLine(Ped, pictureBox1.CreateGraphics(), StartPoint, EndPoint);
                StartPoint.X = 500;
                StartPoint.Y = 100;
                EndPoint.X = 700;
                EndPoint.Y = 300;
                i = i + 1;
            }
        }

        private void ManyRectButt_Click(object sender, EventArgs e)
        {
            Pen Ped = new Pen(MyColor, MyWenPen);
            SolidBrush Brush = new SolidBrush(MyFullColor);
            ManyRectDC ManRec = new ManyRectDC();
            StartPoint.X = 400;
            StartPoint.Y = 500;
            EndPoint.X = 700;
            EndPoint.Y = 700;
            ManRec.DManyRect(Ped, Brush, pictureBox1.CreateGraphics(), StartPoint, EndPoint);

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
