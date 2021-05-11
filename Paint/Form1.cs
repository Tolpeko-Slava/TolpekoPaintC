using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime;
using System.IO;

namespace Paint
{
    public partial class Form1 : Form
    {
        UndoRedo FigureBack = new UndoRedo();
        //  IFigur CurrentFigure = null;
        private Color MyColor = Color.Black;
        private Color MyFullColor = Color.White;
        private float MyWenPen { get; set; }
        private Pen MyPen = new Pen(Color.Black, 1);
        private Point StartP, EndP=new Point (-1,-1);
        Bitmap MainPicture = new Bitmap(1000, 1000), TemporaryImage = new Bitmap(1000, 1000);
        LinkedList<IFigur> Creators = new LinkedList<IFigur>();
       // IFigurRemov CurrentFigure = null;
        private Graphics Graph;
        bool IsClicked;
        bool ClickManyRect=false;
        private int Up { get; set; }


        IRemov Last;


        // IFigur CreadFigur;
        Figur Figura;

        public Form1()
        {
            InitializeComponent();

            LineCread lineCreding = new LineCread { };
            Figura = lineCreding.Cread(StartP, EndP, pictureBox1.CreateGraphics(), MyPen, MyFullColor);

            //ManyRectCraed ManyRectCreading = new ManyRectCraed { };
            //FiguraRigth = ManyRectCreading.Cread(StartP, EndP, pictureBox1.CreateGraphics(), MyPen, MyFullColor);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics grap = e.Graphics;
            grap.ScaleTransform(1.0f,1.0f);
            grap.TranslateTransform(0, 0);
        }

        protected void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsClicked = true;
            StartP.X = e.X;
            StartP.Y = e.Y;
            Figura.StartPoint = StartP;
        }

        protected void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsClicked)
            {
                EndP.X = e.X;
                EndP.Y = e.Y;
                Figura.EndPoint = EndP;
                //pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsClicked = false;
            if (e.Button == MouseButtons.Right)
                Figura.EndManyLine = true;
            Figura.Draw();
        }

        private void LineButt_Click(object sender, EventArgs e)
        {
            LineCread lineCreding = new LineCread { };
            Figura = lineCreding.Cread(StartP, EndP, pictureBox1.CreateGraphics(), MyPen, MyFullColor);
        }

        private void RectButt_Click(object sender, EventArgs e)
        {
            RectCread RectCreading = new RectCread { };
            Figura = RectCreading.Cread(StartP, EndP, pictureBox1.CreateGraphics(), MyPen, MyFullColor);
        }

        private void ElipsButt_Click(object sender, EventArgs e)
        {
            ElipsCread ElipsCreading = new ElipsCread { };
            Figura = ElipsCreading.Cread(StartP, EndP, pictureBox1.CreateGraphics(), MyPen, MyFullColor);
        }

        private void ManyLineButt_Click(object sender, EventArgs e)
        {
            ManyLineCread ManyLineCreding = new ManyLineCread { };
            Figura = ManyLineCreding.Cread(StartP, EndP, pictureBox1.CreateGraphics(), MyPen, MyFullColor);
        }

        private void ManyRectButt_Click(object sender, EventArgs e)
        {
            ManyRectCraed ManyRectCreading = new ManyRectCraed { };
            Figura = ManyRectCreading.Cread(StartP, EndP, pictureBox1.CreateGraphics(), MyPen, MyFullColor);
            NumberUp.Value = 3;
            ClickManyRect=true;
        }

        private void ButtUseRect_Click(object sender, EventArgs e)
        {
            UserManyRectCread UserManyRectCreding = new UserManyRectCread { };
            Figura = UserManyRectCreding.Cread(StartP, EndP, pictureBox1.CreateGraphics(), MyPen, MyFullColor);
        }



        private void ColorButt_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.FullOpen = true;
            if (MyDialog.ShowDialog() == DialogResult.Cancel)
                return;
            MyColor = MyDialog.Color;
            MyPen= new Pen(MyColor, MyWenPen);
            Figura.DPen = MyPen;
        }

        private void NumInputUser_ValueChanged(object sender, EventArgs e)
        {
            MyWenPen = (float)NumInputUser.Value;
            MyPen = new Pen(MyColor, MyWenPen);
            Figura.DPen = MyPen;
        }

        private void ClearButt_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void NumberUp_ValueChanged(object sender, EventArgs e)
        {
            if(ClickManyRect)
            {
                (Figura as ManyRectDC).Kol = (int)NumberUp.Value;
                //ClickManyRect = false;
            }  
            //ManyRectCraed ManyRectCreading = new ManyRectCraed { };
            //Figura = ManyRectCreading.Cread(StartP, EndP, pictureBox1.CreateGraphics(), MyPen, MyFullColor);
        }

        private void ButtSave_Click(object sender, EventArgs e)
        {
            /*  SaveFileDialog SavFal = new SaveFileDialog();
              SavFal.Title = "Сохранить картинку как...";
              SavFal.OverwritePrompt = true;
              SavFal.CheckPathExists = true;
              SavFal.Filter = "Image Files (*.BMP)|*.BMP|Image Files (*.JPG)|*.JPG|Image Files (*.GIF)|*.GIF|" +
                  "Image Files (*.PNG)|*.PNG|ALL files(*.*)|*.*";
              SavFal.ShowHelp = true;

              if (SavFal.ShowDialog() == DialogResult.OK)
              {
                  try
                  {
                      pictureBox1.Image.Save("SaveFal.FileName");
                  }
                  catch
                  {
                      MessageBox.Show("Cannot create output file!");
                  }
              }*/
        }

        private void ButtLoad_Click(object sender, EventArgs e)
        {

        }

        private void ButtRemove_Click(object sender, EventArgs e)
        {






      /*      int N = FigureBack.KolElem;
            if (N <= 0)
                return;
            if (FigureBack == null)
                FigureBack = new UndoRedo();


            IFigurRemov Last = FigureBack.Element(0);

            Last.EndOfCurrentFigure = true;
            FigureBack.Push(Last);
            FigureBack.Pop();


            ButtMove.Enabled = true;

            Graph = Graphics.FromImage(MainPicture);
            Graph.Clear(pictureBox1.BackColor);

            FigureBack.DrawRemov(Graph);


            pictureBox1.Image = MainPicture;

            if (FigureBack.KolElem <= 0)
                ButtRemove.Enabled = false;

            */

            //IFigur CurrentCreator = Creators.ElementAt<IFigur>(1);
         //   CurrentFigure = CurrentCreator.Cread(StartP, EndP, pictureBox1.CreateGraphics(), MyPen, MyFullColor);
          //  -1, -1, gr, pen, FillColorPanel.BackColor
          //  Figura = ManyLineCreding.Cread(StartP, EndP, pictureBox1.CreateGraphics(), MyPen, MyFullColor);
        }

        private void ButtMove_Click(object sender, EventArgs e)
        {
          /*  IFigurRemov tmp = FigureBack.Pop();
            gr = Graphics.FromImage(MainPicture);
            tmp.DrawPanel = gr;
            tmp.Redraw();
            FigureBack.Push(tmp);
            UndoButton.Enabled = true;
            pictureBox1.Image = MainPicture;
            gr.Dispose();
            if (FigureBack.Count == 0)
            {
                RedoButton.Enabled = false;
            }*/
        }

        private void FullUserButt_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.FullOpen = true;
            if (MyDialog.ShowDialog() == DialogResult.Cancel)
                return;
            MyFullColor = MyDialog.Color;
            Figura.FillDrawColor = MyFullColor;
        }
    }

}
