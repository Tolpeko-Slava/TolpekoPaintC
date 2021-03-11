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
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen RedPed = new Pen(Color.Red,6);
            e.Graphics.DrawLine(RedPed, 250, 10, 500, 50);

            Rectangle RectRect = new Rectangle(50,50,250,250);
            SolidBrush BlueBrush = new SolidBrush(Color.Blue);
            e.Graphics.DrawRectangle(RedPed, RectRect);
            e.Graphics.FillRectangle(BlueBrush, RectRect);

            Rectangle EllipRect = new Rectangle(400, 100, 100, 100);
            e.Graphics.DrawEllipse(RedPed, EllipRect);
            e.Graphics.FillEllipse(BlueBrush, EllipRect);

            Point[] LinePointer =
            {
               new Point(500,100),
               new Point(560,125),
               new Point(600,125),
               new Point(620, 50),
            };
            int i = 1;
            while (i < 4)
            {
                e.Graphics.DrawLine(RedPed, LinePointer[i-1], LinePointer[i]);
                i = i + 1;
            }

            Point[] PolygPointer =
             {
               new Point(400,220),
               new Point(545,198),
               new Point(620,298),
               new Point(700,322),
               new Point(440,400),
             };

            SolidBrush YelBrush = new SolidBrush(Color.Yellow);
            e.Graphics.DrawPolygon(RedPed, PolygPointer);
            e.Graphics.FillPolygon(YelBrush, PolygPointer);

        }

    }

}
