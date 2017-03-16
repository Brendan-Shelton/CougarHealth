using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreProject.Controller.HSPControllers;
using CoreProject.Data.HealthcareServiceProvider;

namespace CoreProject.Present
{
    public partial class HSPAccount : Form
    {
        public CreateHSPController HSPControl;
        public HSP hsp;
        public HSPAccount(CreateHSPController HSPControl)
        {
            this.HSPControl = HSPControl;
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs args)
        {
            List<string> servicesOffered = new List<string>();
            foreach (string item in this.ServicesOffered.SelectedItems)
                servicesOffered.Add(item);
            string address = this.Street.Text;
            CreateHSPController.BankInfo? info = null;

            if ( this.BankName.Text != "" &&
                 this.routingNum.Text != "" &&
                 this.accountNum.Text != "" )
            {
                info = new CreateHSPController.BankInfo
                {
                    Account = Int32.Parse(this.routingNum.Text),
                    Routing = Int32.Parse(this.routingNum.Text),
                    Name = this.BankName.Text
                }; 
            }

            try
            {
                var id = this.HSPControl.CreateHSP(
                    name: this.CompanyName.Text,
                    services: servicesOffered,
                    address: address,
                    phone: this.phoneNum.Text,
                    pin: this.pin.Text,
                    netowrkStatus: this.networkStatus.Checked,
                    info: info
                );

                this.thanks.Text = $@"Congratulations {this.CompanyName.Text} your id is {id}";
                this.finishPane.Visible = true;

            }
            catch ( ArgumentException e )
            {
                this.error.Text = @"Error " + e.Message;
                this.error.Visible = true;
            }
            catch ( DataException )
            {
                this.error.Text = $@"Error: {this.CompanyName.Text} already exist in the database";
                this.error.Visible = true;
            }
        }

        /// <summary>
        /// The client hsp is done creating their account 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void donezo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
