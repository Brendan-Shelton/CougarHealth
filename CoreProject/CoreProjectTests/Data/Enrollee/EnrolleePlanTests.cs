using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Data.Enrollee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.Enrollee.Tests
{
    [TestClass()]
    public class EnrolleePlanTests
    {
        public DbMgr Mgr { get; set; } = DbMgr.Instance;
        [TestMethod()]
        public void ChangeToTest()
        {
            EnrolleePlan plan = Mgr.GetPolicyByID(1);
            InsurancePlan newPlan = Mgr.GetPlanByType("Extended");

            plan.ChangeTo(newPlan);
            Mgr.SaveEnrolleePlan(plan);
            EnrolleePlan bringBack = Mgr.GetPolicyByID(1);

            // make sure the plan type has changed 
            Assert.AreEqual(plan.Type, "Extended");
            // make sure the saved plan is the same as the plan we just worked with 
            Assert.AreSame(plan, bringBack);
        }
        /// <summary>
        /// Test that changing twice causes an exception
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeToDupTest()
        {
            EnrolleePlan plan = Mgr.GetPolicyByID(1);
            InsurancePlan newPlan = Mgr.GetPlanByType("Extended");
            InsurancePlan changeAgain = Mgr.GetPlanByType("Basic");

            plan.ChangeTo(newPlan);
            plan.ChangeTo(changeAgain);
        }
    }
}