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
    public partial class Invoice : Form
    {
        public Invoice(String[,] arr)
        {
            InitializeComponent();
            int count = 0;

            Label[] labelArr = new Label[4];
            labelArr[0] = new Label();
            labelArr[0].Text = "Service: ";
            labelArr[1] = new Label();
            labelArr[1].Text = "Adjusted Amount: ";
            labelArr[2] = new Label();
            labelArr[2].Text = "Enrollee Pays: ";
            labelArr[3] = new Label();
            labelArr[3].Text = "Cougar Health Pays: ";
            for (int i = 0; i < arr.Length / 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    labelArr[0] = new Label();
                    labelArr[0].Text = "Service: ";
                    labelArr[1] = new Label();
                    labelArr[1].Text = "Adjusted Amount: ";
                    labelArr[2] = new Label();
                    labelArr[2].Text = "Enrollee Pays: ";
                    labelArr[3] = new Label();
                    labelArr[3].Text = "Cougar Health Pays: ";

                    Label label2 = new Label();
                    label2.Text = arr[i, j];
                    labelArr[j].Left = 10;
                    label2.Left = 120;
                    labelArr[j].Top = (++count + 1) * 22;
                    label2.Top = (count + 1) * 22;

                    this.Controls.Add(labelArr[j]);
                    this.Controls.Add(label2);
                }
                
            }


            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        
    }
}
