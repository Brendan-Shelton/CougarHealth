using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreProject.Controller.EmployeeControllers;

namespace CoreProject.Present
{
    public partial class MonthlyReport : Form
    {
        public MonthReportController mthCtrl { get; private set; }

        public MonthlyReport(MonthReportController monthCtrllr) {

            mthCtrl = monthCtrllr;
            InitializeComponent();
        }
    }
}
