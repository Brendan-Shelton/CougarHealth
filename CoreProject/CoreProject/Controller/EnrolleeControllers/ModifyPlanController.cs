using CoreProject.Data;
using CoreProject.Data.Enrollee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Controller.EnrolleeControllers
{
    public class ModifyPlanController
    {
        public DbMgr Mgr { get; set; } = DbMgr.Instance;
        public EnrolleePlan CurrentPlan { get; set; }
        /// <summary>
        /// the plans given by the database. Previously we identified by primary
        /// enrollee id, but since a primary enrollee can have multiple plans 
        /// we have to have them pick one. 
        /// </summary>
        public IEnumerable<EnrolleePlan> AvailablePlans { get; private set; } = null;

        /// <summary>
        /// Array of columns in data row with the corresponding field names 
        /// from InsurancePlan
        /// </summary>
        public Tuple<string, string>[] ComparedBenefits => new Tuple<string, string>[] 
        {
            Tuple.Create("Plan Name", "Type"),
            Tuple.Create("Plan Year Maximum Benefit", "PYMB"),
            Tuple.Create("Annual Plan Deductible", "APD"),
            Tuple.Create("Out of Pocket Maximum Family", "OPMFamily"),
            Tuple.Create("Out of pocket Maximum Individual", "OPMIndividual"),
            Tuple.Create("Primary Enrollee Rate", "PrimaryFee"),
            Tuple.Create("Dependent Rate", "DependentFee"),
            Tuple.Create("Change to Fee", "PrimaryChangeFee"),
            Tuple.Create("Dependent Change to Fee", "DependentChangeFee")
        };

        /// <summary>
        /// Whether the enrollee has multiple plans 
        /// </summary>
        public bool MultiplePlans {
            get
            {
                return this.AvailablePlans == null ||
                    this.AvailablePlans.Count() > 0;
            }
        }

        public ModifyPlanController( int EnrolleeId)
        {
            this.AvailablePlans = Mgr.GetPlanByPrimary(EnrolleeId);
        }

        public void PickPlan( int planNum )
        {
            this.CurrentPlan = this.AvailablePlans
                .Where(p => p.PlanNum == planNum)
                .SingleOrDefault();
        }

        /// <summary>
        /// Get all the Plan options available by displaying their Type 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> PlanOptions ()
        {
            return Mgr.GetPlans().Select((plan) => plan.Type);
        }

        /// <summary>
        /// Get the details of a plan that a user selected 
        /// </summary>
        /// <param name="type">Selected plan</param>
        /// <returns></returns>
        public InsurancePlan PlanDetails ( string type )
        {
            return Mgr.GetPlanByType(type);
        }

        /// <summary>
        /// Get the names of the benefits we are comparing 
        /// </summary>
        /// <returns></returns>
        public string[] BenfitsCompared()
        {
            return ( from benefit in ComparedBenefits
                     select benefit.Item1 ).ToArray();

        }
        
        /// <summary>
        /// Prints the values of all properties in the Insurance plan type 
        /// </summary>
        /// <param name="plan"></param>
        /// <returns></returns>
        public string[] PrintPlanValues (InsurancePlan plan)
        {
            var planValues = new List<string>();
            var insuranceType = typeof(InsurancePlan);
            foreach ( Tuple<string, string> benefit in this.ComparedBenefits )
            {
                // use reflection to get the value of the property we are looking at
                string benefitValueStr;
                if ( benefit.Item2 != "Type" )
                {
                    var fieldValue = (double)insuranceType
                        .GetProperty(benefit.Item2)
                        .GetValue(plan);
                    benefitValueStr = fieldValue.ToString("C0"); 
                }
                else
                {
                    benefitValueStr = (string) insuranceType
                        .GetProperty(benefit.Item2)
                        .GetValue(plan);
                }
                planValues.Add(benefitValueStr);
            }
            return planValues.ToArray();
        }

        public InsurancePlan CurrentDetails()
        {
            if ( !this.MultiplePlans )
            {
                return Mgr.GetPlanByType(CurrentPlan.Type);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Change the enrollee's plan to the new Plan that they selected. 
        /// </summary>
        /// <param name="change"></param>
        public void ChangeCurrent ( InsurancePlan change )
        {
            if ( !MultiplePlans )
            {
                this.CurrentPlan.ChangeTo(change);
                Mgr.SaveEnrolleePlan(this.CurrentPlan);
            }
        }
    }
}
