using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GradingSys_SIA
{
    public partial class studLogin : Form
    {
        private DbConnection db;
        public studLogin()
        {
            InitializeComponent();
            db = new DbConnection();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string cadetId = textBox1.Text.Trim();
            MessageBox.Show("You entered ID: [" + cadetId + "]");

            if (string.IsNullOrEmpty(cadetId))
            {
                MessageBox.Show("Please enter your Cadet ID.");
                return;
            }

            try
            {
                db.OpenConnection();
                MySqlConnection connection = db.GetConnection();
                MessageBox.Show("Connection State: " + connection.State.ToString());

                string query = "SELECT first_name, middle_name, last_name, profile_picture FROM cadet_info WHERE cadet_id = @cadetId";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@cadetId", cadetId);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string firstName = reader["first_name"].ToString();
                    string middleName = reader["middle_name"].ToString();
                    string lastName = reader["last_name"].ToString();

                    Image profileImage = null;
                    if (reader["profile_picture"] != DBNull.Value)
                    {
                        byte[] imageData = (byte[])reader["profile_picture"];
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            profileImage = Image.FromStream(ms);
                        }
                    }

                    string fullName = $"{firstName} {middleName} {lastName}";

                    sideBarPanel sideBar = new sideBarPanel(fullName, profileImage);
                    sideBar.Show();
                    this.Hide();
                }
                else
                {
                    reader.Close();
                    MessageBox.Show("Wrong ID. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

        }
    }
}
