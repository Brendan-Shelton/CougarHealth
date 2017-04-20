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
    public partial class CreatePlan : Form
    {
        public CreatePlan(CreatePlanController CreateCtrl)
        {
            InitializeComponent();
        }

        private void addServiceButton_Click(object sender, EventArgs e)
        {
            // Add the service to the listbox and refresh the listbox
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            // submit all of the information for processing/checking
        }
    }
}
