using CoreProject.Controller.EnrolleeControllers;
using CoreProject.Data;
using CoreProject.Data.Enrollee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreProject.Present
{
    public partial class ModifyPlan : Form
    {
        private int _primaryId;
        public ModifyPlanController Ctrl { get; set; }
        public DataTable Src { get; set; }
        public InsurancePlan CurrentPlan { get; set; }
        public InsurancePlan ComparedPlan { get; set; }

        /// <summary>
        /// A plan has been picked, so we can show the current one 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void PlanPicked( object source, ChoiceArgs e )
        {
            this.Ctrl.PickPlan(e.PlanNum);
            this.DisplayCurrent();
        }

        /// <summary>
        /// When we only have one plan, we display it's details 
        /// </summary>
        public void DisplayCurrent ()
        {
            if (this.Ctrl.MultiplePlans) throw new ArgumentException("To many plans");

            this.CurrentPlan = Ctrl.CurrentDetails();
            var benefitName = "Benefits";
            var currName = "Current";
            this.Src.Columns.Add(new DataColumn(benefitName, typeof(string)));
            // current plan values 
            this.Src.Columns.Add(new DataColumn(currName, typeof(string)));
            // the data source for the datagrid view 
            foreach ( string type in this.Ctrl.PlanOptions() )
            {
                this.PlanType.Items.Add(type);
            }
            string[] benefits = this.Ctrl.BenfitsCompared();
            string[] currentBenefits = this.Ctrl.PrintPlanValues(this.CurrentPlan);
            for (int i = 0; i < benefits.Length; i++)
            {
                this.Src.Rows.Add(benefits[i], currentBenefits[i]);
            }
            this.PlanComparison.DataSource = this.Src;
            this.PlanComparison.AutoResizeColumns();


        }

        public ModifyPlan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Login the user with the ModifyPlanController. And create the Data source 
        /// </summary>
        /// <param name="primaryId"></param>
        public ModifyPlan(int primaryId, bool isPrimary) : this()
        {  
            this._primaryId = primaryId;
            this.Ctrl = new ModifyPlanController(primaryId);
            this.Src = new DataTable("Plan comparison");
        }

        /// <summary>
        /// load all benefit fields that we are presenting to the user as well 
        /// as the value for those fields in their current insurance plan 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyPlan_Load(object sender, EventArgs e)
        {
            if ( this.Ctrl.MultiplePlans )
            {
                var picked = new PickPlan(_primaryId);
                picked.Show();
                picked.OnChoice += new ChoiceHandler(this.PlanPicked);
            }
            else
            {
                this.DisplayCurrent();
            }
        }

        /// <summary>
        /// Delete the third column in the view, if it exists, and add a third 
        /// column for the values of the insurance plan that the Enrollee chose 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newColIdx = 2;
            // an insurance plan is already being compared delete it 
            if ( this.Src.Columns.Count > newColIdx )
            {
                this.Src.Columns.RemoveAt(newColIdx);
            }
            // grab selected plan 
            var selectedPlan = (string)this.PlanType.Items[this.PlanType.SelectedIndex];
            this.Src.Columns.Add(
                new DataColumn(selectedPlan, typeof(string))
            );

            // grab the benefit values of insurance plan and present to user 
            this.ComparedPlan = this.Ctrl.PlanDetails(selectedPlan);
            string[] comparedValues = this.Ctrl.PrintPlanValues(
                this.ComparedPlan
            );

            // update the rows already in the table 
            for (int i = 0; i < comparedValues.Length; i++)
            {
                DataRow dr = this.Src.Rows[i];
                dr[newColIdx] = comparedValues[i];
            }
            this.PickPlan.Visible = true;
            this.OtherServices.Visible = true; 
        }
        
        /// <summary>
        /// display service values for the current plan 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentServices_Click(object sender, EventArgs e)
        {
            var view = new ViewServices(this.CurrentPlan);
            view.Show();
        }

        /// <summary>
        /// Show the values for other services 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OtherServices_Click(object sender, EventArgs e)
        {
            if ( this.ComparedPlan != null)
            {
                var view = new ViewServices(this.ComparedPlan);
                view.Show();
            }
        }

        /// <summary>
        /// Attach the new Plan onto the current enrollee plan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PickPlan_Click(object sender, EventArgs e)
        {
            try
            {
                this.Ctrl.ChangeCurrent(this.ComparedPlan);
                DialogResult result = MessageBox.Show(
                    $"Your plan has been changed to \"{this.ComparedPlan.Type}\"",
                    "Plan changed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                this.Close();
            }
            catch ( ArgumentException )
            {
                DialogResult result = MessageBox.Show(
                    "Plan Types can only be changed once per Plan Coverage Year",
                    "Cannot change plan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                
                if ( result == DialogResult.OK)
                {
                    this.Focus();
                }
            }
            catch ( NullReferenceException )
            {
                DialogResult result = MessageBox.Show(
                    "There is no plan to change to",
                    "Cannot change plan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                
                if ( result == DialogResult.OK)
                {
                    this.Focus();
                }
            
            }
        }
    }
}
