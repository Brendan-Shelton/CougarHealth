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
    public class CougarCostsControllerTests
    {
        DbMgr mgr = DbMgr.Instance;
        InsurancePlan Plan;

        [TestMethod()]
        public void GetPlanTest()
        {
            var CostCtrl = new CougarCostsController();
            Plan = mgr.GetPlanByType("Basic");
            InsurancePlan TestPlan_right = CostCtrl.GetPlan("Basic");
            InsurancePlan TestPlan_wrong = CostCtrl.GetPlan("WRONG");
            InsurancePlan TestPlan_empty = CostCtrl.GetPlan("");
            InsurancePlan TestPlan_null = CostCtrl.GetPlan(null);
            Assert.AreEqual(Plan, TestPlan_right);
            Assert.IsNull(TestPlan_wrong);
            Assert.IsNull(TestPlan_empty);
            Assert.IsNull(TestPlan_null);
        }

        [TestMethod()]
        public void GetNumTest_Name()
        {
            var CostCtrl = new CougarCostsController();

            var TestResult_right = CostCtrl.GetNum("Annual Plan Deductible", "Basic", false, false);
            var TestResult_wrong = CostCtrl.GetNum("WRONG", "Basic", false, false);
            var TestResult_empty = CostCtrl.GetNum("", "Basic", false, false);
            var TestResult_null = CostCtrl.GetNum(null, "Basic", false, false);

            Assert.AreEqual(250, TestResult_right);
            Assert.AreEqual(0, TestResult_wrong);
            Assert.AreEqual(0, TestResult_empty);
            Assert.AreEqual(0, TestResult_null);
        }

        [TestMethod()]
        public void GetNumTest_Type()
        {
            var CostCtrl = new CougarCostsController();

            var TestResult_right = CostCtrl.GetNum("Annual Plan Deductible", "Basic", false, false);
            var TestResult_wrong = CostCtrl.GetNum("Annual Plan Deductible", "WRONG", false, false);
            var TestResult_empty = CostCtrl.GetNum("Annual Plan Deductible", "", false, false);
            var TestResult_null = CostCtrl.GetNum("Annual Plan Deductible", null, false, false);

            Assert.AreEqual(250, TestResult_right);
            Assert.AreEqual(0, TestResult_wrong);
            Assert.AreEqual(0, TestResult_empty);
            Assert.AreEqual(0, TestResult_null);
        }

        [TestMethod()]
        public void GetNumTest_Percent()
        {
            var CostCtrl = new CougarCostsController();

            var TestResult_right = CostCtrl.GetNum("Emergency Room", "Basic", true, false);
            var TestResult_wrong = CostCtrl.GetNum("Emergency Room", "Basic", false, false);

            Assert.AreEqual(1, TestResult_right);
            Assert.AreEqual(250, TestResult_wrong);
        }

        [TestMethod()]
        public void GetNumTest_MaxPay()
        {
            var CostCtrl = new CougarCostsController();

            var TestResult_right = CostCtrl.GetNum("Emergency Room", "Basic", false, true);
            var TestResult_wrong = CostCtrl.GetNum("Emergency Room", "Basic", false, false);

            Assert.AreEqual(1000, TestResult_right);
            Assert.AreEqual(250, TestResult_wrong);
        }

        [TestMethod()]
        public void GetNumTest_Both()
        {
            var CostCtrl = new CougarCostsController();

            var TestResult_right = CostCtrl.GetNum("Emergency Room", "Basic", false, false);
            var TestResult_wrong = CostCtrl.GetNum("Emergency Room", "Basic", true, true);

            Assert.AreEqual(250, TestResult_right);
            Assert.AreEqual(0, TestResult_wrong);
        }

        [TestMethod()]
        public void UpdateTest_Name()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest_Type()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest_Percent()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest_MaxPay()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest_Value()
        {
            Assert.Fail();
        }
    }
}