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
            pictureBox1 = new PictureBox();
            label5 = new Label();
            label12 = new Label();
            label6 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            btn_login = new Button();
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
            label1.Location = new Point(219, 311);
            label1.Name = "label1";
            label1.Size = new Size(193, 37);
            label1.TabIndex = 9;
            label1.Text = "CADET NUMBER:";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(418, 311);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 10;
            // 
            // btn_login
            // 
            btn_login.BackColor = Color.White;
            btn_login.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_login.ForeColor = Color.Black;
            btn_login.Location = new Point(348, 377);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(112, 34);
            btn_login.TabIndex = 11;
            btn_login.Text = "LOGIN";
            btn_login.UseVisualStyleBackColor = false;
            btn_login.Click += btn_login_Click;
            // 
            // studLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(75, 83, 32);
            ClientSize = new Size(800, 450);
            Controls.Add(btn_login);
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
        private Button btn_login;
    }
}