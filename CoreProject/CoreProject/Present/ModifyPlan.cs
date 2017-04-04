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
        public ModifyPlan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Login the user with the ModifyPlanController. And create the Data source 
        /// </summary>
        /// <param name="primaryId"></param>
        public ModifyPlan(int primaryId) : this()
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

        private void PickPlan_Click(object sender, EventArgs e)
        {
            this.Ctrl.ChangeCurrent(this.ComparedPlan);
            this.Close();
        }
    }
}
