using CoreProject.Controller.EmployeeControllers;
using CoreProject.Data.Employees;
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
    public partial class CreateEmployee : Form
    {
        public CreateEmployeeController Ctrl { get; set; }
        public CreateEmployee()
        {
            this.Ctrl = new CreateEmployeeController();
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                int newId = Ctrl.Create(
                    this.Username.Text,
                    this.Password.Text,
                    this.RepeatPass.Text,
                    this.Permission.Text
                );
                DialogResult dialog = MessageBox.Show(
                    $"Success Employee Id: {newId}", "", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                
                if ( dialog == DialogResult.OK )
                {
                    this.Close();
                }

            }
            catch ( CreationException ex )
            {
                DialogResult result = MessageBox.Show(
                    ex.Description,
                    "Cannot Create Account",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                
                if ( result == DialogResult.OK)
                {
                    this.Focus();
                }
            }
            catch ( DataException )
            {
                DialogResult result = MessageBox.Show(
                    "Duplicate Employee",
                    "The employee you just entered has the same username "+
                    "as another employee",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                
                if ( result == DialogResult.OK)
                {
                    this.Focus();
                }
            }

        }
    }
}
