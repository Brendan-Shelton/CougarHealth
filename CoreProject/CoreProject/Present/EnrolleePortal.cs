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

namespace CoreProject.Present
{
    public partial class EnrolleePortal : Form
    {
        public EnrolleePortal()
        {
            InitializeComponent();
        }

        private void enroll_Click(object sender, EventArgs e)
        {

            var enrollCtrl = new EnrollController();
            var enrollGui = new PrimaryEnroll(enrollCtrl);
            enrollGui.Show();
        }

        private void dependent_Click(object sender, EventArgs e)
        {
            var depedentGUI = new Login(typeof(DependentEnroll));
            depedentGUI.Show();
        }


        private void ModifyPlan_Click(object sender, EventArgs e)
        {
            var modifyGUI = new Login(typeof(ModifyPlan));
            modifyGUI.Show();
        }
    }
}
