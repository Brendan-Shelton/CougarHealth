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
    public partial class ChangeCosts : Form
    {
        public CougarCostsController CostCtrl {get; private set; }
        public ChangeCosts(CougarCostsController CoCtrl)
        {
            this.CostCtrl = CoCtrl;
            InitializeComponent();

            var Plans = CostCtrl.GetPlans();

            foreach (var plan in Plans)
            {
                listBox2.Items.Add(plan.Type.ToString());
            }
            
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Plans = CostCtrl.GetPlans();
            foreach (var plan in Plans)
            {
                if (plan == CostCtrl.GetPlan(listBox2.SelectedItem.ToString()))
                {
                    listBox1.Items.Add("Plan Year Max Benefit");
                    listBox1.Items.Add("Out of Pocket Maximum Per Enrollee");
                    listBox1.Items.Add("Out of Pocket Maximum Per Family");
                    listBox1.Items.Add("Annual Plan Deductable");
                    listBox1.Items.Add("Primary Enrollee Fee");
                    listBox1.Items.Add("Primary Enrollee Change Fee");
                    listBox1.Items.Add("Dependent Enrollee Fee");
                    listBox1.Items.Add("Dependent Enrollee Change Fee");

                    for (int i = 0; i < plan.ServiceCosts.Length; i++)
                    {
                        listBox1.Items.Add(plan.ServiceCosts[i].Name);
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextBox();
        }


            private void UpdateTextBox()
        {
            var Plans = CostCtrl.GetPlans();
            var percent = checkBox1.Checked;
            var maxPay = checkBox2.Checked;
            if (maxPay && percent)
            {
                // no can do
            }
            else
            {
                foreach (var plan in Plans)
                {
                    if (plan == CostCtrl.GetPlan(listBox2.SelectedItem.ToString()))
                    {
                        if (percent)
                        {
                            textBox1.Text = (100 * CostCtrl.GetNum(listBox1.SelectedItem.ToString(), plan.Type, percent, maxPay)).ToString();
                        }
                        else
                        {
                            textBox1.Text = CostCtrl.GetNum(listBox1.SelectedItem.ToString(), plan.Type, percent, maxPay).ToString();
                        }

                    }
                }
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox();
        }
    }
}
