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
    public partial class CougarCosts : Form
    {
        public CougarCostsController CostCtrl { get; private set; }
        public CougarCosts(CougarCostsController CoCtrl)
        {
            this.CostCtrl = CoCtrl;
            InitializeComponent();
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
            CostCtrl.update(this);
            this.Hide();
        }

        public double getPYMBBasic()
        {
            return double.Parse(PYMBBasic.Text);
        }
        public double getPYMBExtend()
        {
            return PYMBExtended.Value;
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
