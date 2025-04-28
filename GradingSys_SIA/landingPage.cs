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
        private string fullName;
        private Image profileImage;
        public landingPage(string fullName, Image profileImage)
        {
            InitializeComponent();
            this.fullName = fullName;
            this.profileImage = profileImage;
        }




        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // MakePictureBoxCircular(pictureBox2);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void landingPage_Load(object sender, EventArgs e)
        {
            lbl_studName.Text = "Welcome, " + fullName;

            if (profileImage != null)
            {
                pictureBox2.Image = profileImage;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                // Set default image if no profile image exists
                //pictureBox2.Image = Properties.Resources.DefaultProfilePic;
            }
        }
    }
}

