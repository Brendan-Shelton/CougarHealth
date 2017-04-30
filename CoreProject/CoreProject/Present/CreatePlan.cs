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
    public partial class CreatePlan : Form
    {
        public CreatePlanController CreateCtrl { get; set; }
        List<Service> services = new List<Service>();
        public CreatePlan()
        {
            CreateCtrl = new CreatePlanController();
            InitializeComponent();
        }

        private void addServiceButton_Click(object sender, EventArgs e)
        {
            // Add the service to the listbox and refresh the listbox
            Service s = null;
            if(maxPayRateComboBox.SelectedItem != null)
            {
                s = CreateCtrl.AddService(serviceNameTextbox.Text, serviceCatTextbox.Text, Convert.ToDouble(copayNumeric.Value),
                                  Convert.ToDouble(percentNumeric.Value), Convert.ToDouble(maxNumeric.Value), maxPayRateComboBox.SelectedItem.ToString());
            }
            
            
            if (s != null)
            {
                services.Add(s);
                serviceListbox.Items.Add(s.Name.ToString());
                serviceListbox.Refresh();
            }
            // Name has been set to ERROR meaning the service was not successfully created
            else
            {
                MessageBox.Show("Error adding service!");
            }
            
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            // submit all of the information for processing/checking, returns a bool
            if(CreateCtrl.CreatePlan(planNameTextbox.Text, Convert.ToDouble(PYMBNumeric.Value), Convert.ToDouble(APDNumeric.Value), Convert.ToDouble(OPMINumeric.Value), Convert.ToDouble(OPMFNumeric.Value),
                                  Convert.ToDouble(primaryNumeric.Value), Convert.ToDouble(dependentNumeric.Value), Convert.ToDouble(primaryChangeNumeric.Value), Convert.ToDouble(dependentChangeNumeric.Value),
                                  optionalCheckbox.Checked, services))
            {
                MessageBox.Show("Successfully added plan!");
            }
            else
            {
                MessageBox.Show("Error adding plan!");
            }
        }

        private void CreatePlan_Load(object sender, EventArgs e)
        {

        }
    }
}
