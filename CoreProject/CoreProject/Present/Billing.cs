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

namespace CoreProject.Present
{
    public partial class Billing : Form
    {
        public BillController billControl { get; }
        public Billing Type { get; set; }
            
        public Billing(BillController billControl)
        {
            this.billControl = billControl;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String s = listBox1.SelectedItem.ToString();
            s += " - $" + numericUpDown1.Value.ToString();

            listView1.Items.Add(s);
            listView1.Update();
        }
    }
}
