using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.Enrollee
{
    public class DependentEnrollee: Enrollee
    {
        public string Relationship { get; set; }


        public override bool IsPrimary => false;
        public DependentEnrollee(): base()
        {

        }

        public DependentEnrollee( string pin): base(pin)
        {

        }
    }
}
