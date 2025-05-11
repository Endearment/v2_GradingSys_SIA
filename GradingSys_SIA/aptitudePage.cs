using MySql.Data.MySqlClient;
using System.Data;

namespace GradingSys_SIA
{
    public partial class aptitudePage : Form
    {
        private string studentId;

        public aptitudePage(string studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            this.Load += aptitudePage_Load;
           
        }

        private void aptitudePage_Load(object sender, EventArgs e)
        {
            LoadAptitudeData();
            LoadStudentDemeritsWithDate();
            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Enabled = true;
        }

        private void LoadAptitudeData()
        {
            DbConnection db = null;
            try
            {
                db = new DbConnection("cis_db");
                db.OpenConnection();
                MySqlConnection conn = db.GetConnection();

                string checkQuery = "SELECT COUNT(*) FROM aptitude WHERE Student_ID = @studentId";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@studentId", studentId);
                    long count = (long)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        string insertQuery = "INSERT INTO aptitude (Student_ID, Total_Demerits, aptitude_points) VALUES (@studentId, 0, 100)";
                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@studentId", studentId);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }

                string query = @"SELECT Total_Demerits, aptitude_points 
                         FROM aptitude 
                         WHERE Student_ID = @studentId";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int totalDemerits = Convert.ToInt32(reader["Total_Demerits"]);
                            int aptitudePoints = Convert.ToInt32(reader["aptitude_points"]);

                            UpdateAptitudeDisplay(totalDemerits, aptitudePoints);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading aptitude data: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db?.CloseConnection();
            }
        }


        private void LoadStudentDemeritsWithDate()
        {
            dataGridView1.ClearSelection();
            dataGridView1.Enabled = false;
            DbConnection db = null;
            try
            {
                db = new DbConnection("cis_db");
                db.OpenConnection();
                MySqlConnection conn = db.GetConnection();

                List<string> excludedColumns = new List<string>
                    {
                        "Student_ID",
                        "Total_Demerits",
                        "Aptitude_Points"
                    };

                List<string> demeritColumns = new List<string>();
                string columnQuery = "SHOW COLUMNS FROM aptitude";
                using (MySqlCommand cmd = new MySqlCommand(columnQuery, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string columnName = reader["Field"].ToString();
                        if (!excludedColumns.Contains(columnName))
                        {
                            demeritColumns.Add(columnName);
                        }
                    }
                }

                string dataQuery = "SELECT * FROM aptitude WHERE Student_ID = @studentId";
                using (MySqlCommand cmd = new MySqlCommand(dataQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable resultTable = new DataTable();
                        resultTable.Columns.Add("Demerit");
                        resultTable.Columns.Add("Date Taken");

                        while (reader.Read())
                        {
                            string date = reader["aptitude_date"].ToString();

                            foreach (string col in demeritColumns)
                            {
                                if (int.TryParse(reader[col].ToString(), out int value) && value > 0)
                                {
                                    for (int i = 0; i < value; i++)
                                    {
                                        resultTable.Rows.Add(col, date);
                                    }
                                }
                            }
                        }

                        dataGridView1.DataSource = resultTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading demerits: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db?.CloseConnection();
            }
        }


        private void UpdateAptitudeDisplay(int totalDemerits, int aptitudePoints)
        {
            label35.Text = totalDemerits.ToString();
            label15.Text = aptitudePoints.ToString();

            circularProgressBar2.Maximum = 100;
            circularProgressBar2.Value = aptitudePoints;
        }

        private void label13_Click(object sender, EventArgs e) => this.Hide();
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label35_Click(object sender, EventArgs e) { }



        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}