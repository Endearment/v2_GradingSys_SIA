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
        private int targetAptitude = 0;
        private int targetFinalGrade = 0;


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
            CallUpdateFinalGradeProcedure(CadetId);
            UpdateLandPageProgress(CadetId);
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {

            UpdateNotifier.OnGradeDataUpdated -= () => UpdateLandPageProgress(CadetId);
            base.OnFormClosed(e);
        }

        private void UpdateLandPageProgress(string cadetId)
        {
            string connStr = "server=database-sia-cis.c7gskq208sgz.ap-southeast-2.rds.amazonaws.com;user=admin;database=cis_db;password=05152025CIASIA-admin; port=3306";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string aptitudeQuery = "SELECT Aptitude_Points FROM aptitude WHERE Student_ID = @studentId";
                using (MySqlCommand aptitudeCmd = new MySqlCommand(aptitudeQuery, conn))
                {
                    aptitudeCmd.Parameters.AddWithValue("@studentId", cadetId);
                    object result = aptitudeCmd.ExecuteScalar();
                    int points = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                    circularProgressBar1.Value = points;
                    circularProgressBar1.Text = points.ToString();
                }

                string gradeQuery = "SELECT Final_Grade FROM grade_management WHERE student_id = @studentId";
                using (MySqlCommand gradeCmd = new MySqlCommand(gradeQuery, conn))
                {
                    gradeCmd.Parameters.AddWithValue("@studentId", cadetId);
                    object gradeResult = gradeCmd.ExecuteScalar();
                    double finalGrade = gradeResult != DBNull.Value ? Convert.ToDouble(gradeResult) : 0;

                    circularProgressBar3.Value = (int)Math.Round(finalGrade);
                    circularProgressBar3.Text = $"{finalGrade:F2}%";
                }

                string examQuery = "SELECT Score FROM examination WHERE student_id = @studentId";
                using (MySqlCommand examCmd = new MySqlCommand(examQuery, conn))
                {
                    examCmd.Parameters.AddWithValue("@studentId", cadetId);
                    object scoreResult = examCmd.ExecuteScalar();
                    int examScore = scoreResult != DBNull.Value ? Convert.ToInt32(scoreResult) : 0;

                    int scaledScore = examScore * 2;
                    circularProgressBar4.Value = scaledScore;
                    circularProgressBar4.Text = $"{scaledScore}%";
                }

                int currentMonth = DateTime.Now.Month;
                string attendanceColumn = (currentMonth >= 1 && currentMonth <= 3) ? "midterm_attendance_grade" : "finals_attendance_grade";

                string attendanceQuery = $"SELECT {attendanceColumn} FROM grade_management WHERE student_id = @studentId";
                using (MySqlCommand attendanceCmd = new MySqlCommand(attendanceQuery, conn))
                {
                    attendanceCmd.Parameters.AddWithValue("@studentId", cadetId);
                    object attendanceResult = attendanceCmd.ExecuteScalar();

                    int rawAttendance = attendanceResult != DBNull.Value ? Convert.ToInt32(attendanceResult) : 0;
                    int maxAttendance = 30;
                    int attendancePercentage = (int)Math.Round((rawAttendance / (double)maxAttendance) * 100);

                    circularProgressBar2.Value = attendancePercentage;
                    circularProgressBar2.Text = $"{attendancePercentage}%";
                }


            }
        }


        private void CallUpdateFinalGradeProcedure(string studentId)
        {
            string connStr = "server=database-sia-cis.c7gskq208sgz.ap-southeast-2.rds.amazonaws.com;user=admin;password=05152025CIASIA-admin;database=cis_db;port=3306";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("UpdateFinalGrade", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sid", studentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}


