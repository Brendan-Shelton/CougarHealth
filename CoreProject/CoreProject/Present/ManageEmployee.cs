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
    public partial class ManageEmployee : Form
    {
        public ManageEmployeeController Ctrl { get; set; }
        public string[] UserNames { get; set; }
        public Employee ToModify { get; set; }
        public ManageEmployee()
        {
            Ctrl = new ManageEmployeeController();
            InitializeComponent();
        }

        /// <summary>
        /// Load all usernames of employees into the Usermenu for the manager 
        /// to pick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageEmployee_Load(object sender, EventArgs e)
        {
            this.UserNames = this.Ctrl.EmployeeMenu().ToArray();
            this.UserMenu.Items.AddRange(UserNames);
            this.Permission.Items.AddRange(
                Employee.GetPermissions().Select(perm => perm.Item1).ToArray()
            );
        }

        /// <summary>
        /// Pick an individual employee to manage 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Select_Click(object sender, EventArgs e)
        {
            var user = this.UserNames[this.UserMenu.SelectedIndex];
            var emp = this.Ctrl.GrabInfo(user);
            this.ModifyWhom.Text += " " + user;
            this.Username.Text = user;
            this.ToModify = emp;
            
            // load string that correspond to the 
            Tuple<string, Permission>[] permissions = Employee.GetPermissions();
            int permIndex = Array.IndexOf( (from perm in permissions
                                  select perm.Item2).ToArray(), emp.Permission);
            this.Permission.SelectedIndex = permIndex;

            this.ModifyPanel.Visible = true;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                int successId = this.Ctrl.Modify(
                    this.Username.Text,
                    this.Password.Text,
                    this.RepeatPass.Text,
                    this.Permission.Text,
                    this.ToModify
                );
                DialogResult dialog = MessageBox.Show(
                    $"Success Employee \"{this.Username.Text}\" has been changed", "", 
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
                    "Cannot Modify Account",
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
                    "Employee provided does not exist in the database",
                    "Cannot Modify Account",
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
