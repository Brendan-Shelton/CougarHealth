using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;

namespace CoreProject.Data.Tests
{
    [TestClass()]
    public class DbMgrTests
    {

        private PrimaryEnrollee primary = new PrimaryEnrollee("2104")
        {
            MailingAddr = "805 N Ealy",
            Email = "me@michaelrhodes.us",
            FirstName = "Michael",
            LastName = "Rhodes",
            HomePhone = "2178214819",
            SSN = "555102104"
        };

        private DbMgr mgr = DbMgr.Instance;

        [TestMethod()]
        public void GetPlanByPrimaryTest()
        {
            var plan = mgr.Plans.ElementAt(0);

            mgr.PlanSet.Add(new EnrolleePlan(this.primary, plan));

            var enrolleePlan = mgr.GetPlanByPrimary(this.primary.Id);
            var badPlan = mgr.GetPlanByPrimary(12);

            Assert.IsNull(badPlan);
            Assert.IsNotNull(enrolleePlan);
            Assert.AreEqual(this.primary.Id, enrolleePlan.PrimaryEnrollee.Value);
        }

        [TestMethod()]
        public void FindPrimaryByIdTest()
        {
            mgr.PrimaryEnrolleeSet.Add(primary);

            var goodPrimary = mgr.FindPrimaryById(primary.Id);
            var badPrimary = mgr.FindPrimaryById(2);

            Assert.IsNull(badPrimary);
            Assert.AreSame(primary, goodPrimary);
        }

        [TestMethod()]
        public void LoginTest()
        {
            mgr.PrimaryEnrolleeSet.Add(primary);

            var primaryId = mgr.Login("me@michaelrhodes.us", "2104");
            var notPrimary = mgr.Login("fake", "credentials");

            Assert.AreEqual(primaryId, primary.Id);
            Assert.IsNull(notPrimary);
        }
    }
}