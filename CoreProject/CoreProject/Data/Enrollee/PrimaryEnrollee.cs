using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.Enrollee
{
    public class PrimaryEnrollee: Enrollee
    {
        public PrimaryEnrollee() : base()
        {

        }
        public PrimaryEnrollee(string pin) : base(pin)
        {
        }
        
        /// <summary>
        /// optional for the enrollee to have
        /// </summary>
        public string BillingAddr { get; set; } = null;

        public override bool IsPrimary => true;

        public string MailingAddr { get; set; }
    }
}
