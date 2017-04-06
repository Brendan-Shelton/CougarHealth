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
            PercentLabel.Hide();
            Error.Hide();
            Copay.Checked = true;

            var Plans = CostCtrl.GetPlans();

            foreach (var plan in Plans)
            {
                PlanList.Items.Add(plan.Type.ToString());
            }
        }
        /// <summary>
        /// Updates the textbox with the appropriate value
        /// </summary>
        private void UpdateTextBox()
        {
            var Plans = CostCtrl.GetPlans();
            var percent = Percent.Checked;
            var maxPay = MaxPay.Checked;

            foreach (var plan in Plans)
            {
                bool percentValid = false;
                if(PlanList.SelectedItem != null)
                {
                    if (plan == CostCtrl.GetPlan(PlanList.SelectedItem.ToString()))
                    {

                        if (PlanQueries.SelectedItem != null)
                        {
                            percentValid = (CostCtrl.GetNum(PlanQueries.SelectedItem.ToString(), plan.Type, percent, maxPay) <= 1);
                        }
                        if (percent && percentValid)
                        {
                            Cost.Text = (100 * CostCtrl.GetNum(PlanQueries.SelectedItem.ToString(), plan.Type, percent, maxPay)).ToString();
                            DollarLabel.Hide();
                            PercentLabel.Show();
                        }
                        else
                        {
                            if (PlanQueries.SelectedItem != null)
                                Cost.Text = CostCtrl.GetNum(PlanQueries.SelectedItem.ToString(), plan.Type, percent, maxPay).ToString();
                            DollarLabel.Show();
                            PercentLabel.Hide();
                        }
                    }
                

                }
            }
        }
        /// <summary>
        /// When a different plan is selected, lists all benefits for that plan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlanList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Plans = CostCtrl.GetPlans();
            foreach (var plan in Plans)
            {
                if (plan == CostCtrl.GetPlan(PlanList.SelectedItem.ToString()))
                {
                    PlanQueries.Items.Add("Plan Year Max Benefit");
                    PlanQueries.Items.Add("Out of Pocket Maximum Per Enrollee");
                    PlanQueries.Items.Add("Out of Pocket Maximum Per Family");
                    PlanQueries.Items.Add("Annual Plan Deductible");
                    PlanQueries.Items.Add("Primary Enrollee Fee");
                    PlanQueries.Items.Add("Primary Enrollee Change Fee");
                    PlanQueries.Items.Add("Dependent Enrollee Fee");
                    PlanQueries.Items.Add("Dependent Enrollee Change Fee");

                    for (int i = 0; i < plan.ServiceCosts.Count(); i++)
                    {
                        PlanQueries.Items.Add(plan.ServiceCosts[i].Name);
                    }
                }
            }
            UpdateTextBox();
        }

        /// <summary>
        /// Updates the textbox to corrected value when PlanQueries Index changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlanQueries_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextBox();
        }

        /// <summary>
        /// Updates textbox if Percent Radio button is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Percent_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox();
        }

        /// <summary>
        /// Updates textbox if MaxPay radio button is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaxPay_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox();
        }
        /// <summary>
        /// Submits the selected information to the controller
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_Click(object sender, EventArgs e)
        {
            var Plans = CostCtrl.GetPlans();

            foreach (var plan in Plans)
            {
                if (plan.Type.Equals(PlanList.SelectedItem.ToString()))
                {
                    if (Percent.Checked)
                    {
                        if (Convert.ToDouble(Cost.Value) >= 1)
                        {
                            CostCtrl.Update(plan, PlanQueries.SelectedItem.ToString(), Percent.Checked, MaxPay.Checked, (Convert.ToDouble(Cost.Value) / 100));
                            ChangeCostsSuccess CCS = new ChangeCostsSuccess();
                            CCS.Show();

                        }
                            
                        
                        else if (Convert.ToDouble(Cost.Value) < 0)
                        {
                            Error.Text = "Percent cannot be negative";
                            Error.Show();
                        }
                        else
                        {
                            CostCtrl.Update(plan, PlanQueries.SelectedItem.ToString(), Percent.Checked, MaxPay.Checked, Convert.ToDouble(Cost.Value));
                            Error.Hide();
                        }
                    }
                    else
                    {
                        if(PlanQueries.SelectedItem != null)
                        {
                            CostCtrl.Update(plan, PlanQueries.SelectedItem.ToString(), Percent.Checked, MaxPay.Checked, Convert.ToDouble(Cost.Value));
                            ChangeCostsSuccess CCS = new ChangeCostsSuccess();
                            CCS.Show();
                        }
                        
                    }
                    RefreshForm();   
                }
            }
            

        }
        public void RefreshForm()
        {
            
            this.Refresh();
        }
        
    }
}
