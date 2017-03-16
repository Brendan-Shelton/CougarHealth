using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.Enrollee
{
    public class EnrolleePlan 
    {
        public int PlanNum { get; set; }
        public string Type { get; }
        /* 
         * all of the following properties are privately set because they are 
         * set on charge
         */
        public double PYMBRemainder { get; private set; }
        public double OPMRemainder { get; private set; }
        public double APDRemainder { get; private set; }
        public List<double> Charges { get; private set; }
        public double TotalCost { get; private set; }
        private List<int> _dependents;
        private List<double> _dependentOPMs;
        /// <summary>
        /// list of primary keys of the dependent enrollees
        /// </summary>
        public List<int> Dependents
        {
            get { return _dependents; }
            private set
            {
                if (PrimaryEnrollee == null)
                {
                    throw new ArgumentException(
                        "Primary enrollee should be attached before adding dependents"
                    );
                }

                _dependentOPMs = new List<double>();
                for (int i = 0; i < value.Count; i++)
                {
                    _dependentOPMs.Add(0); 
                }

                _dependents = value;
            }
        }

        private static int idCount = 0;

        /// <summary>
        /// the primary key of the primary enrollee
        /// </summary>
        public int? PrimaryEnrollee { get; } = null;

        public EnrolleePlan( PrimaryEnrollee primary, InsurancePlan plan )
        {
            // identifiers
            this.PrimaryEnrollee = primary.Id;
            this.Type = plan.Type;
            this.PlanNum = ++idCount;

            this.Dependents = new List<int>();
            // start at the top of the plan 
            this.PYMBRemainder = plan.PYMB;
            this.APDRemainder = plan.APD;
            this.OPMRemainder = plan.OPMFamily;
        }

        public void AddDependent( DependentEnrollee enrollee )
        {
            
        }

        public void AddCharge(double charge)
        {
            
        }

        /// <summary>
        /// this and that are equal if they have the same primary enrollee 
        /// primary enrollees can't  have more than one plan 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var that = (EnrolleePlan) obj;
            return this.PrimaryEnrollee == that.PrimaryEnrollee;
        }

        /// <summary>
        /// return the primary key of the primary enrollee 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if ( PrimaryEnrollee == null )
            {
                throw new ArgumentException("Primary enrollee does not exists");
            }
            return PrimaryEnrollee.Value;
        }

    }
}
