using System;
using System.Windows.Forms;
using CoreProject.Controller.EnrolleeControllers;
using CoreProject.Data.Enrollee;

namespace CoreProject.Present
{
    /// <summary>
    /// A form that the user fills out to enroll in an insurance plan 
    /// </summary>
    public partial class PrimaryEnroll : Form
    {
        public EnrollController EnrollCtrl { get; }
        public Enrollee Type { get; set; }

        /// <summary>
        /// The base constructor. It initializes the gui and sets the
        /// EnrollCtrl to the provided Controller.
        /// </summary>
        /// <param name="enrollCtrl"></param>
        public PrimaryEnroll( EnrollController enrollCtrl )
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
        public PrimaryEnroll( EnrollController enrollCtrl, string failMessage ) : this(enrollCtrl)
        {
            this.errMsg.Text = failMessage;
            this.errMsg.Visible = true;
        }

        #region PersonalInfo
        /// <summary>
        /// Check if SSN is valid and cycle to the next page if so 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Next_Click( object sender, EventArgs e )
        {
            var validSSN = this.EnrollCtrl.CheckSSN(this.SSN.Text);

            if ( validSSN && this.firstName.Text != "" && 
                 this.lastName.Text != "" && this.mailingAddr.Text != "" )
            {
                // go the next part of the form 
                contactPage.Visible = true;
                this.homePhone.Focus();
            }
            else
            {
                this.Hide();
                var errForm = new PrimaryEnroll(this.EnrollCtrl, 
                    validSSN ? "You didn't submit required fields" : 
                               "Invalid Social Security Number");
                // close this form when the child form is closed -> creates a closing chain
                errForm.Closed += (s, args) => this.Close();
                errForm.Show();
            }
        }
        #endregion

        #region ContactInfo
        /// <summary>
        /// Goes back to the previous (main) page from the contact page 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toPersonal_Click( object sender, EventArgs e )
        {
            contactPage.Visible = false;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            var contactInfo = this.EnrollCtrl.NewContact(
                this.homePhone.Text, 
                this.mobilePhone.Text, 
                this.email.Text
            );

            bool goodInfo = this.EnrollCtrl.VerifyContact(ref contactInfo);

            if ( goodInfo && this.pin.Text != "" )
            {
                this.EnrollCtrl.CreatePrimaryEnrollee(
                    this.firstName.Text,
                    this.lastName.Text,
                    this.SSN.Text,
                    this.mailingAddr.Text,
                    this.billingAddr.Text,
                    this.pin.Text,
                    contactInfo
                );
                var planIdentifiers = this.EnrollCtrl.ShowPlans();
                foreach ( var plan in planIdentifiers )
                {
                    plans.Items.Add(plan);
                }
                planView.Visible = true;
            }
            else
            {
                // show error message
                this.contactErr.Text = @"Error: " + (contactInfo.errMsg ?? @"A pin is required");
                this.contactErr.Visible = true;
            }
        }
        #endregion

        #region PickPlan
        /// <summary>
        /// display the details of an insurance plan in a tabular format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plans_SelectedItemChanged(object sender, EventArgs e)
        {
            if (planDetails.Rows.Count > 1)
            {
                planDetails.Rows.Clear();
            }
            var planIdentifier = (string) plans.SelectedItem;
            var planServices = EnrollCtrl.ShowPlanDetails(planIdentifier);

            foreach (var service in planServices)
            {
                planDetails.Rows.Add(
                    service.Name, 
                    service.PercentCoverage, 
                    service.RequiredCopayment
                );
            }
            planDetails.Visible = true;
        }
        /// <summary>
        /// attaches an the user to the plan on the backend and sends back a 
        /// confirmation message 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void planPick_Click(object sender, EventArgs e)
        {
            var planIdentifier = (string) plans.SelectedItem;
            var plan = this.EnrollCtrl.PickPlan(planIdentifier);
            var customer = this.EnrollCtrl.GetName();
            this.confirmation.Text = $"Congratulations {customer} your plan is: {plan}";
            this.finish.Visible = true;
        }
        #endregion

        /// <summary>
        /// The final panel is complete so the form is finished 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
