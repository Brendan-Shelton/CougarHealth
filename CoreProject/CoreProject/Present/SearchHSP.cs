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
    public partial class SearchHSP : Form
    {
        SearchController searchCntrl = new SearchController();
        public SearchHSP()
        {
            InitializeComponent();

            var plans = searchCntrl.GetPlans();
            foreach (var item in plans)
            {
                planList.Items.Add(item.Type);
            }

            benefitListBox.Items.Clear();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchHSPResult.Rows.Clear();
            searchHSPResult.Refresh();
            string[] selected = new string[benefitListBox.CheckedIndices.Count];
            for (int i = 0; i < benefitListBox.CheckedIndices.Count; i++)
            {
                selected[i] = benefitListBox.CheckedItems[i].ToString();
            }

            foreach (string service in selected)
            {
                IEnumerable<HSP> result =  searchCntrl.GetProviders(service);
                foreach (HSP found in result)
                {
                    Boolean isIn = false;
                    foreach (DataGridViewRow row in searchHSPResult.Rows)
                    {
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

        private void planList_SelectedIndexChanged(object sender, EventArgs e)
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
