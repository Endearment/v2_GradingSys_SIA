using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace GradingSys_SIA
{
    public partial class sideBarPanel : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private string fullName;
        private Image profileImage;
        private string studentId;
        private int aptitudePoints;


        public sideBarPanel(string fullName, Image profileImage, string studentId, int aptitudePoints)
        {
            InitializeComponent();
            this.fullName = fullName;
            this.profileImage = profileImage;
            this.studentId = studentId;
            this.aptitudePoints = aptitudePoints;
            panel2.MouseDown += new MouseEventHandler(panel2_MouseDown);
            panel2.MouseMove += new MouseEventHandler(panel2_MouseMove);
            panel2.MouseUp += new MouseEventHandler(panel2_MouseUp);

            ExecuteUpdateFinalGradeProcedure(studentId);

            loadform(new landingPage(fullName, profileImage, aptitudePoints, studentId));
        }

        private void panel2_MouseDown(object? sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel2_MouseMove(object? sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void panel2_MouseUp(object? sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label13.Padding = new Padding(15, 0, 0, 0);
            label1.Padding = new Padding(50, 0, 0, 0);
            label2.Padding = new Padding(50, 0, 0, 0);
            label3.Padding = new Padding(50, 0, 0, 0);
            label4.Padding = new Padding(15, 0, 0, 0);

            label1.MouseEnter += labelFunction.Label_MouseEnter;
            label1.MouseLeave += labelFunction.Label_MouseLeave;
            label2.MouseEnter += labelFunction.Label_MouseEnter;
            label2.MouseLeave += labelFunction.Label_MouseLeave;
            label3.MouseEnter += labelFunction.Label_MouseEnter;
            label3.MouseLeave += labelFunction.Label_MouseLeave;
            label4.MouseEnter += labelFunction.Label_MouseEnter;
            label4.MouseLeave += labelFunction.Label_MouseLeave;
            label13.MouseEnter += labelFunction.Label_MouseEnter;
            label13.MouseLeave += labelFunction.Label_MouseLeave;
        }

        public void loadform(object form)
        {
            this.panel6.Controls.Clear();
            Form? fh = form as Form;
            if (fh != null)
            {
                fh.TopLevel = false;
                fh.FormBorderStyle = FormBorderStyle.None;
                fh.Dock = DockStyle.Fill;
                this.panel6.Controls.Add(fh);
                this.panel6.Tag = fh;
                fh.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            loadform(new aptitudePage(studentId));
        }

        private void label2_Click(object sender, EventArgs e)
        {
            loadform(new attendancePage());
        }

        private void label4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            loadform(new examPage(studentId));
        }

        private void label13_Click(object sender, EventArgs e)
        {
            loadform(new landingPage(fullName, profileImage, aptitudePoints, studentId));
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ExecuteUpdateFinalGradeProcedure(string studentId)
        {
            string connectionString = "server=database-sia-cis.c7gskq208sgz.ap-southeast-2.rds.amazonaws.com;user id=admin;password=05152025CIASIA-admin;database=cis_db;port=3306";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("UpdateFinalGrade", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sid", studentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}