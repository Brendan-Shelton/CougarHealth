﻿using System;
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
    public partial class HSPPortal : Form
    {
        public HSPPortal()
        {
            InitializeComponent();
        }

        private void create_Click(object sender, EventArgs e)
        {
            var hspCtrl = new CreateHSPController();
            var hspForm = new HSPAccount(hspCtrl);
            hspForm.Show();
        }

        private void bill_Click(object sender, EventArgs e)
        {
            var billCtrl = new BillController();
            //var billForm = new Billing(billCtrl);
            //billForm.Show();
        }

        private void login_Click(object sender, EventArgs e)
        {
            var loginForm = new HSPLogin();
            loginForm.Show();
        }
    }
}
