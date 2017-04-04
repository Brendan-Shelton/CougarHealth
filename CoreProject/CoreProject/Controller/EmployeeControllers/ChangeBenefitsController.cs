using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;

namespace CoreProject.Controller.EmployeeControllers
{
    class ChangeBenefitsController
    {
        /// <summary>
        /// Adds a benefit to the selected plan
        /// </summary>
        /// <param name="plan"></param>
        /// <param name="name"></param>
        /// <param name="cat"></param>
        /// <param name="percent"></param>
        /// <param name="copay"></param>
        /// <param name="maxPay"></param>
        public void AddBenefit(InsurancePlan plan, String name, String cat, double percent, int copay, int maxPay)
        {
            // add benefit to services -- may not be possible with current data structure?   
        }
        /// <summary>
        /// Removes a benefit from the selected plan
        /// </summary>
        /// <param name="plan"></param>
        /// <param name="name"></param>
        public void RemoveBenefit(InsurancePlan plan, String name)
        {
            // find the benefit in services, then remove it
        }
    }
}
