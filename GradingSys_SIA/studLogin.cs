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
    public partial class studLogin : Form
    {
        public studLogin()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Form form = new sideBarPanel();
            form.Show();
            this.Hide();
        }
    }
}
