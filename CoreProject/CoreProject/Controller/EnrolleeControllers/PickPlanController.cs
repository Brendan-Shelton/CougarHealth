using CoreProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreProject.Present
{
    public class PickPlanController
    {
        public DbMgr Mgr { get; set; } = DbMgr.Instance;

        public IEnumerable<string> GetPlans( int enrolleeId )
        {
            return Mgr.GetPlanByPrimary(enrolleeId)
                ?.Select(plan => $"{plan.Type} #{plan.PlanNum}");

        }

        public int PickPlan ( string planStr )
        {
            int hashStart = planStr.IndexOf('#');
            string hashValue = planStr.Substring(hashStart + 1);
            return Convert.ToInt32(hashValue);
        }
    }
}