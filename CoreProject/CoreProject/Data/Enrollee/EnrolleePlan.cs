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
        public readonly DateTime PCY = new DateTime(1979, 7, 1);
        public int PlanNum { get; set; }
        public InsurancePlan Plan { get; set; }
        /// <summary>
        /// DEPRECATED
        /// TODO: remove this property as we should be storing actual 
        /// InsurancePlans.
        /// </summary>
        public string Type { get; set; }
        /* 
         * all of the following properties are privately set because they are 
         * set on charge
         */
        public double PYMBRemainder { get; private set; }
        public double OPMFRemainder { get; private set; }
        public double OPMIRemainder { get; private set; }
        public double APDRemainder { get; private set; }
       
        /// <summary>
        /// A enrollee can only change once per PCY if this is the same year 
        /// then the enrollee can't change the plan. Is set to null if never 
        /// changed
        /// </summary>
        public DateTime? LastChange { get; private set; }
        public List<Bill> Charges { get; set; }
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


        /// <summary>
        /// the primary key of the primary enrollee
        /// </summary>
        public int? PrimaryEnrollee { get; } = null;

        public EnrolleePlan( PrimaryEnrollee primary, InsurancePlan plan )
        {
            // identifiers
            this.PrimaryEnrollee = primary.Id;
            this.Type = plan.Type;
            this.Dependents = new List<int>();
            this.Charges = new List<Bill>();
            // start at the top of the plan 
            this.PYMBRemainder = plan.PYMB;
            this.APDRemainder = plan.APD;
            this.OPMFRemainder = plan.OPMFamily;
        }

        /// <summary>
        /// Database constructor 
        /// </summary>
        /// <param name="apdRemainder"></param>
        /// <param name="lastCharge"></param>
        /// <param name="totalCost"></param>
        /// <param name="opmRemainder"></param>
        /// <param name="pymbRemainder"></param>
        public EnrolleePlan( int pid, InsurancePlan plan,  
                             DateTime lastCharge, int planNum,
                             double totalCost, double opmRemainder, 
                             double pymbRemainder,  double apdRemainder)
        {
            this.Plan = plan;
            this.Type = plan.Type;
            this.PrimaryEnrollee = pid;
            this.PlanNum = planNum;
            this.APDRemainder = apdRemainder;
            this.LastChange = lastCharge;
            this.PYMBRemainder = pymbRemainder;
            this.APDRemainder = apdRemainder;
            this.TotalCost = totalCost;
            this.OPMFRemainder = opmRemainder;
            this.Charges = new List<Bill>();
            this.Dependents = new List<int>();
        }
        
        /// <summary>
        /// Change the insurance plan attached to this EnrolleePlan to 
        /// something different
        /// </summary>
        /// <param name="plan"></param>
        public void ChangeTo( InsurancePlan plan )
        {
            var now = DateTime.Now;
            // get current PCY 
            DateTime thisPCY;
            if (now.Month > 6)
            {
                thisPCY = new DateTime(now.Year, PCY.Month, PCY.Day);
            }
            else
            {
                thisPCY = new DateTime(now.Year - 1, PCY.Month, PCY.Day);
            }

            // changes can only be done once per PCY 
            if ( now.Month > 6 && LastChange?.Year == thisPCY.Year || 
                now.Month < 6 && LastChange?.Year == thisPCY.Year + 1 )
            {
                throw new ArgumentException("You can only change plans once per PCY");
            }
            this.OPMFRemainder = plan.OPMFamily;
            this.OPMIRemainder = plan.OPMIndividual;
        

            // throw an error if null insurance plan 
            if ( plan == null )
            {
                throw new NullReferenceException("The insurance plan selected can not be null");
            }
            // an enrollee can oly change their plan once per calender year
            this.Type = plan.Type;
            this.PYMBRemainder = plan.PYMB;
            this.APDRemainder = plan.APD;
            this.OPMFRemainder = plan.OPMFamily;
            // not the first month of the PCY, so there is a charge 
            if ( DateTime.Now.Month != PCY.Month )
            {
                // charge the primary change fee once and the dependent fee for
                // each dependent
                this.AddCharge(plan.PrimaryChangeFee);
                foreach ( int dependent in Dependents )
                {
                    this.AddCharge(plan.DependentChangeFee);
                }
            }
            this.LastChange = now;
        }
        public void AddDependent( DependentEnrollee enrollee )
        {
            Dependents.Add(enrollee.Id);
        }

        public void AddCharge(DateTime date, HSP hsp, Service service, int enrolleeId, String enrolleeEmail, double totalBillAmount, double enrolleeBillAmount)
        {
            this.planCtrl = new PlanController((int)PrimaryEnrollee, enrolleeEmail, true);
            var bill = new Bill(date, hsp.Id, service.Id, enrolleeId, enrolleeEmail, totalBillAmount, enrolleeBillAmount);
            Charges.Add(bill);
            APDRemainder -= enrolleeBillAmount;
            if (APDRemainder < 0)
                APDRemainder = 0;
            PYMBRemainder -= (totalBillAmount - enrolleeBillAmount);

            if (OPMIRemainder != 0 && OPMFRemainder != 0)
            {
                if (OPMIRemainder < enrolleeBillAmount)
                {
                    TotalCost += OPMIRemainder;
                }
                else if (OPMFRemainder < enrolleeBillAmount)
                {
                    TotalCost += OPMFRemainder;
                }
                else
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
