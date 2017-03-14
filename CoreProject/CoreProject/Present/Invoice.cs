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
    public partial class Invoice : Form
    {
        public Invoice(double[,] arr)
        {
            InitializeComponent();

            this.label4.Text = arr[0, 0].ToString();
            this.label5.Text = arr[0, 1].ToString();
            this.label6.Text = arr[0, 2].ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        
    }
}
