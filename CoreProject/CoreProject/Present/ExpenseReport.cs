using System;
using System.Collections.Generic;
using CoreProject.Controller.EmployeeControllers;
using System.ComponentModel;
using CoreProject.Data;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreProject.Present
{ 
    public partial class ExpenseReport : Form
    {
        


        private DateTime beginDate;
        private DateTime endDate;
        
       
        //DbMgr dbmgr = DbMgr.Instance;
        //public DbMgr Mgr { get; private set; }
        public RangeReportController rangeCtrl { get; private set; }

        public ExpenseReport(RangeReportController rControl)
        {
            this.rangeCtrl = rControl;
            InitializeComponent();
            MyInitialize();
        }

        private void MyInitialize()
        {
            //this.Mgr = DbMgr.Instance;
            BasicTotalCostsLabel.TextAlign = ContentAlignment.MiddleLeft;
            BasicTotalCostsLabel.AutoSize = false;

            ExtendedTotalCostsLabel.TextAlign = ContentAlignment.MiddleLeft;
            ExtendedTotalCostsLabel.AutoSize = false;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void BasicCostsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DateSelectSubmitButton_Click(object sender, EventArgs e)
        {
            if(EndingDatePicker.Value > DateTime.Now)          
                EndingDatePicker.Value = DateTime.Now;
            
            if(BeginningDatePicker.Value > DateTime.Now)
                BeginningDatePicker.Value = DateTime.Now;
            

            rangeCtrl.retrieveRangedData(BeginningDatePicker.Value, EndingDatePicker.Value);

           double[] temp = rangeCtrl.checkBills();
           rangeCtrl.outputBillsToForm(this, temp[0], temp[1], temp[2], temp[3]);

        }

        public void changeBeginningDateLabel(String date)
        {
            BeginningDateDisplayLabel.Text = date;
        }

        public void changeEndDateLabel(String date)
        {
            EndingDateDisplayLabel.Text = date;
        }

        public void setBasicTotal(double amount)
        {
            BasicTotalCostsLabel.Text = String.Format("{0:C}", amount);
        }

        public void setExtendedTotal(double amount)
        {
            ExtendedTotalCostsLabel.Text = String.Format("{0:C}", amount);
        }

        public void setBasicPercentage(double percentage)
        {
            if (percentage == 0)
            {
                BasicPercNumLabel.Text = String.Format("{0:.##}", 0);
            } else 
                BasicPercNumLabel.Text = String.Format("{0:.##}", percentage);
        }

        public void setExtendedPercentage(double percentage)
        {
            if (percentage == 0)
            {
                ExtendedPercNumLabel.Text = String.Format("{0:.##}", 0);
            }  else 
                ExtendedPercNumLabel.Text = String.Format("{0:.##}", percentage);
        }

        private void BasicPlanLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
