using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Data.Enrollee;
namespace CoreProject.Controller.EmployeeControllers
{
    public class RemovePlanController
    {
        // get the plans
        // find the selected plan
        // remove selected plan

        public DbMgr dbmgr { get; private set; }
        public IEnumerable<InsurancePlan> Plans { get; private set; }

        public RemovePlanController()
        {
            this.dbmgr = DbMgr.Instance;
            this.Plans = dbmgr.GetPlans();
        }

        /// <summary>
        /// Gets all plans from the Database and returns a array of 2-tuples that 
        /// have the primary key of the plan as item1 and the name of the plan as 
        /// item2
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ShowPlans()
        {
            var planIdentifiers = from plan in Plans select plan.Type;
            return planIdentifiers;
        }

        /// <summary>
        /// Removes a plan given the plan name
        /// </summary>
        /// <param name="name">Name of plan</param>
        public bool Remove(String name)
        {
            if (name == "" || name == null)
                return false;
            else
            {
                dbmgr.RemovePlan(name);
                return true;
            }
            
        }
    }
}
