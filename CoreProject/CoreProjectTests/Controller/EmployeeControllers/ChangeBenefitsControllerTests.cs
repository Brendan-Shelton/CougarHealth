using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Controller.EmployeeControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Data.Enrollee;

namespace CoreProject.Controller.EmployeeControllers.Tests
{
    [TestClass()]
    public class ChangeBenefitsControllerTests
    {
        DbMgr mgr = DbMgr.Instance;
        InsurancePlan Plan;
        [TestMethod()]
        public void AddBenefitTest_Name()
        {
            Plan = mgr.GetPlanByType("Basic");
            var ChangeCtrl = new ChangeBenefitsController();
            int prevCount = Plan.ServiceCosts.Count();

            //Correctly formatted name
            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", 15, 150, 1500);
            var TestResult_right = Plan.ServiceCosts.Count();
            Assert.AreEqual(prevCount+1, TestResult_right);
            prevCount = Plan.ServiceCosts.Count();

            // Empty name
            ChangeCtrl.AddBenefit(Plan, "", "Hospital", 15, 150, 1500);
            var TestResult_empty = Plan.ServiceCosts.Count();
            Assert.AreEqual(prevCount, TestResult_empty);
            prevCount = Plan.ServiceCosts.Count();
            // Null name
            ChangeCtrl.AddBenefit(Plan, null, "Hospital", 15, 150, 1500);
            var TestResult_null = Plan.ServiceCosts.Count();
            Assert.AreEqual(prevCount, TestResult_null);

        }

        [TestMethod()]
        public void AddBenefitTest_Category()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddBenefitTest_Percent()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddBenefitTest_Copay()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddBenefitTest_MaxPay()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveBenefitTest()
        {
            Assert.Fail();
        }
    }
}