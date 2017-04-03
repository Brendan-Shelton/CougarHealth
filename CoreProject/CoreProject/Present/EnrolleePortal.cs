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
            var depedentGUI = new Login();
            depedentGUI.Show();
        }

        private void EnrolleeCostsButton_Click(object sender, EventArgs e)
        {
            var costsGUI = new EnrolleeCosts();
            costsGUI.Show();
        }
    }
}
