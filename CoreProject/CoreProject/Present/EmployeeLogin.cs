using CoreProject.Controller.EmployeeControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreProject.Present
{
    /// <summary>
    /// The barrier gui for the Employee portal. This will determine the type
    /// of actions the employee can do once they login 
    /// </summary>
    public partial class EmployeeLogin : Form
    {
        /// <summary>
        /// Does the backend login stuff
        /// </summary>
        private EmployeeLoginController Ctrl { get; set; }
        public EmployeeLogin()
        {
            this.Ctrl = new EmployeeLoginController();
            InitializeComponent();
        }

        /// <summary>
        /// Cross reference the provided UserName and Password with the login
        /// system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_Click(object sender, EventArgs e)
        {
            var employee = this.Ctrl.Login(this.Username.Text, this.Password.Text);
            if ( employee != null )
            {
                var employGUI = new EmployeePortal(employee);
                employGUI.Show();
                this.Hide();
                employGUI.FormClosed += (source, args) => this.Close();

            }
            else
            {
                this.ErrMsg.Visible = true;
                this.ErrMsg.Text = "Error: Credentials invalid";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
