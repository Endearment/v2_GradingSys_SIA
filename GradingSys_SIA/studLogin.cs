using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace GradingSys_SIA
{
    public partial class studLogin : Form
    {
        private DbConnection db;

        public studLogin()
        {
            InitializeComponent();
            db = new DbConnection("cis_db");
            textBox1.KeyPress += textBox1_KeyPress;
            textBox1.MaxLength = 10;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string cadetId = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(cadetId))
                {
                    MessageBox.Show("Please enter your Cadet ID.");
                    return;
                }

                string fullName = null;
                Image profileImage = null;
                int aptitudePoints = 0;

                try
                {
                    db.OpenConnection();
                    MySqlConnection connection = db.GetConnection();

                    string query = @"SELECT c.first_name, c.middle_name, c.last_name, c.profile_picture, a.aptitude_points
                                     FROM cadet_info c
                                     LEFT JOIN aptitude a ON c.cadet_id = a.student_id
                                     WHERE c.cadet_id = @cadetId";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@cadetId", cadetId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string firstName = reader["first_name"].ToString();
                                string middleName = reader["middle_name"].ToString();
                                string lastName = reader["last_name"].ToString();

                                if (reader["profile_picture"] != DBNull.Value)
                                {
                                    byte[] imageData = (byte[])reader["profile_picture"];
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        profileImage = Image.FromStream(ms);
                                    }
                                }

                                if (reader["aptitude_points"] != DBNull.Value)
                                {
                                    aptitudePoints = Convert.ToInt32(reader["aptitude_points"]);
                                }

                                fullName = $"{firstName} {middleName} {lastName}";
                            }
                        }
                    }
                    db.CloseConnection();

                    db.OpenConnection();
                    using (MySqlCommand checkCmd = new MySqlCommand("SELECT COUNT(*) FROM aptitude WHERE Student_ID = @cadetId", db.GetConnection()))
                    {
                        checkCmd.Parameters.AddWithValue("@cadetId", cadetId);
                        long count = (long)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            string insertQuery = "INSERT INTO aptitude (Student_ID, Total_Demerits, aptitude_points) VALUES (@cadetId, 0, 100)";
                            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, db.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@cadetId", cadetId);
                                insertCmd.ExecuteNonQuery();
                            }

                            aptitudePoints = 100;
                        }
                    }
                    db.CloseConnection();

                    if (fullName != null)
                    {
                        sideBarPanel sideBar = new sideBarPanel(fullName, profileImage, cadetId, aptitudePoints);
                        sideBar.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("ID does not exist. Please try again.", "Login Failed",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    if (db.GetConnection().State == ConnectionState.Open)
                    {
                        db.CloseConnection();
                    }
                }
            }
        }
    }
}
