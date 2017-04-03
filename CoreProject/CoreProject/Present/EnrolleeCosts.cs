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

namespace CoreProject.Present
{
    public partial class EnrolleeCosts : Form
    {

        public PlanController planCtrl { get; private set; }
        public EnrolleeCosts(PlanController ctrl)
        {
            this.planCtrl = ctrl;
            InitializeComponent();
            myInitialize();
        }

        private void myInitialize()
        {
            planCtrl.update(this);
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

        public void setInpatientPercent(double amount)
        {
            InpatientPercentLabel.Text = amount + "";
        }

        public void setInpatientCopay(double amount)
        {
            InpatientCopayLabel.Text = amount + "";
        }

        public void setInpatientBHPercent(double amount)
        {
            InpatientBHPercentLabel.Text = amount + "";
        }

        public void setInpatientBHCopay(double amount)
        {
            InpatientBHCopayLabel.Text = amount + "";
        }

        public void setEmergencyRoomPercent(double amount)
        {
            EmergencyPercentLabel.Text = amount + "";
        }

        public void setEmergencyRoomCopay(double amount)
        {
            EmergencyCopayLabel.Text = amount + "";
        }

        public void setOutpatientPercent(double amount)
        {
            OutpatientPercentLabel.Text = amount + "";
        }

        public void setOutpatientCopay(double amount)
        {
            OutpatientCopayLabel.Text = amount + "";
        }

        public void setDLX(double amount)
        {
            DLXPercentLabel.Text = amount + "";
        }

        public void setPhysicianPercent(double amount)
        {
            PhysicianPercentLabel.Text = amount + "";
        }

        public void setSpecialistPercent(double amount)
        {
            SpecialistPercentLabel.Text = amount + "";
        }

        public void setPreventativePercent(double amount)
        {
            PreventivePercentLabel.Text = amount + "";
        }

        public void setBabyCarePercent(double amount)
        {
            BabyCarePercentLabel.Text = amount + "";
        }
        
        public void setDMEPercent(double amount)
        {
            DMEPercentLabel.Text = amount + "";
        }

        public void setPTPercent(double amount)
        {
            PhysicalTherapyPercentLabel.Text = amount + "";
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
    }
}
