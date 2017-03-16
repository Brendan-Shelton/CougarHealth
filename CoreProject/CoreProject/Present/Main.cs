using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreProject.Controller.EmployeeControllers;

namespace CoreProject.Present
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            var rangeReportCtrl = new RangeReportController();
            var rangeGUI = new ExpenseReport(rangeReportCtrl);
            rangeGUI.Show();
        }

        private void monthButton_Click(object sender, EventArgs e)
        {
            var monthReportCtrl = new MonthReportController();
            var monthGUI = new MonthlyReport(monthReportCtrl);
            monthGUI.Show();
        }

        /// <summary>
        /// Open the enrollment gui to allow the client to enroll in an insurance plan 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enroll_Click(object sender, EventArgs e)
        {
            var portal = new EnrolleePortal();
            portal.Show();
            //portal.Closed += (source, args) => this.Close();
            //this.Hide();
        }

        private void hspForm_Click(object sender, EventArgs e)
        {
            var portal = new HSPPortal();
            portal.Show();
            portal.Closed += (source, args) => this.Close();
            this.Hide();
        }
    }
}
