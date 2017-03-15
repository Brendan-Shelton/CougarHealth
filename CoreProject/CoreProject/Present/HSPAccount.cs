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
    }
}
