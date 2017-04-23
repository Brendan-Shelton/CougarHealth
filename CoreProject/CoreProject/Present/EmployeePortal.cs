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
            var cougCostGUI = new ChangeCosts(cougarCostsCtrl);
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

        private void button4_Click(object sender, EventArgs e)
        {
            var changeBenefits = new ChangeBenefits(new ChangeBenefitsController());
            changeBenefits.Show();
        }

        private void removePlan_Click(object sender, EventArgs e)
        {
            var removeCtrl = new RemovePlanController();
            var removeGUI = new RemovePlan(removeCtrl);
            removeGUI.Show();
        }

        /// <summary>
        /// Display what the employee can do based on it's permission
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeePortal_Load(object sender, EventArgs e)
        {
            switch ( employee.Permission )
            {
                case Permission.Manager:
                    // manager can do anything homie
                    break;
                case Permission.PlanAdmin:
                    // date range report
                    this.button1.Visible = false;
                    // Monthly report
                    this.button2.Visible = false;
                    this.createEmployee.Visible = false;
                    this.modify.Visible = false;
                    break;
                case Permission.Accountant:
                    // change benefits
                    this.button4.Visible = false;
                    // cougar costs
                    this.button3.Visible = false;
                    this.removePlan.Visible = false;
                    this.modify.Visible = false;
                    this.createEmployee.Visible = false;
                    break;
                case Permission.EnrolleeSupport:
                    // date range report
                    this.button1.Visible = false;
                    // Monthly report
                    this.button2.Visible = false;
                    // cougar costs
                    this.button3.Visible = false;
                    // change benefits
                    this.button4.Visible = false;
                    this.removePlan.Visible = false;
                    this.modify.Visible = false;
                    this.createEmployee.Visible = false;
                    break;
                case Permission.HSPSupport:
                    // date range report
                    this.button1.Visible = false;
                    // Monthly report
                    this.button2.Visible = false;
                    // cougar costs
                    this.button3.Visible = false;
                    // change benefits
                    this.button4.Visible = false;
                    this.removePlan.Visible = false;
                    this.modify.Visible = false;
                    this.createEmployee.Visible = false;
                    break;
                default:
                    // you have access to nothing homie.
                    // date range report
                    this.button1.Visible = false;
                    // Monthly report
                    this.button2.Visible = false;
                    // cougar costs
                    this.button3.Visible = false;
                    // change benefits
                    this.button4.Visible = false;
                    this.removePlan.Visible = false;
                    this.modify.Visible = false;
                    this.createEmployee.Visible = false;
                    break;

            }
        }
    }
}
