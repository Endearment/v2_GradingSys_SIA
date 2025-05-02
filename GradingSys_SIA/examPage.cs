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
    public partial class examPage : Form
    {
        private double aptitudePoints = 0.0;
        private double totalMidtermDays;
        private double totalFinalsDays;
        private double daysAbsent;
        private readonly DbConnection db;
        private string studentId;
        public examPage(string studentId)
        {
            this.studentId = studentId;
            db = new DbConnection();
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void examPage_Load(object sender, EventArgs e)
        {
            CalculateExamGrades();
            LoadExamScoresFromDatabase();
            LoadAttendanceData();
            LoadAptitudeData();

        }

        private void CalculateExamGrades()
        {
            try
            {
                double midtermScore = double.Parse(txtMidtermScore.Text);
                double midtermMax = double.Parse(txtMidtermMax.Text);
                double finalsScore = double.Parse(txtFinalsScore.Text);
                double finalsMax = double.Parse(txtFinalsMax.Text);

                double midtermExamRaw = (midtermScore / midtermMax) * 100;
                double finalsExamRaw = (finalsScore / finalsMax) * 100;
                double totalRawPercentage = (midtermExamRaw + finalsExamRaw) / 2;

                double midtermExamWeighted = midtermExamRaw * 0.4;
                double finalsExamWeighted = finalsExamRaw * 0.4;

                double attendanceMidtermRaw = ((totalMidtermDays - daysAbsent) / totalMidtermDays) * 100;
                double attendanceFinalsRaw = ((totalFinalsDays - daysAbsent) / totalFinalsDays) * 100;

                double midtermAttendanceWeighted = attendanceMidtermRaw * 0.3;
                double finalsAttendanceWeighted = attendanceFinalsRaw * 0.3;

                double aptitudeRawPercentage = (aptitudePoints / 100) * 100;
                double aptitudeWeighted = aptitudeRawPercentage * 0.3;

                double midtermGrade = midtermExamWeighted + midtermAttendanceWeighted + aptitudeWeighted;
                double finalsGrade = finalsExamWeighted + finalsAttendanceWeighted + aptitudeWeighted;
                double overallGrade = ((midtermGrade) + (finalsGrade)) / 2;

                lblMidtermRaw.Text = $"{midtermExamRaw:F2}%";
                lblFinalsRaw.Text = $"{finalsExamRaw:F2}%";
                lblTotalRaw.Text = $"{totalRawPercentage:F2}%";

                lblExamWeightedMidterm.Text = $"{midtermExamWeighted:F2}%";
                lblExamWeightedFinals.Text = $"{finalsExamWeighted:F2}%";

                lblaptitudeWeightedMidterm.Text = $"{aptitudeWeighted:F2}%";
                lblaptitudeWeightedFinals.Text = $"{aptitudeWeighted:F2}%";

                txtAttendanceMidterm.Text = $"{midtermAttendanceWeighted:F2}%";
                txtAttendanceFinals.Text = $"{finalsAttendanceWeighted:F2}%";

                lblMidtermGrade.Text = $"{midtermGrade:F2}%";
                lblFinalsGrade.Text = $"{finalsGrade:F2}%";
                lblOverallGrade.Text = $"{overallGrade:F2}%";


            }
            catch
            {
                lblMidtermRaw.Text = "--";
                lblFinalsRaw.Text = "--";
                lblTotalRaw.Text = "--";
                lblExamWeightedMidterm.Text = "--";
                lblExamWeightedFinals.Text = "--";
                txtAttendanceMidterm.Text = "--";
                txtAttendanceFinals.Text = "--";
                lblMidtermGrade.Text = "--";
                lblFinalsGrade.Text = "--";
                lblOverallGrade.Text = "--";
            }
        }

        private void LoadExamScoresFromDatabase()
        {
            try
            {
                db.OpenConnection();
                string query = "SELECT midterm_exam_score, finals_exam_score, Max_Score FROM examination WHERE student_id = @studentId LIMIT 1";

                using (var cmd = new MySqlCommand(query, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            double midtermScore = reader.GetDouble("midterm_exam_score");
                            double finalsScore = reader.GetDouble("finals_exam_score");
                            double maxScore = reader.GetDouble("Max_Score");

                            txtMidtermScore.Text = midtermScore.ToString();
                            txtMidtermMax.Text = maxScore.ToString();
                            txtFinalsScore.Text = finalsScore.ToString();
                            txtFinalsMax.Text = maxScore.ToString();

                            CalculateExamGrades();
                        }
                        else
                        {
                            MessageBox.Show("No data found for the selected student.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading exam data: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void LoadAttendanceData()
        {
            try
            {
                db.OpenConnection();
                string query = "SELECT total_days_midterm, total_days_finals, days_absent FROM attendance WHERE student_id = @studentId";

                using (var cmd = new MySqlCommand(query, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                           totalMidtermDays = reader.GetDouble("total_days_midterm");
                             totalFinalsDays = reader.GetDouble("total_days_finals");
                             daysAbsent = reader.GetDouble("days_absent");
                           
                             CalculateExamGrades(); 
                        }
                        else
                        {
                            MessageBox.Show("No attendance data found for the selected student.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance data: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void LoadAptitudeData()
        {
            try
            {
                db.OpenConnection();
                string query = "SELECT Aptitude_Points FROM aptitude WHERE student_id = @studentId"; 

                using (var cmd = new MySqlCommand(query, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);

                    using (var reader = cmd.ExecuteReader())
                    {                        
                            if (reader.Read())
                            {
                                aptitudePoints = reader.GetDouble("Aptitude_Points");

                                CalculateExamGrades();
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading aptitude data: " + ex.Message);
            }
        }




    }
}
