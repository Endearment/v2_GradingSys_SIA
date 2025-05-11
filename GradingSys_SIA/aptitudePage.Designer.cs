namespace GradingSys_SIA
{
    partial class aptitudePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aptitudePage));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            label4 = new Label();
            panel3 = new Panel();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            label7 = new Label();
            panel4 = new Panel();
            circularProgressBar2 = new CircularProgressBar();
            label15 = new Label();
            label35 = new Label();
            label14 = new Label();
            label9 = new Label();
            label10 = new Label();
            label8 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-1, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(657, 77);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(13, 32);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(325, 19);
            label2.TabIndex = 1;
            label2.Text = "Demerits system based on appearance and conduct";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(10, 5);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(219, 30);
            label1.TabIndex = 0;
            label1.Text = "Aptitude Evaluation";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(236, 81);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(413, 167);
            panel2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(2, 7);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 3;
            label3.Text = "Demerit System";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.Location = new Point(2, 29);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(406, 130);
            label4.TabIndex = 4;
            label4.Text = resources.GetString("label4.Text");
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label6);
            panel3.Controls.Add(dataGridView1);
            panel3.Location = new Point(4, 81);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(229, 334);
            panel3.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(5, 7);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(105, 15);
            label6.TabIndex = 6;
            label6.Text = "Current Demerits";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(8, 29);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(218, 301);
            dataGridView1.TabIndex = 7;
            dataGridView1.Scroll += dataGridView1_Scroll;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Window;
            label5.Location = new Point(158, 56);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(25, 15);
            label5.TabIndex = 5;
            label5.Text = "100";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(2, 10);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(91, 15);
            label7.TabIndex = 7;
            label7.Text = "Aptitude Score";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(circularProgressBar2);
            panel4.Controls.Add(label15);
            panel4.Controls.Add(label35);
            panel4.Controls.Add(label14);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(label7);
            panel4.Location = new Point(236, 251);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(413, 165);
            panel4.TabIndex = 7;
            // 
            // circularProgressBar2
            // 
            circularProgressBar2.BackColor = Color.White;
            circularProgressBar2.BarColor1 = Color.DarkBlue;
            circularProgressBar2.BarColor2 = Color.AliceBlue;
            circularProgressBar2.BarWidth = 14F;
            circularProgressBar2.Font = new Font("Segoe UI", 15F);
            circularProgressBar2.ForeColor = Color.Indigo;
            circularProgressBar2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            circularProgressBar2.LineColor = Color.Indigo;
            circularProgressBar2.LineWidth = 1;
            circularProgressBar2.Location = new Point(228, 10);
            circularProgressBar2.Margin = new Padding(2);
            circularProgressBar2.Maximum = 100L;
            circularProgressBar2.MinimumSize = new Size(70, 60);
            circularProgressBar2.Name = "circularProgressBar2";
            circularProgressBar2.ProgressShape = CircularProgressBar._ProgressShape.Flat;
            circularProgressBar2.Size = new Size(165, 165);
            circularProgressBar2.TabIndex = 45;
            circularProgressBar2.Text = "57";
            circularProgressBar2.TextMode = CircularProgressBar._TextMode.Percentage;
            circularProgressBar2.Value = 57L;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Gainsboro;
            label15.Location = new Point(165, 119);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(31, 15);
            label15.TabIndex = 44;
            label15.Text = "        ";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.BackColor = Color.Gainsboro;
            label35.Location = new Point(165, 81);
            label35.Margin = new Padding(2, 0, 2, 0);
            label35.Name = "label35";
            label35.Size = new Size(31, 15);
            label35.TabIndex = 43;
            label35.Text = "        ";
            label35.Click += label35_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(10, 96);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(202, 15);
            label14.TabIndex = 13;
            label14.Text = "_______________________________________";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.Location = new Point(10, 81);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(101, 15);
            label9.TabIndex = 7;
            label9.Text = "Demerits Applied:";
            label9.Click += label9_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label10.Location = new Point(10, 119);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(66, 15);
            label10.TabIndex = 9;
            label10.Text = "Final Score:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.Location = new Point(10, 56);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(81, 15);
            label8.TabIndex = 6;
            label8.Text = "Total Possible:";
            // 
            // aptitudePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 419);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "aptitudePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "aptitude";
            Load += aptitudePage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label4;
        private Panel panel2;
        private Label label3;
        private Panel panel3;
        private Label label5;
        private Label label6;
        private Panel panel4;
        private Label label8;
        private Label label7;
        private Label label14;
        private Label label9;
        private Label label10;
        private Label label15;
        private Label label35;
        private CircularProgressBar circularProgressBar2;
        private DataGridView dataGridView1;
    }
}