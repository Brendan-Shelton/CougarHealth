using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreProject.Controller.HSPControllers;
using CoreProject.Data.HealthcareServiceProvider;

namespace CoreProject.Present
{
    public partial class HSPLogin : Form
    {
        private HSPLoginController Ctrl { get; } = new HSPLoginController();
        public HSPLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Take the name and pin supplied and pass it to the 
        /// HSPLoginController. If the HSPLoginController sends back a non-null
        /// id then we use that for billing, otherwise we show an error message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submit_Click(object sender, EventArgs e)
        {
            string name = this.companyName.Text;
            string pwd = this.pin.Text;
            HSP hsp;
            hsp = Ctrl.Login(name, pwd);

            if ( hsp == null )
            {
                MessageBox.Show("Login failed: invalid credentials");
            }
            else
            {
                var billCtrl = new BillController();
                var billing = new Billing(billCtrl, hsp);
                billing.Show();
                billing.Closed += (source, args) => this.Close();
                this.Hide();
            }
        }
    }
}
