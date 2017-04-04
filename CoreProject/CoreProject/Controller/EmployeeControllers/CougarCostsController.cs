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

        public DbMgr dbmgr { get; private set; }
        private IEnumerable<InsurancePlan> Plans { get; }
        public CougarCostsController()
        {
            this.dbmgr = DbMgr.Instance;
            this.Plans = dbmgr.GetPlans();
        }
        

        public IEnumerable<InsurancePlan> GetPlans()
        {
            return Plans;
        }

        public InsurancePlan GetPlan(String name)
        {
            return dbmgr.GetPlanByType(name);
        }

        public double GetNum(string name, string type, bool isPercent, bool isMaxPay)
        {
            var plan = dbmgr.GetPlanByType(type);
            double retVal = 0;

            switch (name)
            {
                case "Plan Year Max Benefit": retVal = plan.PYMB;
                    break;
                case "Out of Pocket Maximum Per Enrollee": retVal = plan.OPMIndividual;
                    break;
                case "Out of Pocket Maximum Per Family": retVal = plan.OPMFamily;
                    break;
                case "Annual Plan Deductable": retVal = plan.APD;
                    break;
                case "Primary Enrollee Fee": retVal = plan.PrimaryFee;
                    break;
                case "Primary Enrollee Change Fee": retVal = plan.PrimaryChangeFee;
                    break;
                case "Dependent Enrollee Fee": retVal = plan.DependentFee;
                    break;
                case "Dependent Enrollee Change Fee": retVal = plan.DependentChangeFee;
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
                            else if( isMaxPay)
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

            return retVal;
        }

        //replace with a more universal approach (ability for more than 2 plans)
        public void Update(InsurancePlan plan, string type, string name, bool percent, bool max, double val)
        {

            switch (name)
            {
                case "Plan Year Max Benefit":
                    dbmgr.adminUpdateVerify(1234, plan.Id, "Benefits", "PYMB", percent, max, val);
                    break;
                case "Out of Pocket Maximum Per Enrollee":
                    dbmgr.adminUpdateVerify(1234, plan.Id, "Benefits", "OPMIndividual", percent, max, val);
                    break;
                case "Out of Pocket Maximum Per Family":
                    dbmgr.adminUpdateVerify(1234, plan.Id, "Benefits", "OPMFamily", percent, max, val);
                    break;
                case "Annual Plan Deductable":
                    dbmgr.adminUpdateVerify(1234, plan.Id, "Benefits", "APD", percent, max, val);
                    break;
                case "Primary Enrollee Fee":
                    dbmgr.adminUpdateVerify(1234, plan.Id, "Benefits", "PrimaryFee", percent, max, val);
                    break;
                case "Primary Enrollee Change Fee":
                    dbmgr.adminUpdateVerify(1234, plan.Id, "Benefits", "PrimaryChangeFee", percent, max, val);
                    break;
                case "Dependent Enrollee Fee":
                    dbmgr.adminUpdateVerify(1234, plan.Id, "Benefits", "DependentFee", percent, max, val);
                    break;
                case "Dependent Enrollee Change Fee":
                    dbmgr.adminUpdateVerify(1234, plan.Id, "Benefits", "DependentChangeFee", percent, max, val);
                    break;
                default:
                    for (int i = 0; i < plan.ServiceCosts.Length; i++)
                    {
                        if (plan.ServiceCosts[i].Name.Equals(name))
                        {
                            if (percent)
                            {
                                dbmgr.adminUpdateVerify(1234, plan.Id, "", plan.ServiceCosts[i].Name, percent, max, val);
                            }
                            else if (max)
                            {
                                dbmgr.adminUpdateVerify(1234, plan.Id, "", plan.ServiceCosts[i].Name, percent, max, val);
                            }
                            else
                            {
                                dbmgr.adminUpdateVerify(1234, plan.Id, "", plan.ServiceCosts[i].Name, percent, max, val);
                            }
                        }
                    }
                    break;
            }
           
        }
    }
}
