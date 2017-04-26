using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.Enrollee
{
    public class Service
    {
        public int Id { get; set; }
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

        public int insurancePlanId;

        /// <summary>
        /// default ctor
        /// </summary>
        public Service()
        {

        }

        /// <summary>
        /// Database constructor 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <param name="coverage"></param>
        /// <param name="maxPayRate"></param>
        /// <param name="inNetworkMax"></param>
        /// <param name="insurancePlan"></param>
        /// <param name="reqCopay"></param>
        public Service(
            int id, 
            string name, 
            string category, 
            double coverage,
            string maxPayRate, 
            double inNetworkMax,
            int insurancePlan, 
            double reqCopay 
        )
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.PercentCoverage = coverage;
            this.RequiredCopayment = reqCopay;
            this.InNetMax = Tuple.Create(
                inNetworkMax, 
                this.PayRateStr(maxPayRate)
            );
            this.insurancePlanId = insurancePlan;
        }

        /// <summary>
        /// get the enum member represented by the string
        /// </summary>
        /// <param name="maxPayRate"></param>
        /// <returns></returns>
        public MaxPayRate PayRateStr( string maxPayRate )
        {
            switch ( maxPayRate )
            {
                case "Day":
                    return MaxPayRate.Day;
                case "PCY":
                    return MaxPayRate.PCY;
                case "Session":
                    return MaxPayRate.Session;
                default:
                    throw new ArgumentException("Not a valid pay rate");
            }
        }
    }
}
