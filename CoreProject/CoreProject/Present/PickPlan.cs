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
    public partial class PickPlan : Form
    {
        /// <summary>
        /// An enrollee has picked a plan 
        /// </summary>
        public event ChoiceHandler OnChoice;
        public PickPlanController Ctrl { get; set; } 

        public PickPlan()
        {
            InitializeComponent();
        }

        public PickPlan( int enrolleeId ) : this()
        {
            this.Ctrl = new PickPlanController();
            var choices = Ctrl.GetPlans(enrolleeId);
            this.plans.Items.AddRange(choices.ToArray());
        }

        /// <summary>
        /// pick a plan 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submit_Click(object sender, EventArgs e)
        {
            int planNum = this.Ctrl.PickPlan((string)this.plans.SelectedItem);
            if ( OnChoice != null )
            {
                OnChoice.Invoke(this, new ChoiceArgs(planNum));
            }
            this.Close();
        }
    }

    public delegate void ChoiceHandler( object source, ChoiceArgs e );

    public class ChoiceArgs: EventArgs
    {
        public int PlanNum { get; set; }
        public ChoiceArgs( int planNum )
        {
            this.PlanNum = planNum;
        }
    }
}
