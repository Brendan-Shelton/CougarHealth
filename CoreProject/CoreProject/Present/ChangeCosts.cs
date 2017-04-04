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
            label2.Hide();

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
                    listBox1.Items.Add("Annual Plan Deductible");
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
            UpdateTextBox();
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
                    bool percentValid = false;
                    if (plan == CostCtrl.GetPlan(listBox2.SelectedItem.ToString()))
                    {
                        
                        if(listBox1.SelectedItem != null)
                        {
                             percentValid = (CostCtrl.GetNum(listBox1.SelectedItem.ToString(), plan.Type, percent, maxPay) <= 1);
                        }
                        if (percent && percentValid)
                        {
                            numericUpDown1.Text = (100 * CostCtrl.GetNum(listBox1.SelectedItem.ToString(), plan.Type, percent, maxPay)).ToString();
                            label3.Hide();
                            label2.Show();
                        }
                        else
                        {
                            if(listBox1.SelectedItem != null)
                            numericUpDown1.Text = CostCtrl.GetNum(listBox1.SelectedItem.ToString(), plan.Type, percent, maxPay).ToString();
                            label3.Show();
                            label2.Hide();
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

        private void button1_Click(object sender, EventArgs e)
        {
            var Plans = CostCtrl.GetPlans();

            foreach (var plan in Plans)
            {
                if (plan.Type.Equals(listBox2.SelectedItem.ToString()))
                {
                    if (checkBox1.Checked)
                    {
                        if(Convert.ToDouble(numericUpDown1.Value) > 1)
                            CostCtrl.Update(plan, listBox1.SelectedItem.ToString(), checkBox1.Checked, checkBox2.Checked, (Convert.ToDouble(numericUpDown1.Value) / 100));
                        else if(Convert.ToDouble(numericUpDown1.Value) < 0)
                        {
                            // error
                        }
                        else
                        {
                            CostCtrl.Update(plan, listBox1.SelectedItem.ToString(), checkBox1.Checked, checkBox2.Checked, Convert.ToDouble(numericUpDown1.Value));
                        }
                    }
                    else
                    {
                        CostCtrl.Update(plan, listBox1.SelectedItem.ToString(), checkBox1.Checked, checkBox2.Checked, Convert.ToDouble(numericUpDown1.Value));
                    }
                    this.Refresh();
                }
            }
        }
    }
}
