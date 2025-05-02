using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace GradingSys_SIA
{
    public partial class examPage : Form
    {
        private double aptitudePoints = 0.0;
        private double totalMidtermDays;
        private double totalFinalsDays;
        private double daysAbsentMidterm;
        private double daysAbsentFinals;
        private readonly DbConnection db;
        private string studentId;

        public examPage(string studentId)
        {
            this.studentId = studentId;
            db = new DbConnection();
            InitializeComponent();
        }

        private void examPage_Load(object sender, EventArgs e)
        {
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

                double attendanceMidtermRaw = totalMidtermDays > 0 ? ((totalMidtermDays - daysAbsentMidterm) / totalMidtermDays) * 100 : 0;
                double attendanceFinalsRaw = totalFinalsDays > 0 ? ((totalFinalsDays - daysAbsentFinals) / totalFinalsDays) * 100 : 0;

                double midtermAttendanceWeighted = attendanceMidtermRaw * 0.3;
                double finalsAttendanceWeighted = attendanceFinalsRaw * 0.3;

                double aptitudeRawPercentage = (aptitudePoints / 100) * 100;
                double aptitudeWeighted = aptitudeRawPercentage * 0.3;

                double midtermGrade = midtermExamWeighted + midtermAttendanceWeighted + aptitudeWeighted;
                double finalsGrade = finalsExamWeighted + finalsAttendanceWeighted + aptitudeWeighted;
                double overallGrade = (midtermGrade + finalsGrade) / 2;

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
                lblMidtermGrade2.Text = $"{midtermGrade:F2}%";
                lblFinalsGrade2.Text = $"{finalsGrade:F2}%";
                lblOverallGrade.Text = $"{overallGrade:F2}%";

                circularProgressBar3.Value = (int)Math.Round(overallGrade);
                circularProgressBar3.Text = $"{overallGrade:F2}%";
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
                lblMidtermGrade2.Text = "--";
                lblFinalsGrade2.Text = "--";
                circularProgressBar3.Value = 0;
                circularProgressBar3.Text = "--";
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
                            MessageBox.Show("No exam data found for the selected student.");
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
                string query = "SELECT total_days_midterm, total_days_finals, days_absent_midterm, days_absent_finals FROM attendance WHERE student_id = @studentId";

                using (var cmd = new MySqlCommand(query, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalMidtermDays = reader.GetDouble("total_days_midterm");
                            totalFinalsDays = reader.GetDouble("total_days_finals");
                            daysAbsentMidterm = reader.GetDouble("days_absent_midterm");
                            daysAbsentFinals = reader.GetDouble("days_absent_finals");

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
                        else
                        {
                            MessageBox.Show("No aptitude data found for the selected student.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading aptitude data: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }
    }
}
