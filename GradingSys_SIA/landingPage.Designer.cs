namespace GradingSys_SIA
{
    partial class landingPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(landingPage));
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            label11 = new Label();
            lbl_studName = new Label();
            label7 = new Label();
            circularProgressBar1 = new CircularProgressBar();
            panel3 = new Panel();
            label8 = new Label();
            panel4 = new Panel();
            circularProgressBar2 = new CircularProgressBar();
            panel5 = new Panel();
            label9 = new Label();
            circularProgressBar3 = new CircularProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(lbl_studName);
            panel2.Location = new Point(1, 0);
            panel2.Margin = new Padding(2, 2, 2, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(653, 145);
            panel2.TabIndex = 5;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(496, 14);
            pictureBox2.Margin = new Padding(2, 2, 2, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(132, 104);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(27, 76);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(426, 23);
            label11.TabIndex = 1;
            label11.Text = "See your most recent grades and performance updates.";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_studName
            // 
            lbl_studName.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_studName.Location = new Point(27, 38);
            lbl_studName.Margin = new Padding(2, 0, 2, 0);
            lbl_studName.Name = "lbl_studName";
            lbl_studName.Size = new Size(321, 38);
            lbl_studName.TabIndex = 0;
            lbl_studName.Text = "---------------------------------";
            lbl_studName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Image = (Image)resources.GetObject("label7.Image");
            label7.ImageAlign = ContentAlignment.MiddleRight;
            label7.Location = new Point(2, 6);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(206, 23);
            label7.TabIndex = 2;
            label7.Text = "Aptitude";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            label7.Click += label7_Click;
            // 
            // circularProgressBar1
            // 
            circularProgressBar1.BackColor = Color.White;
            circularProgressBar1.BarColor1 = Color.DarkBlue;
            circularProgressBar1.BarColor2 = Color.AliceBlue;
            circularProgressBar1.BarWidth = 14F;
            circularProgressBar1.Font = new Font("Segoe UI", 15F);
            circularProgressBar1.ForeColor = Color.Indigo;
            circularProgressBar1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            circularProgressBar1.LineColor = Color.Indigo;
            circularProgressBar1.LineWidth = 1;
            circularProgressBar1.Location = new Point(9, 61);
            circularProgressBar1.Margin = new Padding(2, 2, 2, 2);
            circularProgressBar1.Maximum = 100L;
            circularProgressBar1.MinimumSize = new Size(70, 60);
            circularProgressBar1.Name = "circularProgressBar1";
            circularProgressBar1.ProgressShape = CircularProgressBar._ProgressShape.Flat;
            circularProgressBar1.Size = new Size(192, 192);
            circularProgressBar1.TabIndex = 1;
            circularProgressBar1.Text = "57";
            circularProgressBar1.TextMode = CircularProgressBar._TextMode.Percentage;
            circularProgressBar1.Value = 57L;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label7);
            panel3.Controls.Add(circularProgressBar1);
            panel3.Location = new Point(8, 149);
            panel3.Margin = new Padding(2, 2, 2, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(210, 263);
            panel3.TabIndex = 6;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Image = (Image)resources.GetObject("label8.Image");
            label8.ImageAlign = ContentAlignment.MiddleRight;
            label8.Location = new Point(2, 6);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(206, 23);
            label8.TabIndex = 3;
            label8.Text = "Attendance";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(label8);
            panel4.Controls.Add(circularProgressBar2);
            panel4.Location = new Point(223, 149);
            panel4.Margin = new Padding(2, 2, 2, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(210, 263);
            panel4.TabIndex = 7;
            // 
            // circularProgressBar2
            // 
            circularProgressBar2.BackColor = Color.White;
            circularProgressBar2.BarColor1 = Color.DarkGreen;
            circularProgressBar2.BarColor2 = Color.LavenderBlush;
            circularProgressBar2.BarWidth = 14F;
            circularProgressBar2.Font = new Font("Segoe UI", 15F);
            circularProgressBar2.ForeColor = Color.Green;
            circularProgressBar2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            circularProgressBar2.LineColor = Color.LimeGreen;
            circularProgressBar2.LineWidth = 1;
            circularProgressBar2.Location = new Point(10, 61);
            circularProgressBar2.Margin = new Padding(2, 2, 2, 2);
            circularProgressBar2.Maximum = 100L;
            circularProgressBar2.MinimumSize = new Size(70, 60);
            circularProgressBar2.Name = "circularProgressBar2";
            circularProgressBar2.ProgressShape = CircularProgressBar._ProgressShape.Flat;
            circularProgressBar2.Size = new Size(192, 192);
            circularProgressBar2.TabIndex = 2;
            circularProgressBar2.Text = "57";
            circularProgressBar2.TextMode = CircularProgressBar._TextMode.Percentage;
            circularProgressBar2.Value = 57L;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(label9);
            panel5.Controls.Add(circularProgressBar3);
            panel5.Location = new Point(437, 149);
            panel5.Margin = new Padding(2, 2, 2, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(210, 263);
            panel5.TabIndex = 8;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Image = (Image)resources.GetObject("label9.Image");
            label9.ImageAlign = ContentAlignment.MiddleRight;
            label9.Location = new Point(2, 6);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(206, 23);
            label9.TabIndex = 4;
            label9.Text = "Exam";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // circularProgressBar3
            // 
            circularProgressBar3.BackColor = Color.White;
            circularProgressBar3.BarColor1 = Color.DarkOrange;
            circularProgressBar3.BarColor2 = Color.LavenderBlush;
            circularProgressBar3.BarWidth = 14F;
            circularProgressBar3.Font = new Font("Segoe UI", 15F);
            circularProgressBar3.ForeColor = Color.DarkOrange;
            circularProgressBar3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            circularProgressBar3.LineColor = Color.Tomato;
            circularProgressBar3.LineWidth = 1;
            circularProgressBar3.Location = new Point(10, 61);
            circularProgressBar3.Margin = new Padding(2, 2, 2, 2);
            circularProgressBar3.Maximum = 100L;
            circularProgressBar3.MinimumSize = new Size(70, 60);
            circularProgressBar3.Name = "circularProgressBar3";
            circularProgressBar3.ProgressShape = CircularProgressBar._ProgressShape.Flat;
            circularProgressBar3.Size = new Size(192, 192);
            circularProgressBar3.TabIndex = 3;
            circularProgressBar3.Text = "57";
            circularProgressBar3.TextMode = CircularProgressBar._TextMode.Percentage;
            circularProgressBar3.Value = 57L;
            // 
            // landingPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 247, 248);
            ClientSize = new Size(654, 419);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel5);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 2, 2, 2);
            Name = "landingPage";
            Text = "landingPage";
            Load += landingPage_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private PictureBox pictureBox2;
        private Label label11;
        private Label lbl_studName;
        private Label label7;
        private CircularProgressBar circularProgressBar1;
        private Panel panel3;
        private Label label8;
        private Panel panel4;
        private CircularProgressBar circularProgressBar2;
        private Panel panel5;
        private Label label9;
        private CircularProgressBar circularProgressBar3;
        private System.Windows.Forms.Timer timer1;
    }
}