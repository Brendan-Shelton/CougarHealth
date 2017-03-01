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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Open the enrollment gui to allow the client to enroll in an insurance plan 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enroll_Click(object sender, EventArgs e)
        {

            var enrollCtrl = new EnrollController();
            var enrollGui = new Enroll(enrollCtrl);
            enrollGui.Show();
        }
    }
}
