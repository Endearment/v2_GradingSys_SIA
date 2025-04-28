using MySql.Data.MySqlClient;

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
        }

        private void LoadAptitudeData()
        {
            DbConnection db = null;
            try
            {
                db = new DbConnection("grading_db");
                db.OpenConnection();
                MySqlConnection conn = db.GetConnection();

                string query = @"SELECT Total_Demerits 
                       FROM aptitude 
                       WHERE Student_ID = @studentId";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    object result = cmd.ExecuteScalar();

                    int totalDemerits = (result != null && result != DBNull.Value) ?
                                       Convert.ToInt32(result) : 0;

                    UpdateAptitudeDisplay(totalDemerits);
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

        private void UpdateAptitudeDisplay(int totalDemerits)
        {
            int aptitudePoints = 100 - Math.Abs(totalDemerits);

            label5.Text = "100"; 
            label35.Text = Math.Abs(totalDemerits).ToString(); 
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
    }
}