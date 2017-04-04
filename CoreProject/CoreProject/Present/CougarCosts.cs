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
using CoreProject.Data.Enrollee;

namespace CoreProject.Present
{
    public partial class CougarCosts : Form
    {
        public CougarCostsController CostCtrl { get; private set; }
        public CougarCosts(CougarCostsController CoCtrl)
        {
            this.CostCtrl = CoCtrl;
            InitializeComponent();

            //get the plans from the Controller
            var Plans = CostCtrl.GetPlans();
            // Each text field for Basic plan
            PYMBBasic.Text = Plans.ElementAt(0).PYMB.ToString();
            OPMIBasic.Text = Plans.ElementAt(0).OPMIndividual.ToString();
            OPMFBasic.Text = Plans.ElementAt(0).OPMFamily.ToString();
            APDBasic.Text = Plans.ElementAt(0).APD.ToString();
            PrimaryBasicFee.Text = Plans.ElementAt(0).PrimaryFee.ToString();
            DependentBasicFee.Text = Plans.ElementAt(0).DependentFee.ToString();
            InpatientBasicPercent.Text = Plans.ElementAt(0).ServiceCosts[0].PercentCoverage.ToString();
            InpatientBasicCopay.Text = Plans.ElementAt(0).ServiceCosts[0].RequiredCopayment.ToString();
            IBHBasicPercent.Text = Plans.ElementAt(0).ServiceCosts[1].PercentCoverage.ToString();
            IBHBasicCopay.Text = Plans.ElementAt(0).ServiceCosts[1].RequiredCopayment.ToString();
            ERBasicPercent.Text = Plans.ElementAt(0).ServiceCosts[2].PercentCoverage.ToString();
            ERBasicCopay.Text = Plans.ElementAt(0).ServiceCosts[2].RequiredCopayment.ToString();



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        public double getPYMBBasic()
        {
            double temp = double.Parse(PYMBBasic.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }


        public double getPYMBExtend()
        {
            double temp = double.Parse(PYMBExtended.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getOPMIBasic()
        {
            double temp = double.Parse(OPMIBasic.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getOPMIExtend()
        {
            double temp = double.Parse(OPMIExtend.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getOPMFBasic()
        {
            double temp = double.Parse(OPMFBasic.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getOPMFExtend()
        {
            double temp = double.Parse(OPMFExtend.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getAPDBasic()
        {
            double temp = double.Parse(APDBasic.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getAPDExtend()
        {
            double temp = double.Parse(APDExtend.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getPrimaryBasicFee()
        {
            double temp = double.Parse(PrimaryBasicFee.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getPrimaryExtendFee()
        {
            double temp = double.Parse(PrimaryExtendFee.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getDependBasicFee()
        {
            double temp = double.Parse(DependentBasicFee.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getDependExtendFee() {
            double temp = double.Parse(DependentExtendFee.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getInpatientBasicPercent()
        {
            double temp = double.Parse(InpatientBasicPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getInpatientBasicCopay()
        {
            double temp = double.Parse(InpatientBasicCopay.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getInpatientExtendPercent()
        {
            double temp = double.Parse(InpatientExtendPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getInpatientExtendCopay()
        {
            double temp = double.Parse(InpatientExtendCopay.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getIBHBasicPercent()
        {
            double temp = double.Parse(IBHBasicPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getIBHBasicCopay()
        {
            double temp = double.Parse(IBHBasicCopay.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getIBHExtendPercent()
        {
            double temp = double.Parse(IBHExtendPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getIBHExtendCopay()
        {
            double temp = double.Parse(IBHExtendCopay.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getERBasicPercent()
        {
            double temp = double.Parse(ERBasicPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getERBasicCopay()
        {
            double temp = double.Parse(ERBasicCopay.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getERExtendPercent()
        {
            double temp = double.Parse(ERExtendPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getERExtendCopay()
        {
            double temp = double.Parse(ERExtendCopay.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getOSBasicPercent()
        {
            double temp = double.Parse(OSBasicPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getOSBasicCopay()
        {
            double temp = double.Parse(OSBasicCopay.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getOSExtendPercent()
        {
            double temp = double.Parse(OSExtendPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getOSExtendcopay()
        {
            double temp = double.Parse(OSExtendCopay.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getDLXrayBasic()
        {
            double temp = double.Parse(DLXrayBasicPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getDLXrayExtend()
        {
            double temp = double.Parse(DLXrayExtendPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getPOVBasicPercent()
        {
            double temp = double.Parse(POVBasicPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getPOVExtendPercent()
        {
            double temp = double.Parse(POVExtendPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getPOVExtendCopay()
        {
            double temp = double.Parse(POVExtendCopay.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getSOVBasicPercent()
        {
            double temp = double.Parse(SOVBasicPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getSOVExtendPercent()
        {
            double temp = double.Parse(SOVExtendPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getSOVExtendCopay() {
            double temp = double.Parse(SOVExtendCopay.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getPSBasicPercent()
        {
            double temp = double.Parse(PSBasicPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getPSExtendPercent()
        {
            double temp = double.Parse(PSExtendPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getBCBasicPercent()
        {
            double temp = double.Parse(BCBasicPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getBCExtendPercent()
        {
            double temp = double.Parse(BCExtendPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getDMEBasicPercent()
        {
            double temp = double.Parse(DMEBasicPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getDMEExtendPercent()
        {
            double temp = double.Parse(DMEExtendPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getNFBasicPercent()
        {
            double temp = double.Parse(NFBasicPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getNFExtendPercent()
        {
            double temp = double.Parse(NFExtendPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getPTBasicPercent()
        {
            double temp = double.Parse(PTBasicPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getPTExtendPercent()
        {
            double temp = double.Parse(PTExtendPercent.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        public double getPTExtendCopay()
        {
            double temp = double.Parse(PTExtendCopay.Text);
            if (temp < 0)
            {
                temp *= -1;
            }
            return temp;
        }

        private void PYMBBasicLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void NFBasicPercent_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
