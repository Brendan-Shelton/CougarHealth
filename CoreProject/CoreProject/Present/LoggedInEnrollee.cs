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
        private bool _isPrimary;
        private String _email;
        public LoggedInEnrollee(int primary, String email, bool isPrimary)
        {
            this._primaryId = primary;
            this._isPrimary = isPrimary;
            this._email = email;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dependentForm = new DependentEnroll(this._primaryId, this._isPrimary);
            dependentForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var enrollPlanCtrl = new PlanController(_primaryId, _email, this._isPrimary);
            var enrolleeCostsGUI = new EnrolleeCosts(enrollPlanCtrl);
            enrolleeCostsGUI.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new ModifyPlan(_primaryId, _isPrimary);
            form.Show();
        }

        private void LoggedInEnrollee_Load(object sender, EventArgs e)
        {
            if ( !_isPrimary )
            {
                // disable all primary actions Modify plan and add dependent 
                this.button2.Visible = false;
                this.button3.Visible = false;
            }
        }
    }
}
