using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Present;
using CoreProject.Data.Enrollee;
namespace CoreProject.Controller.EmployeeControllers
{
    public class CougarCostsController
    {

        public DbMgr Mgr { get; private set; }
        private IEnumerable<InsurancePlan> Plans { get; }
        public CougarCostsController()
        {
            this.Mgr = DbMgr.Instance;
            this.Plans = Mgr.GetPlans();
        }
        
        /// <summary>
        /// Get all plans from Mgr
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InsurancePlan> GetPlans()
        {
            return Plans;
        }
        /// <summary>
        /// Get one plan from Mgr
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public InsurancePlan GetPlan(String name)
        {
            return Mgr.GetPlanByType(name);
        }
        /// <summary>
        /// Gets the number percent, max pay, or copayment
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="isPercent"></param>
        /// <param name="isMaxPay"></param>
        /// <returns></returns>
        public double GetNum(string name, string type, bool isPercent, bool isMaxPay)
        {
            var plan = Mgr.GetPlanByType(type);
            double retVal = 0;
            if(plan != null && !(isPercent && isMaxPay))
            {
                switch (name)
                {
                    case "Plan Year Max Benefit":
                        retVal = plan.PYMB;
                        break;
                    case "Out of Pocket Maximum Per Enrollee":
                        retVal = plan.OPMIndividual;
                        break;
                    case "Out of Pocket Maximum Per Family":
                        retVal = plan.OPMFamily;
                        break;
                    case "Annual Plan Deductible":
                        retVal = plan.APD;
                        break;
                    case "Primary Enrollee Fee":
                        retVal = plan.PrimaryFee;
                        break;
                    case "Primary Enrollee Change Fee":
                        retVal = plan.PrimaryChangeFee;
                        break;
                    case "Dependent Enrollee Fee":
                        retVal = plan.DependentFee;
                        break;
                    case "Dependent Enrollee Change Fee":
                        retVal = plan.DependentChangeFee;
                        break;
                    default:
                        for (int i = 0; i < plan.ServiceCosts.Length; i++)
                        {
                            if (plan.ServiceCosts[i].Name.Equals(name))
                            {
                                if (isPercent)
                                {
                                    retVal = plan.ServiceCosts[i].PercentCoverage;
                                }
                                else if (isMaxPay)
                                {
                                    retVal = plan.ServiceCosts[i].InNetMax.Item1;
                                }
                                else
                                {
                                    retVal = plan.ServiceCosts[i].RequiredCopayment;
                                }
                            }
                        }
                        break;
                }
            }
            

            return retVal;
        }

        /// <summary>
        /// Updates one cost at a time
        /// </summary>
        /// <param name="plan"></param>
        /// <param name="name"></param>
        /// <param name="percent"></param>
        /// <param name="max"></param>
        /// <param name="val"></param>
        public void Update(InsurancePlan plan, string name, bool percent, bool max, double val)
        {
            if(plan != null && val >= 0)
            {
                switch (name)
                {
                    case "Plan Year Max Benefit":
                        Mgr.adminUpdateVerify(1234, plan.Id, "Benefits", "PYMB", percent, max, val);
                        break;
                    case "Out of Pocket Maximum Per Enrollee":
                        Mgr.adminUpdateVerify(1234, plan.Id, "Benefits", "OPMIndividual", percent, max, val);
                        break;
                    case "Out of Pocket Maximum Per Family":
                        Mgr.adminUpdateVerify(1234, plan.Id, "Benefits", "OPMFamily", percent, max, val);
                        break;
                    case "Annual Plan Deductible":
                        Mgr.adminUpdateVerify(1234, plan.Id, "Benefits", "APD", percent, max, val);
                        break;
                    case "Primary Enrollee Fee":
                        Mgr.adminUpdateVerify(1234, plan.Id, "Benefits", "PrimaryFee", percent, max, val);
                        break;
                    case "Primary Enrollee Change Fee":
                        Mgr.adminUpdateVerify(1234, plan.Id, "Benefits", "PrimaryChangeFee", percent, max, val);
                        break;
                    case "Dependent Enrollee Fee":
                        Mgr.adminUpdateVerify(1234, plan.Id, "Benefits", "DependentFee", percent, max, val);
                        break;
                    case "Dependent Enrollee Change Fee":
                        Mgr.adminUpdateVerify(1234, plan.Id, "Benefits", "DependentChangeFee", percent, max, val);
                        break;
                    default:
                        for (int i = 0; i < plan.ServiceCosts.Length; i++)
                        {
                            if (plan.ServiceCosts[i].Name.Equals(name))
                            {
                                // checks bools and if true executes for that value
                                if (percent)
                                {
                                    // check for percent greater than 100%
                                    if(val <= 1)
                                    Mgr.adminUpdateVerify(1234, plan.Id, "", plan.ServiceCosts[i].Name, percent, max, val);
                                }
                                else if (max)
                                {
                                    Mgr.adminUpdateVerify(1234, plan.Id, "", plan.ServiceCosts[i].Name, percent, max, val);
                                }
                                else
                                {
                                    Mgr.adminUpdateVerify(1234, plan.Id, "", plan.ServiceCosts[i].Name, percent, max, val);
                                }
                            }
                        }
                        break;
                }
            }
            
           
        }
    }
}
