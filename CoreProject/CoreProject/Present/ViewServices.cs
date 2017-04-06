using CoreProject.Data.Enrollee;
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
    public partial class ViewServices : Form
    {
        public List<Service> Services { get; set; }
        public ViewServices(InsurancePlan plan)
        {
            this.Services = plan.ServiceCosts;
            InitializeComponent();
        }

        /// <summary>
        /// Add all services and their field values to the DataGridView 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewServices_Load(object sender, EventArgs e)
        {
            foreach ( var service in this.Services )
            {
                string per;
                switch (service.InNetMax.Item2)
                {
                    case Service.MaxPayRate.Day:
                        per = "/ day";
                        break;
                    case Service.MaxPayRate.PCY:
                        per = "/ Plan Coverage Year";
                        break;
                    case Service.MaxPayRate.Session:
                        per = "/ Visit";
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
                string inNetwork = service.InNetMax.Item1.ToString("C0");
                this.ServicesDisplayed.Rows.Add(
                    service.Name,
                    service.Category,
                    service.PercentCoverage.ToString("P"),
                    service.RequiredCopayment.ToString("C0"),
                    inNetwork + per
                );
            }
            this.ServicesDisplayed.AutoResizeColumns();
        }
    }
}
