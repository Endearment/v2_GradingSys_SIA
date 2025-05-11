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
            private bool isExamLoaded = false;
            private bool isAttendanceLoaded = false;
            private bool isAptitudeLoaded = false;

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

                ExecuteUpdateFinalGradeProcedure();
        }

        private void TryExecuteStoredProcedure()
        {
            if (isExamLoaded && isAttendanceLoaded && isAptitudeLoaded)
            {
                ExecuteUpdateFinalGradeProcedure();
            }
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
                double overallGrade = finalsExamWeighted > 0 ? (midtermGrade + finalsGrade) / 2 : midtermGrade;

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
                lblFinalsGrade2.Text = finalsExamWeighted > 0 ? $"{finalsGrade:F2}%" : "";
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
                lblFinalsGrade2.Text = "";
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

                            isExamLoaded = true;
                            TryExecuteStoredProcedure();
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

                                
                            isAttendanceLoaded = true;
                            TryExecuteStoredProcedure();
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

        private void SaveOrUpdateFinalGradeFromReader(MySqlDataReader reader)
        {
            string connectionString = "server=database-sia-cis.c7gskq208sgz.ap-southeast-2.rds.amazonaws.com;user id=admin;password=05152025CIASIA-admin;database=cis_db;port=3306";

            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT midterm_aptitude_grade FROM grade_management WHERE student_id = @studentId";
                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@studentId", studentId);
                        var result = checkCmd.ExecuteScalar();


                        if (result != null && result != DBNull.Value && Convert.ToDouble(result) > 0)
                        {
                            return;
                        }
                    }

                    string sql = @"INSERT INTO grade_management (student_id, midterm_exam, finals_exam, midterm_attendance_grade, 
                finals_attendance_grade, midterm_aptitude_grade, finals_aptitude_grade, Final_Grade)
               VALUES (@studentId, @midterm_exam, @finals_exam, @midterm_attendance, @finals_attendance, 
                       @midterm_aptitude_grade, @finals_aptitude_grade, @final_grade)
               ON DUPLICATE KEY UPDATE 
                    midterm_exam = VALUES(midterm_exam),
                    finals_exam = VALUES(finals_exam),
                    midterm_attendance_grade = VALUES(midterm_attendance_grade),
                    finals_attendance_grade = VALUES(finals_attendance_grade),
                    midterm_aptitude_grade = CASE WHEN midterm_aptitude_grade > 0 THEN midterm_aptitude_grade ELSE VALUES(midterm_aptitude_grade) END,
                    finals_aptitude_grade = CASE WHEN finals_aptitude_grade > 0 THEN finals_aptitude_grade ELSE VALUES(finals_aptitude_grade) END,
                    Final_Grade = VALUES(Final_Grade)";

                    MessageBox.Show($"Executing query: {sql}");

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@midterm_exam", reader.GetDouble("midterm_exam_weighted"));
                        cmd.Parameters.AddWithValue("@finals_exam", reader.GetDouble("finals_exam_weighted"));
                        cmd.Parameters.AddWithValue("@midterm_attendance", reader.GetDouble("midterm_attendance_weighted"));
                        cmd.Parameters.AddWithValue("@finals_attendance", reader.GetDouble("finals_attendance_weighted"));
                        cmd.Parameters.AddWithValue("@midterm_aptitude_grade", reader.GetDouble("midterm_aptitude_weighted"));
                        cmd.Parameters.AddWithValue("@finals_aptitude_grade", reader.GetDouble("finals_aptitude_weighted"));
                        cmd.Parameters.AddWithValue("@final_grade", reader.GetDouble("final_grade"));

                        int rowsAffected = cmd.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Grade saved/updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No rows were affected. Please check the data.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving grade details: " + ex.Message);
                }
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
                            
                            isAptitudeLoaded = true;
                            TryExecuteStoredProcedure();
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

        private void ExecuteUpdateFinalGradeProcedure()
        {
            string connectionString = "server=database-sia-cis.c7gskq208sgz.ap-southeast-2.rds.amazonaws.com;user id=admin;password=05152025CIASIA-admin;database=cis_db;port=3306";

            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("UpdateFinalGrade", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@sid", studentId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                double finalGrade = reader.GetDouble("final_grade");

                                lblMidtermRaw.Text = $"{reader.GetDouble("midterm_raw_percentage"):F2}%";
                                lblFinalsRaw.Text = $"{reader.GetDouble("finals_raw_percentage"):F2}%";
                                lblTotalRaw.Text = $"{reader.GetDouble("total_raw_percentage"):F2}%";

                                lblExamWeightedMidterm.Text = $"{reader.GetDouble("midterm_exam_weighted"):F2}%";
                                lblExamWeightedFinals.Text = $"{reader.GetDouble("finals_exam_weighted"):F2}%";

                                txtAttendanceMidterm.Text = $"{reader.GetDouble("midterm_attendance_weighted"):F2}%";
                                txtAttendanceFinals.Text = $"{reader.GetDouble("finals_attendance_weighted"):F2}%";

                                lblaptitudeWeightedMidterm.Text = $"{reader.GetDouble("midterm_aptitude_weighted"):F2}%";
                                lblaptitudeWeightedFinals.Text = $"{reader.GetDouble("finals_aptitude_weighted"):F2}%";

                                lblMidtermGrade.Text = $"{reader.GetDouble("midterm_grade"):F2}%";
                                lblFinalsGrade.Text = $"{reader.GetDouble("finals_grade"):F2}%";
                                lblMidtermGrade2.Text = $"{reader.GetDouble("midterm_grade"):F2}%";
                                lblFinalsGrade2.Text = reader.GetDouble("finals_exam_weighted") > 0 ? $"{reader.GetDouble("finals_grade"):F2}%" : "";

                                lblOverallGrade.Text = $"{finalGrade:F2}%";
                                circularProgressBar3.Value = (int)Math.Round(finalGrade);
                                circularProgressBar3.Text = $"{finalGrade:F2}%";

                                SaveOrUpdateFinalGradeFromReader(reader);
                                UpdateNotifier.RaiseGradeDataUpdated();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to execute grading procedure: " + ex.Message);
                }
            }
        }

    }
}