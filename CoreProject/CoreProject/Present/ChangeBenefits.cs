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
    public partial class ChangeBenefits : Form
    {
        ChangeBenefitsController ChangeCtrl;
        public ChangeBenefits(ChangeBenefitsController ChangeCtrl)
        {
            this.ChangeCtrl = ChangeCtrl;
            InitializeComponent();
            var plans = ChangeCtrl.GetPlans();
            foreach (var item in plans)
            {
                planList.Items.Add(item.Type);
            }
        }

        private void addSubmit_Click(object sender, EventArgs e)
        {
            if(planList.SelectedItem != null)
            {
                var plan = ChangeCtrl.GetPlan(planList.SelectedItem.ToString());
                var result = ChangeCtrl.AddBenefit(plan, benefitName.Text, catName.Text, Convert.ToDouble(percent.Value), Convert.ToDouble(copay.Value), Convert.ToDouble(maxPay.Value));
                if (result)
                {
                    benefitList.Items.Add(benefitName.Text);

                    MessageBox.Show("Successfully Added Benefit");
                }
                else
                {
                    MessageBox.Show("Error Processing Request");
                }
                
            }
            
        }

        private void removeSubmit_Click(object sender, EventArgs e)
        {
            if(planList.SelectedItem != null && benefitList.SelectedItem != null)
            {
                var plan = ChangeCtrl.GetPlan(planList.SelectedItem.ToString());
                var result = ChangeCtrl.RemoveBenefit(plan, benefitList.SelectedItem.ToString());
                if (result)
                {
                    benefitList.Items.Remove(benefitList.SelectedItem);
                    MessageBox.Show("Successfully Removed Benefit");
                }
                else
                {
                    MessageBox.Show("Error Processing Request");
                }
                

            }
            
        }

        private void planList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var plan = ChangeCtrl.GetPlan(planList.SelectedItem.ToString());
            benefitList.Items.Clear();
            foreach (var item in plan.ServiceCosts)
            {
                benefitList.Items.Add(item.Name);
            }
        }

        private void benefitList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
