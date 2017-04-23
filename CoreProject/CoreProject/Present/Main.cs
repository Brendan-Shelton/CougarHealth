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
            var portal = new EnrolleePortal();
            portal.Show();
            //portal.Closed += (source, args) => this.Close();
            //this.Hide();
        }

        private void hspForm_Click(object sender, EventArgs e)
        {
            var portal = new HSPPortal();
            portal.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var login = new EmployeeLogin();
            login.Show();
        }

        private void searchHSPButton_Click(object sender, EventArgs e)
        {
            var search = new SearchHSP();
            search.Show();
        }
    }
}
