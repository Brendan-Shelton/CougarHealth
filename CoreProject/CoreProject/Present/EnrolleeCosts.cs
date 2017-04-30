using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreProject.Controller.EnrolleeControllers;
using CoreProject.Data.Enrollee;
using CoreProject.Data.HealthcareServiceProvider;

namespace CoreProject.Present
{
    public partial class EnrolleeCosts : Form
    {

        public PlanController planCtrl { get; private set; }

        public void PlanPicked ( object source, ChoiceArgs e )
        {
            myInitialize(e.PlanNum);
        }
        public EnrolleeCosts(PlanController ctrl)
        {
            this.planCtrl = ctrl;
            InitializeComponent();
            if ( planCtrl.MultiplePlans )
            {
                var pick = new PickPlan(ctrl._primaryId);
                pick.OnChoice += new ChoiceHandler(PlanPicked);
                pick.Show();
            }
        }

        private void myInitialize( int planNum )
        {
            planCtrl.update(this, planNum);
        }

        public void addHospitalService(Service service)
        {
            String backline = service.PercentCoverage*100 + "% after $" + service.RequiredCopayment + " Copay\n";

            String line = String.Format("{0, -30} {1, 34}", service.Name, backline);
            HospitalListBox.Items.Add(line);
        }

        public void addPhysicianService(Service service)
        {
            String backline = service.PercentCoverage * 100 + "% after $" + service.RequiredCopayment + " Copay\n";

            String line = String.Format("{0, -30} {1, 34}", service.Name, backline);
            PhysicianListBox.Items.Add(line);
        }

        public void addOtherService(Service service)
        {
            String backline = service.PercentCoverage * 100 + "% after $" + service.RequiredCopayment + " Copay\n";

            String line = String.Format("{0, -30} {1, 34}", service.Name, backline);
            OtherListBox.Items.Add(line);
        }

        public void addBillRow(Bill bill)
        {
            var enrollee = planCtrl.dbmgr.FindPrimaryById(bill.enrolleeId);
            if (enrollee == null)
            {
                var depEnrollee = planCtrl.dbmgr.FindDependentById(bill.enrolleeId);
                BillsListView.Rows.Add(bill.date.ToShortDateString(), (depEnrollee.FirstName + " " + depEnrollee.LastName), planCtrl.dbmgr.GrabHspById(bill.hspId).Name, planCtrl.dbmgr.GetServiceById(bill.serviceId).Name, bill.enrolleeBillAmount, bill.totalBillAmount);
                return;
            }
            BillsListView.Rows.Add(bill.date.ToShortDateString(), (enrollee.FirstName + " " + enrollee.LastName), planCtrl.dbmgr.GrabHspById(bill.hspId).Name, planCtrl.dbmgr.GetServiceById(bill.serviceId).Name, bill.enrolleeBillAmount, bill.totalBillAmount);
        }

        public void setPolicyNumber(int amount)
        {
            label12.Text = amount + "";
        }

        public void setTotalCharges(double amount)
        {
            totalChargesLabel.Text = String.Format("{0:C}", amount);
        }

        public void setPlanYearMaxRemain(double amount)
        {
            PYMBRlabel.Text = String.Format("{0:C}", amount);
        }

        public void setPlanYearMaxBen(double amount)
        {
            PYMBLabel.Text = String.Format("{0:C}", amount);
        }

        public void setOutPocketInd(double amount)
        {
            OPMILabel.Text = String.Format("{0:C}", amount);
        }

        public void setOutPocketFam(double amount)
        {
            OPMFLabel.Text = String.Format("{0:C}", amount);
        }

        public void setOutPockeRem(double amount)
        {
            OPMRemainingLabel.Text = String.Format("{0:C}", amount);
        }

        public void setAPDRem(double amount)
        {
            APDRemLabel.Text = String.Format("{0:C}", amount);
        }

        public void setAPD(double amount)
        {
            APDLabel.Text = String.Format("{0:C}", amount);
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
