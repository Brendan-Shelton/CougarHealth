using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.HealthcareServiceProvider;
using CoreProject.Controller.EnrolleeControllers;

namespace CoreProject.Data.Enrollee
{
    public class EnrolleePlan 
    {
        public PlanController planCtrl { get; private set; }
        public int PlanNum { get; set; }
        public string Type { get; }
        /* 
         * all of the following properties are privately set because they are 
         * set on charge
         */
        public double PYMBRemainder { get; private set; }
        public double OPMFRemainder { get; private set; }
        public double OPMIRemainder { get; private set; }
        public double APDRemainder { get; private set; }
        public List<Bill> Charges { get; private set; }
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
            this.planCtrl = new PlanController(primary.Id);
            this.Dependents = new List<int>();
            this.Charges = new List<Bill>();
            // start at the top of the plan 
            this.PYMBRemainder = plan.PYMB;
            this.APDRemainder = plan.APD;
            this.OPMFRemainder = plan.OPMFamily;
            this.OPMIRemainder = plan.OPMIndividual;
        }

        public void AddDependent( DependentEnrollee enrollee )
        {
            
        }

        public void AddCharge(DateTime date, HSP hsp, Service service, int enrolleeId, double totalBillAmount, double enrolleeBillAmount)
        {
            var bill = new Bill(date, hsp, service, enrolleeId, totalBillAmount, enrolleeBillAmount);
            Charges.Add(bill);
            APDRemainder -= enrolleeBillAmount;
            if (APDRemainder < 0)
                APDRemainder = 0;
            PYMBRemainder -= (totalBillAmount - enrolleeBillAmount);

            if (OPMIRemainder !=0 && OPMFRemainder !=0)
            {
                if (OPMIRemainder < enrolleeBillAmount)
                {
                    TotalCost += OPMIRemainder;
                } else if (OPMFRemainder < enrolleeBillAmount)
                {
                    TotalCost += OPMFRemainder;
                } else
                    TotalCost += (enrolleeBillAmount);
            }

            OPMIRemainder -= (totalBillAmount - enrolleeBillAmount);
            if (OPMIRemainder < 0)
            {
                OPMIRemainder = 0;
            }

            OPMFRemainder -= (totalBillAmount - enrolleeBillAmount);
            if (OPMFRemainder < 0)
            {
                OPMFRemainder = 0;
            }

            
            planCtrl.addBill(bill);
            
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
