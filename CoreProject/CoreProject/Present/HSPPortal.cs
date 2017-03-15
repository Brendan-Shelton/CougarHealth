using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreProject.Present
{
    public partial class HSPPortal : Form
    {
        public HSPPortal()
        {
            InitializeComponent();
        }

        private void createAccount_Click(object sender, EventArgs e)
        {
            // HSP create account goes here
        }

        private void submitBill_Click(object sender, EventArgs e)
        {

            var portal = new Billing(new Controller.HSPControllers.BillController());
            portal.Show();
        }
    }
}
