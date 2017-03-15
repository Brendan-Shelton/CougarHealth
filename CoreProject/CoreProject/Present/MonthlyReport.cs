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
    public partial class MonthlyReport : Form
    {
        public MonthReportController mthCtrl { get; private set; }

        public MonthlyReport(MonthReportController monthCtrllr) {

            this.mthCtrl = monthCtrllr;
            InitializeComponent();

            mthCtrl.update(this);
        }

        public void setBasicEnrollNum(int amount)
        {
            if (amount >=0 )
            {
                basicNumEnrolleesLabel.Text = amount + "";
            }
        }

        public void setExtendedErollNum(int amount)
        {
            if (amount >=0 )
            {
                ExtendedNumEnrolleesLabel.Text = amount + "";
            }
        }

        public void setMonth(String month)
        {
            MonthLabel.Text = month;
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }
    }
}
