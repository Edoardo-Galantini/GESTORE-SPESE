using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESTORE_SPESE
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        // Method associated with the button btnLogin that allows access to the service
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string pwd = txtPwd.Text;
            CloseForm(pwd);
        }

        // Method to close the Form 
        private void CloseForm(string pwd)
        {
            if (pwd == "0000")
            {
                this.Close();
            }
            else
            {
                lblError.Text = "La Password è sbagliata. Riprova.";
            }
        }
    }
}
