using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreProject.Controller.EnrolleeControllers;

namespace CoreProject.Present
{
    public partial class Login : Form
    {
        public EnrollController EnrollCtrl { get; set; }
        public Login()
        {
            EnrollCtrl = new EnrollController();
            InitializeComponent();
        }

        private void loginSubmit_Click(object sender, EventArgs e)
        {
            var enrollee = EnrollCtrl.LoginPrimary(this.emailLogin.Text, this.pinLogin.Text);
            if (enrollee != null)
            {
                
                var enrolleeLoggedInForm = new LoggedInEnrollee(enrollee.Value);
                enrolleeLoggedInForm.Show();
                enrolleeLoggedInForm.FormClosed += (source, args) => this.Close();
                this.Hide();

            }
            else
            {
                this.errMsg.Text = @"Invalid login credentials";
                this.errMsg.Visible = true;
            }
        }

    }
}
