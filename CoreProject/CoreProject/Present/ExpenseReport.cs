using System;
using System.Collections.Generic;
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

        private int numBills;

        private double basicPayments;
        private double extendedPayments;
        private double percentBasic;
        private double percentExtended;

        //DbMgr dbmgr = DbMgr.Instance;
        public DbMgr dbmgr { get; }

        public ExpenseReport()
        {
            InitializeComponent();
            MyInitialize();
            numBills = 0;
        }

        private void MyInitialize()
        {
           
            BasicCostsView.ColumnCount = 2;
            BasicCostsView.Columns[0].Name = "Basic";
            
        }

        /*
            This Method needs to retrieve the amount that Cougar Health is paying, broken out by plan type. 
            It should include the amount paid across all bills in the specified timeframe and the percentage of the total amount from all bills
            that the paid amount represents. 
            (The total amount from all bills value should be adjusted to reflect the maximum billable amount by IHSPs)
         */
        public String[][] retrieveRangedData(DateTime bDate, DateTime eDate)
        {
            String[][] data = dbmgr.getBills(bDate, eDate);

            return data;
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
    }
}
