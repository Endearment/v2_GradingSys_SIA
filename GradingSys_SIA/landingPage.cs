using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradingSys_SIA
{
    public partial class landingPage : Form
    {
        public string CadetId { get; set; }
        private string fullName;
        private Image profileImage;
        private int aptitudePoints;


        public landingPage(string fullName, Image profileImage, int aptitudePoints, string cadetId)
        {
            InitializeComponent();
            this.fullName = fullName;
            this.profileImage = profileImage;
            this.aptitudePoints = aptitudePoints;
            this.CadetId = cadetId;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void landingPage_Load(object sender, EventArgs e)
        {
            UpdateAptitudePointsProgress(CadetId);
            lbl_studName.Text = "Welcome, " + fullName;

            if (profileImage != null)
            {
                pictureBox2.Image = profileImage;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                //pictureBox2.Image = Properties.Resources.DefaultProfilePic;
            }
        }

        private void UpdateAptitudePointsProgress(string cadetId)
        {
            string connStr = "server=localhost;user=root;database=cis_db;password=;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT Aptitude_Points FROM aptitude WHERE Student_ID = @studentId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentId", cadetId);
                    object result = cmd.ExecuteScalar();
                    int points = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                    circularProgressBar1.Value = points;
                    circularProgressBar1.Text = points.ToString();
                }
            }
        }

    }
}

