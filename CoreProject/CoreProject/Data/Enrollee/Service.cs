using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.Enrollee
{
    public class Service
    {
        public enum MaxPayRate
        {
            Day,
            PCY,
            Session 
        }
        public string Name { get; set; }
        public string Category { get; set; }

        private double _percentCoverage;
        public double PercentCoverage
        {
            get { return _percentCoverage; }
            set
            {
                if ( value > 1 || value < 0 )
                {
                    throw new ArgumentOutOfRangeException();
                }

                _percentCoverage = value;
            }
        }
        public double RequiredCopayment { get; set; }
        public Tuple<double, MaxPayRate> InNetMax { get; set; }
    }
}
