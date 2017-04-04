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
        public Type LoginFor { get; set; }
        public Login( Type loginFor )
        {
            this.LoginFor = loginFor;
            EnrollCtrl = new EnrollController();
            InitializeComponent();
        }

        private void loginSubmit_Click(object sender, EventArgs e)
        {
            var enrollee = EnrollCtrl.LoginPrimary(this.emailLogin.Text, this.pinLogin.Text);
            if (enrollee != null)
            {
                Form form;
                if ( LoginFor == typeof(DependentEnroll) )
                {
                    form = new DependentEnroll(enrollee.Value);

                }
                else
                {
                    form = new ModifyPlan(enrollee.Value);
                }

                form.Show();
                form.Closed += (source, args) => this.Close();
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
