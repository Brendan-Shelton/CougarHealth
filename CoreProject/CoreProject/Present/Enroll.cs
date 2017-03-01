using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreProject.Controller.EnrolleeControllers;

namespace CoreProject.Present
{
    public partial class Enroll : Form
    {
        public EnrollController EnrollCtrl { get; private set; }
        public Enroll( EnrollController enrollCtrl )
        {
            this.EnrollCtrl = enrollCtrl;
            InitializeComponent();
        }


    }
}
