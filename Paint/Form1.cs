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
using Newtonsoft.Json;
using InterfesV;

namespace Paint
{
    public partial class Form1 : Form
    {
        UndoRedo FigureBack = new UndoRedo(), FigureGo = null;
        private Color MyColor = Color.Black;
        private Color MyFullColor = Color.White;
        private float MyWenPen { get; set; }
        private Pen MyPen = new Pen(Color.Black, 1);
        private Point StartP, EndP = new Point(-1, -1);
        Graphics Graph;
        Bitmap MainPicture = new Bitmap(730, 500);
        bool IsClicked;
        bool ClickManyRect=false;
        private Point Pounters = new Point(-1, -1);
        IFigurRemov Figura;

        public Form1()
        {
            InitializeComponent();

            ButtRemove.Enabled = false;
            ButtMove.Enabled = false;

            LineCread lineCreding = new LineCread { };
            Figura = lineCreding.Cread(StartP, EndP, pictureBox1.CreateGraphics(), MyPen, MyFullColor);
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
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsClicked = false;
            if (e.Button == MouseButtons.Right)
                Figura.EndFigur = true;
            Figura.Draw();

          

            if (FigureBack.KolElem < 1)
            {
                FigureBack.Push(Figura);
                ButtRemove.Enabled = true;
            }
            else
            {
                if (FigureBack.CanDraw())
                {
                    FigureBack.Push(Figura);
                }
                else
                {
                    FigureBack.Pop();
                    FigureBack.Push(Figura);
                }
            }
            if (Figura.EndFigur == true)
            {
                Figura.EndPoint = Pounters;
            }
            ButtRemove.Enabled = true;
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
            ButtRemove.Enabled = false;
            ButtMove.Enabled = false;
            FigureBack = new UndoRedo();
        }

        private void NumberUp_ValueChanged(object sender, EventArgs e)
        {
            if(ClickManyRect)
            {
                (Figura as ManyRectDC).Kol = (int)NumberUp.Value;
                
            }  
        }

        private void ButtSave_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                FileStream F = File.Open(path, FileMode.Create);
                try
                {
                    StreamWriter st = new StreamWriter(F);
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.TypeNameHandling = TypeNameHandling.All;
                    for (int i = FigureBack.KolElem - 1; i >= 0; i--)
                    {
                        IFigurRemov Tmp = FigureBack.Element(i);
                        try
                        {
                            string json = JsonConvert.SerializeObject(Tmp, Tmp.GetType(), settings);
                            st.WriteLine(json);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            break;
                        }
                    }
                    st.Close();
                }
                finally
                {
                    F.Close();
                }
            }
        }

        private void ButtLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                FileStream F = File.Open(path, FileMode.Open);
                if (F == null)
                {
                    MessageBox.Show("Cannot open this file!");
                    return;
                }
                try
                {
                    ClearButt_Click(null, null);

                    StreamReader st = new StreamReader(F);
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.TypeNameHandling = TypeNameHandling.All;
                    IFigurRemov Tmp;
                    string json = st.ReadLine();
                    int i = 0;
                    while (json != null)
                    {
                        try
                        {
                            Tmp = (IFigurRemov)JsonConvert.DeserializeObject(json, settings);
                            FigureBack.Push(Tmp);
                        }
                        catch
                        {
                            string type = json.Substring(json.IndexOf(':'), json.IndexOf(','));
                            MessageBox.Show("Error on line " + i.ToString() + ". Cannot read this Figure:" + type);

                        }

                        i++;
                        json = st.ReadLine();
                    }
                    Graph = Graphics.FromImage(MainPicture);
                    Graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    FigureBack.DrawRemov(Graph);
                    pictureBox1.Image = MainPicture;
                    st.Close();
                    ButtRemove.Enabled = true;
                }
                finally
                {
                    F.Close();
                }
            }
        }


        private void ButtRemove_Click(object sender, EventArgs e)
        {
            int N = FigureBack.KolElem;
            if (N <= 0)
                return;
            if (FigureGo == null)
                FigureGo = new UndoRedo();
            IFigurRemov Last = FigureBack.Element(0);
            FigureGo.Push(Last);
            FigureBack.Pop();
            ButtMove.Enabled = true;
            Graph = Graphics.FromImage(MainPicture);
            Graph.Clear(pictureBox1.BackColor);
            FigureBack.DrawRemov(Graph);
            pictureBox1.Image = MainPicture;
            if (FigureBack.KolElem <= 0)
                ButtRemove.Enabled = false;
        }


        private void ButtMove_Click(object sender, EventArgs e)
        {
            IFigurRemov Mov = FigureGo.Pop();
            Graph = Graphics.FromImage(MainPicture);
            Mov.GrapDraw = Graph;
            Mov.Redraw();
            FigureBack.Push(Mov);
            ButtRemove.Enabled = true;
            pictureBox1.Image = MainPicture;
            Graph.Dispose();
            if (FigureGo.KolElem == 0)
            {
                ButtMove.Enabled = false;
            }
        }

        private void FullUserButt_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.FullOpen = true;
            if (MyDialog.ShowDialog() == DialogResult.Cancel)
                return;
            MyFullColor = MyDialog.Color;
            Figura.FillColor = MyFullColor;
        }



        public static List<Type> pluginsList = new List<Type>();

        //Плагины 
        private void ButtAddPlagin_Click(object sender, EventArgs e)
        {
            ToolStripDropDown dropDown = new ToolStripDropDown();

            toolStrip.DropDown = dropDown;
            toolStrip.DropDownDirection = ToolStripDropDownDirection.Right;
            toolStrip.ShowDropDownArrow = true;

            var dlgFileOpen = new OpenFileDialog();
            dlgFileOpen.Filter = @"File dll (*.dll)|*.dll";

            if (dlgFileOpen.ShowDialog() == DialogResult.OK)
            {
                string filename = dlgFileOpen.FileName;

                Assembly assembly = Assembly.LoadFrom(filename);
                Type[] t = assembly.GetTypes();

              //  Object instance = Activator.CreateInstance(t[1]);
         //       Type types = assembly.GetType();
                string str = t[1].FullName.ToString();
                string[] MasStr = str.Split('.');


                ToolStripButton buttPlagin = new ToolStripButton();
                buttPlagin.Text = MasStr[0];
                buttPlagin.ForeColor = Color.Blue;
                pluginsList.Add(t[1]);
                buttPlagin.Click += new EventHandler(ButtonDrawPlag);
                toolStrip.DropDown.Items.Add(buttPlagin);
            }
        }


        private void ButtonDrawPlag(object sender, EventArgs e)
        {
            int SelectIndex = 0;
            for(int i =0; i< toolStrip.DropDownItems.Count; i++)
            {
                if(toolStrip.DropDownItems[i].Selected)
                {
                    SelectIndex = i;
                    break;
                }
            }

            Type FObject = pluginsList.ElementAt(SelectIndex);

            object[] Parametrer = new object[] { StartP, EndP, pictureBox1.CreateGraphics(), MyPen, MyFullColor };
            Object instance = Activator.CreateInstance(FObject);
            MethodInfo CreadPlag = FObject.GetMethod("Cread");

            Figura = (IFigurRemov)CreadPlag.Invoke(instance, Parametrer);


           // Figura = pluginsList.ElementAt(SelectIndex);
        }

    }

}