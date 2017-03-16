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
    public partial class EmployeePortal : Form
    {
        public EmployeePortal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;

            var monthReportCtrl = new MonthReportController();
            var monthGUI = new MonthlyReport(monthReportCtrl, date);
            monthGUI.Show();

        }
    }
}
