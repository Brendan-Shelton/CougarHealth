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

        public void setBasicTotalIncome(double amount)
        {
            if (amount > -1)
            {
                BasicTotalIncomeLabel.Text = String.Format("{0:C}", amount);
            }
        }

        public void setExtendTotalIncome(double amount)
        {
            if (amount > -1)
            {
                ExtendedTotalIncomeLabel.Text = String.Format("{0:C}", amount);
            }
        }

        public void setMonth(String month)
        {
            MonthLabel.Text = month;
        }

        public void setIHSPNumHospBills(int amount)
        {
            if (amount > -1)
            {
                ISHPHospitalNumBills.Text = amount + "";
            }
        }

        public void setOHSPNumHospBills(int amount)
        {
            if (amount > -1)
            {
                OHSPHospitalNumBills.Text = amount + "";
            }
        }

        public void setIHSPNumPhysBills(int amount)
        {
            IHSPPhysicianNumBills.Text = amount + "";
        }

        public void setOHSPNumPhysBills(int amount)
        {
            OHSPPhysicianNumBills.Text = amount + "";
        }

        public void setIHSPNumOtherBills(int amount)
        {
            IHSPOtherNumBills.Text = amount + "";
        }

        public void setOHSPNumOtherBills(int amount)
        {
            OHSPOtherNumBills.Text = amount + "";
        }

        public void setHospitalIHSP(double amount)
        {
            HospitalIHSP.Text = String.Format("{0:C}", amount);
        }

        public void setHospitalOHSP(double amount)
        {
            HospitalOHSP.Text = String.Format("{0:C}", amount);
        }

        public void setPhysicianIHSP(double amount)
        {
            physicianIHSP.Text = String.Format("{0:C}", amount);
        }

        public void setPhysicianOHSP(double amount)
        {
            PhysicanOHSP.Text = String.Format("{0:C}", amount);
        }

        public void setOtherIHSP(double amount)
        {
            categoryOtherIHSP.Text = String.Format("{0:C}", amount);
        }

        public void setOtherOHSP(double amount)
        {
            categoryOtherOHSP.Text = String.Format("{0:C}", amount);
        }

        public void setAmountOwedIHSP(double amount)
        {
            amountOwedIHSP.Text = String.Format("{0:C}", amount);
        }

        public void setAmountOwedOHSP(double amount)
        {
            amountOwedOHSP.Text = String.Format("{0:C}", amount);
        }

        public void setMaxPercentBillable(double amount)
        {
            PercentMaxChargeLabel.Text = String.Format("{0:##}", amount) + "%";
        }

        public void setTotalEnrolleePayments(int amount)
        {
            TotalNumEnrolleePaymentsLabel.Text = amount + "";
        }

        public void setTotalCosts(double amount)
        {
            totalCharges.Text = String.Format("{0:C}", amount);
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void PercentMaxChargeLabel_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }
    }
}
