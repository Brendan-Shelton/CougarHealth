using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.Enrollee
{
    public class InsurancePlan
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double PYMB { get; set; }
        public double APD { get; set; }
        public double OPMIndividual { get; set; }
        public double OPMFamily { get; set; }
        public double PrimaryFee { get; set; }
        public double DependentFee { get; set; }
        public double PrimaryChangeFee { get; set; }
        public double DependentChangeFee { get; set; }
        public Service[] ServiceCosts { get; set; }
    }
}
