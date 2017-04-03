using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
namespace CoreProject.Controller.EmployeeControllers
{
    public class RemovePlanController
    {
        // get the plans
        // find the selected plan
        // remove selected plan

        public DbMgr dbmgr { get; private set; }

        public RemovePlanController()
        {
            this.dbmgr = DbMgr.Instance;
        }
        /// <summary>
        /// Removes a plan given the plan name
        /// </summary>
        /// <param name="name">Name of plan</param>
        public void Remove(String name)
        {
            for (int i = 0; i < dbmgr.Plans.Count; i++)
            {
                if (dbmgr.Plans[i].Type.Equals(name))
                {
                    dbmgr.Plans.RemoveAt(i);
                }
            }
        }
    }
}
