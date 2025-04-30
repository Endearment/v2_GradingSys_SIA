namespace GradingSys_SIA
{
    partial class studLogin
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
            pictureBox1 = new PictureBox();
            label5 = new Label();
            label12 = new Label();
            label6 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(3, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(794, 145);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Gold;
            label5.Location = new Point(3, 172);
            label5.Name = "label5";
            label5.Size = new Size(794, 72);
            label5.TabIndex = 6;
            label5.Text = "QUEZON CITY UNIVERSITY";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(3, 244);
            label12.Name = "label12";
            label12.Size = new Size(794, 38);
            label12.TabIndex = 8;
            label12.Text = "___________________________________";
            label12.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(3, 228);
            label6.Name = "label6";
            label6.Size = new Size(794, 37);
            label6.TabIndex = 7;
            label6.Text = "Reserve Officer's Training Corps";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(218, 337);
            label1.Name = "label1";
            label1.Size = new Size(193, 37);
            label1.TabIndex = 9;
            label1.Text = "CADET NUMBER:";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(417, 337);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 10;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 50;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.ResizeForm = false;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(75, 83, 32);
            label2.ForeColor = Color.White;
            label2.Location = new Point(751, 9);
            label2.Name = "label2";
            label2.Size = new Size(37, 25);
            label2.TabIndex = 12;
            label2.Text = "✖";
            label2.Click += label2_Click;
            // 
            // studLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(75, 83, 32);
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(label12);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            ForeColor = Color.FromArgb(75, 83, 32);
            FormBorderStyle = FormBorderStyle.None;
            Name = "studLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "studLogin";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label5;
        private Label label12;
        private Label label6;
        private Label label1;
        private TextBox textBox1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Label label2;
    }
}