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
    /// <summary>
    /// A form that the user fills out to enroll in an insurance plan 
    /// </summary>
    public partial class Enroll : Form
    {
        public EnrollController EnrollCtrl { get; }

        /// <summary>
        /// The base constructor. It initializes the gui and sets the
        /// EnrollCtrl to the provided Controller.
        /// </summary>
        /// <param name="enrollCtrl"></param>
        public Enroll(EnrollController enrollCtrl)
        {
            this.EnrollCtrl = enrollCtrl;
            InitializeComponent();
            this.errMsg.Visible = false;
        }

        /// <summary>
        /// The constructor that is called when there was a failure in creating
        /// the enrollee previously 
        /// </summary>
        /// <param name="enrollCtrl"></param>
        /// <param name="failMessage"></param>
        public Enroll(EnrollController enrollCtrl, string failMessage) : this(enrollCtrl)
        {
            this.errMsg.Text = failMessage;
            this.errMsg.Visible = true;
        }

        /// <summary>
        /// Check if SSN is valid and cycle to the next page if so 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Next_Click(object sender, EventArgs e)
        {
            if (this.EnrollCtrl.CheckSSN(this.SSN.Text))
            {
                // go the next part of the form 
                contactPage.Visible = true;
                this.homePhone.Focus();
            }
            else
            {
                this.Hide();
                var errForm = new Enroll(this.EnrollCtrl, "Invalid Social Security Number");
                // close this form when the child form is closed -> creates a closing chain
                errForm.Closed += (s, args) => this.Close();
                errForm.Show();
            }
        }

        private void toPersonal_Click(object sender, EventArgs e)
        {
            contactPage.Visible = false;
        }
    }
}
