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

namespace CoreProject.Present
{
    public partial class LoggedInEnrollee : Form
    {

        public PlanController planCtrl { get; private set; }
        private int _primaryId;
        public LoggedInEnrollee(int primary)
        {
            this._primaryId = primary;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dependentForm = new DependentEnroll(_primaryId);
            dependentForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var enrollPlanCtrl = new PlanController(_primaryId);
            var enrolleeCostsGUI = new EnrolleeCosts(enrollPlanCtrl);
            enrolleeCostsGUI.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new ModifyPlan(_primaryId);
            form.Show();
        }
    }
}
