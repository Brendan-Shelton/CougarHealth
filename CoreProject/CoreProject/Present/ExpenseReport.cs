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
    public partial class ExpenseReport : Form
    {
        private DateTime beginDate;
        private DateTime endDate;

        private int numBills;

        private double basicPayments;
        private double extendedPayments;
        private double percentBasic;
        private double percentExtended;



        public ExpenseReport()
        {
            InitializeComponent();

            //This is where the 
            numBills = 0;
        }

        /*
            This Method needs to retrieve the amount that Cougar Health is paying, broken out by plan type. 
            It should include the amount paid across all bills in the specified timeframe and the percentage of the total amount from all bills
            that the paid amount represents. 
            (The total amount from all bills value should be adjusted to reflect the maximum billable amount by IHSPs)
         */
        public void retrieveRangedData(DateTime bDate, DateTime eDate)
        {
            
        }

        
    }
}
