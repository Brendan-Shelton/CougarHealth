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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            // TODO: Still need to validate inputs and insert optional fields if they exist
            // Additionally, personnel info needs to be worked out.

            List<string> servicesOffered = new List<string>();
            foreach (String item in this.ServicesOffered.SelectedItems)
                servicesOffered.Add(item);
            String address = this.Street.Text + " " + this.City.Text + " " + this.State.Text + " " + this.Zip.Text;

            this.HSPControl.CreateHSP(
                this.CompanyName.Text,
                servicesOffered,
                address,
                this.Pin.Text);
        }
    }
}
