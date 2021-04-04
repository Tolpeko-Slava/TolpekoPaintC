namespace Paint
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ClearButt = new System.Windows.Forms.Button();
            this.NumberUp = new System.Windows.Forms.NumericUpDown();
            this.FullUserButt = new System.Windows.Forms.Button();
            this.RectButt = new System.Windows.Forms.Button();
            this.NumInputUser = new System.Windows.Forms.NumericUpDown();
            this.LineButt = new System.Windows.Forms.Button();
            this.ColorButt = new System.Windows.Forms.Button();
            this.ManyLineButt = new System.Windows.Forms.Button();
            this.ManyRectButt = new System.Windows.Forms.Button();
            this.ElipsButt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumInputUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(5, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ClearButt, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.NumberUp, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.FullUserButt, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.RectButt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.NumInputUser, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.LineButt, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ColorButt, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.ManyLineButt, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ManyRectButt, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.ElipsButt, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(717, 36);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ClearButt
            // 
            this.ClearButt.Location = new System.Drawing.Point(635, 3);
            this.ClearButt.Name = "ClearButt";
            this.ClearButt.Size = new System.Drawing.Size(75, 23);
            this.ClearButt.TabIndex = 7;
            this.ClearButt.Text = "Очистка";
            this.ClearButt.UseVisualStyleBackColor = true;
            this.ClearButt.Click += new System.EventHandler(this.ClearButt_Click);
            // 
            // NumberUp
            // 
            this.NumberUp.Location = new System.Drawing.Point(342, 3);
            this.NumberUp.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumberUp.Name = "NumberUp";
            this.NumberUp.Size = new System.Drawing.Size(69, 20);
            this.NumberUp.TabIndex = 8;
            this.NumberUp.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumberUp.ValueChanged += new System.EventHandler(this.NumberUp_ValueChanged);
            // 
            // FullUserButt
            // 
            this.FullUserButt.Location = new System.Drawing.Point(560, 3);
            this.FullUserButt.Name = "FullUserButt";
            this.FullUserButt.Size = new System.Drawing.Size(69, 23);
            this.FullUserButt.TabIndex = 6;
            this.FullUserButt.Text = "Заливка";
            this.FullUserButt.UseVisualStyleBackColor = true;
            this.FullUserButt.Click += new System.EventHandler(this.FullUserButt_Click);
            // 
            // RectButt
            // 
            this.RectButt.Location = new System.Drawing.Point(54, 3);
            this.RectButt.Name = "RectButt";
            this.RectButt.Size = new System.Drawing.Size(67, 23);
            this.RectButt.TabIndex = 6;
            this.RectButt.Text = "Rect";
            this.RectButt.UseVisualStyleBackColor = true;
            this.RectButt.Click += new System.EventHandler(this.RectButt_Click);
            // 
            // NumInputUser
            // 
            this.NumInputUser.Location = new System.Drawing.Point(498, 3);
            this.NumInputUser.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NumInputUser.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumInputUser.Name = "NumInputUser";
            this.NumInputUser.Size = new System.Drawing.Size(56, 20);
            this.NumInputUser.TabIndex = 5;
            this.NumInputUser.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumInputUser.ValueChanged += new System.EventHandler(this.NumInputUser_ValueChanged);
            // 
            // LineButt
            // 
            this.LineButt.Location = new System.Drawing.Point(3, 3);
            this.LineButt.Name = "LineButt";
            this.LineButt.Size = new System.Drawing.Size(45, 23);
            this.LineButt.TabIndex = 4;
            this.LineButt.Text = "Line";
            this.LineButt.UseVisualStyleBackColor = true;
            this.LineButt.Click += new System.EventHandler(this.LineButt_Click);
            // 
            // ColorButt
            // 
            this.ColorButt.Location = new System.Drawing.Point(417, 3);
            this.ColorButt.Name = "ColorButt";
            this.ColorButt.Size = new System.Drawing.Size(75, 23);
            this.ColorButt.TabIndex = 4;
            this.ColorButt.Text = "Цвет";
            this.ColorButt.UseVisualStyleBackColor = true;
            this.ColorButt.Click += new System.EventHandler(this.ColorButt_Click);
            // 
            // ManyLineButt
            // 
            this.ManyLineButt.Location = new System.Drawing.Point(194, 3);
            this.ManyLineButt.Name = "ManyLineButt";
            this.ManyLineButt.Size = new System.Drawing.Size(61, 23);
            this.ManyLineButt.TabIndex = 7;
            this.ManyLineButt.Text = "ManyLine";
            this.ManyLineButt.UseVisualStyleBackColor = true;
            this.ManyLineButt.Click += new System.EventHandler(this.ManyLineButt_Click);
            // 
            // ManyRectButt
            // 
            this.ManyRectButt.Location = new System.Drawing.Point(261, 3);
            this.ManyRectButt.Name = "ManyRectButt";
            this.ManyRectButt.Size = new System.Drawing.Size(75, 23);
            this.ManyRectButt.TabIndex = 8;
            this.ManyRectButt.Text = "ManyRect";
            this.ManyRectButt.UseVisualStyleBackColor = true;
            this.ManyRectButt.Click += new System.EventHandler(this.ManyRectButt_Click);
            // 
            // ElipsButt
            // 
            this.ElipsButt.Location = new System.Drawing.Point(127, 3);
            this.ElipsButt.Name = "ElipsButt";
            this.ElipsButt.Size = new System.Drawing.Size(61, 23);
            this.ElipsButt.TabIndex = 5;
            this.ElipsButt.Text = "Elips";
            this.ElipsButt.UseVisualStyleBackColor = true;
            this.ElipsButt.Click += new System.EventHandler(this.ElipsButt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Paint";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumberUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumInputUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
       // private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.Button LineButt;
        private System.Windows.Forms.Button RectButt;
        private System.Windows.Forms.Button ManyLineButt;
        private System.Windows.Forms.Button ElipsButt;
        private System.Windows.Forms.Button ManyRectButt;
        private System.Windows.Forms.Button ColorButt;
        private System.Windows.Forms.NumericUpDown NumInputUser;
        private System.Windows.Forms.Button FullUserButt;
        private System.Windows.Forms.Button ClearButt;
        public System.Windows.Forms.NumericUpDown NumberUp;
    }
}

