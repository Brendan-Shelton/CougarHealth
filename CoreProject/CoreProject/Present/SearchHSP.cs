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

    //This Class was developed By Philip Atkins
    public partial class SearchHSP : Form
    {
        SearchController searchCntrl = new SearchController();
        public SearchHSP()
        {
            InitializeComponent();

            var plans = searchCntrl.GetPlans();                         //Grabs all plans
            foreach (var item in plans)                                 //Populates the PlanList box with all plans availible
            {
                planList.Items.Add(item.Type);
            }

            benefitListBox.Items.Clear();                               //Clears the benifit list box of default items
        }

        //This method searches the DB for all HSPs that provide the desired service 
        //and populates a DataGridView with the Results
        private void searchButton_Click(object sender, EventArgs e)
        {
            searchHSPResult.Rows.Clear();                               //Clears the DataGridView
            searchHSPResult.Refresh();
            string[] selected = new string[benefitListBox.CheckedIndices.Count];
            for (int i = 0; i < benefitListBox.CheckedIndices.Count; i++)   //converts the selected items to strings to aid searching
            {
                selected[i] = benefitListBox.CheckedItems[i].ToString();
            }

            foreach (string service in selected)                         //this goes through all selected services, and returns
            {                                                            //all providers that provides it.
                IEnumerable<HSP> result =  searchCntrl.GetProviders(service);
                foreach (HSP found in result)
                {
                    Boolean isIn = false;
                    foreach (DataGridViewRow row in searchHSPResult.Rows)   //this loop is to check if an HSP is already in the DGV
                    {                                                       //If it is, it is not put in
                        if (row.Cells[0].Value != null)
                        {
                            if (row.Cells[0].Value.ToString() == found.Name)
                            {
                                isIn = true;
                                break;
                            }
                        }
                    }
                    if (!isIn)
                    {
                        searchHSPResult.Rows.Add(found.Name, found.Address);
                    }
                }
            }
        }

        //This method populates the benefit list box with all services in the given plan
        private void planList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (planList.SelectedItem != null)
            {
                var plan = searchCntrl.GetPlan(planList.SelectedItem.ToString());
                benefitListBox.Items.Clear();
                foreach (var item in plan.ServiceCosts)
                {
                    benefitListBox.Items.Add(item.Name);
                }
                benefitListBox.Visible = true;
            }
        }
    }
}
