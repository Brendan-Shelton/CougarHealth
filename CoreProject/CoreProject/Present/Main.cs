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
        }
    }
}
