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
    public partial class DependentEnroll : Form
    {
        public EnrollController EnrollCtrl { get; set; }
        private int _primaryId;
        public DependentEnroll( int primary )
        {
            this._primaryId = primary;
            EnrollCtrl = new EnrollController();
            InitializeComponent();
        }

        private DependentEnroll(EnrollController enrollCtrl, string failMsg)
        {
            this.errMsg.Text = failMsg;
            this.errMsg.Visible = true;
        }

        private void personNext_Click(object sender, EventArgs e)
        {
            var validSSN = this.EnrollCtrl.CheckSSN(this.ssn.Text);

            if (validSSN && this.firstName.Text != "" &&
                this.lastName.Text != "" && this.relationship.Text != "")
            {
                this.contactForm.Visible = true;
                this.primaryPhone.Focus();
            }
            else
            {
                this.Hide();
                var errForm = new DependentEnroll(this.EnrollCtrl, 
                    validSSN ? "You didn't submit required fields" : 
                               "Invalid Social Security Number");
                // close this form when the child form is closed -> creates a closing chain
                errForm.Closed += (s, args) => this.Close();
                errForm.Show();
            }
        }

        private void DependentEnroll_Load(object sender, EventArgs e)
        {
            this.relationship.Items.AddRange(EnrollCtrl.Relationships);
            this.firstName.Focus();
        }

        private void previous_Click(object sender, EventArgs e)
        {
            this.contactForm.Visible = false;
        }

        private void toFinish_Click(object sender, EventArgs e)
        {
            var contact = this.EnrollCtrl.NewContact(
                primaryPhone.Text,
                secondaryPhone.Text,
                email.Text
            );

            var contactCheck = this.EnrollCtrl.VerifyContact(ref contact);

            if ( contactCheck && this.pin.Text != "" )
            {
                var planNum = this.EnrollCtrl.CreateDependent(
                    this._primaryId,
                    this.firstName.Text,
                    this.lastName.Text,
                    this.ssn.Text,
                    this.relationship.SelectedText,
                    this.pin.Text,
                    contact
                );

                var success = $"You have added ${this.firstName.Text} to ${planNum}";
                successMsg.Text = success;
                successMsg.Visible = true;
                this.confirmPane.Visible = true;
            }
            else
            {
                // show error message
                this.errMsg.Text = @"Error: " + (contact.errMsg ?? @"A pin is required");
                this.errMsg.Visible = true;
            }
        }

        private void contactForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void done_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
