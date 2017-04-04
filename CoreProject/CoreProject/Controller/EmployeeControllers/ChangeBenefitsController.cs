using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;
using CoreProject.Data;

namespace CoreProject.Controller.EmployeeControllers
{
    public class ChangeBenefitsController
    {
        DbMgr mgr = DbMgr.Instance;
        /// <summary>
        /// Get a single plan from the DbMgr
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public InsurancePlan GetPlan(String name)
        {
            return mgr.GetPlanByType(name);
        }
        /// <summary>
        /// Get every plan from DbMgr
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InsurancePlan> GetPlans()
        {
            return mgr.GetPlans();
        }


        /// <summary>
        /// Adds a benefit to the selected plan
        /// </summary>
        /// <param name="plan"></param>
        /// <param name="name"></param>
        /// <param name="cat"></param>
        /// <param name="percent"></param>
        /// <param name="copay"></param>
        /// <param name="maxPay"></param>
        public void AddBenefit(InsurancePlan plan, String name, String cat, double percent, double copay, double maxPay)
        {
            //check that information is valid
            if (plan == null || name == "" || name == null || cat == null || percent < 0 || percent > 100 || maxPay < 0 || copay < 0)
            {
                // error
            }
            else
            {
                // add benefit to services
                plan.ServiceCosts.Add(new Service
                {
                    Category = cat,
                    Name = name,
                    PercentCoverage = (percent / 100),
                    RequiredCopayment = copay,
                    InNetMax = new Tuple<double, Service.MaxPayRate>(maxPay, Service.MaxPayRate.PCY)
                });
            }
            
            
        }
        /// <summary>
        /// Removes a benefit from the selected plan
        /// </summary>
        /// <param name="plan"></param>
        /// <param name="name"></param>
        public void RemoveBenefit(InsurancePlan plan, String name)
        {
            for (int i = 0; i < plan.ServiceCosts.Count(); i++)
            {
                if (plan.ServiceCosts[i].Name.Equals(name))
                {
                    plan.ServiceCosts.Remove(plan.ServiceCosts[i]);
                }

            }
            
        }
    }
}
