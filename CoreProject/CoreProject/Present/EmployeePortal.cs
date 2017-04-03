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
using CoreProject.Data.Employees;

namespace CoreProject.Present
{
    public partial class EmployeePortal : Form
    {
        private Employee employee;

        public EmployeePortal()
        {
            InitializeComponent();
        }

        public EmployeePortal(Employee employee) : this()
        {
            this.employee = employee;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;

            var monthReportCtrl = new MonthReportController();
            var monthGUI = new MonthlyReport(monthReportCtrl, date);
            monthGUI.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rangeReportCtrl = new RangeReportController();
            var expenseGUI = new ExpenseReport(rangeReportCtrl);
            expenseGUI.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var cougarCostsCtrl = new CougarCostsController();
            var cougCostGUI = new CougarCosts(cougarCostsCtrl);
            cougCostGUI.Show();
        }

        private void createEmployee_Click(object sender, EventArgs e)
        {
            var creation = new CreateEmployee();
            var creationCtrl = new CreateEmployeeController();
            creation.Show();
        }

        private void modify_Click(object sender, EventArgs e)
        {
            var manage = new ManageEmployee();
            manage.Show();
        }
    }
}
