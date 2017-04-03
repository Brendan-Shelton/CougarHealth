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
    public partial class RemovePlan : Form
    {
        public RemovePlanController RemoveCtrl { get; }

        public RemovePlan(RemovePlanController RemoveCtrl)
        {
            this.RemoveCtrl = RemoveCtrl;
            InitializeComponent();

            var plans = RemoveCtrl.ShowPlans();
            foreach (var plan in plans)
            {
                planList.Items.Add(plan);
            }

        }

        

        private void submit_Click(object sender, EventArgs e)
        {
            //planList.SelectedItem.ToString()
            RemoveCtrl.Remove(planList.SelectedItem.ToString());
        }
    }
}
