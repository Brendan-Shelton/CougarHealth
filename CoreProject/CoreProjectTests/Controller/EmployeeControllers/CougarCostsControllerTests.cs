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
            var CostCtrl = new CougarCostsController();
            var Plan = mgr.GetPlanByType("Basic");
            CostCtrl.Update(Plan,  "Annual Plan Deductible", false, false, 0);
            var TestResult_right = Plan.APD;
            Plan.APD = 250;
            CostCtrl.Update(Plan, "WRONG", false, false, 0);
            var TestResult_wrong = Plan.APD;
            Plan.APD = 250;
            CostCtrl.Update(Plan, "", false, false, 0);
            var TestResult_empty = Plan.APD;
            Plan.APD = 250;
            CostCtrl.Update(Plan, null, false, false, 0);
            var TestResult_null = Plan.APD;

            Assert.AreEqual(0, TestResult_right);
            Assert.AreEqual(250, TestResult_wrong);
            Assert.AreEqual(250, TestResult_empty);
            Assert.AreEqual(250, TestResult_null);
        }

        [TestMethod()]
        public void UpdateTest_Plan()
        {
            var CostCtrl = new CougarCostsController();
            var Plan = mgr.GetPlanByType("Basic");

            CostCtrl.Update(Plan, "Annual Plan Deductible", false, false, 0);
            var TestResult_right = Plan.APD;
            Plan.APD = 250;
            CostCtrl.Update(null, "Annual Plan Deductible", false, false, 0);
            var TestResult_wrong = Plan.APD;

            Assert.AreEqual(0, TestResult_right);
            Assert.AreEqual(250, TestResult_wrong);
        }

        [TestMethod()]
        public void UpdateTest_Percent()
        {
            var CostCtrl = new CougarCostsController();
            var Plan = mgr.GetPlanByType("Basic");

            CostCtrl.Update(Plan, "Emergency Room", true, false, 0);
            var TestResult_right = Plan.ServiceCosts[2].PercentCoverage;
            Plan.ServiceCosts[2].PercentCoverage = 1;
            CostCtrl.Update(Plan, "Emergency Room", false, false, 0);
            var TestResult_wrong = Plan.ServiceCosts[2].PercentCoverage;

            Assert.AreEqual(0, TestResult_right);
            Assert.AreEqual(1, TestResult_wrong);
        }

        [TestMethod()]
        public void UpdateTest_MaxPay()
        {
            var CostCtrl = new CougarCostsController();
            var Plan = mgr.GetPlanByType("Basic");
            Tuple<double, Service.MaxPayRate > temp = new Tuple<double, Service.MaxPayRate>(1000, Plan.ServiceCosts[2].InNetMax.Item2);
            CostCtrl.Update(Plan, "Emergency Room", false, true, 0);
            var TestResult_right = Plan.ServiceCosts[2].InNetMax.Item1;
            Plan.ServiceCosts[2].InNetMax = temp;
            CostCtrl.Update(Plan, "Emergency Room", false, false, 0);
            var TestResult_wrong = Plan.ServiceCosts[2].InNetMax.Item1;

            Assert.AreEqual(0, TestResult_right);
            Assert.AreEqual(1000, TestResult_wrong);
        }

        [TestMethod()]
        public void UpdateTest_Value()
        {
            var CostCtrl = new CougarCostsController();
            var Plan = mgr.GetPlanByType("Basic");
            // equivalance partitions and BVA

            // Less than 0
            //copayment
            CostCtrl.Update(Plan, "Emergency Room", false, false, -1);
            var TestResult_NegCopay = Plan.ServiceCosts[2].RequiredCopayment;

            //percent
            CostCtrl.Update(Plan, "Emergency Room", true, false, -1);
            var TestResult_NegPercent = Plan.ServiceCosts[2].PercentCoverage;

            // zero

            // reset Plan values
            Plan.ServiceCosts[2].PercentCoverage = 1;
            Plan.ServiceCosts[2].RequiredCopayment = 250;

            //copayment
            CostCtrl.Update(Plan, "Emergency Room", false, false, 0);
            var TestResult_ZeroCopay = Plan.ServiceCosts[2].RequiredCopayment;

            //percent
            CostCtrl.Update(Plan, "Emergency Room", true, false, 0);
            var TestResult_ZeroPercent = Plan.ServiceCosts[2].RequiredCopayment;

            // Greater than 1 (Percent only)

            //reset Plan percent value
            Plan.ServiceCosts[2].PercentCoverage = 1;

            // percent
            CostCtrl.Update(Plan, "Emergency Room", true, false, 1.1);
            var TestResult_AbovePercent = Plan.ServiceCosts[2].PercentCoverage;

            // asserts

            Assert.AreEqual(250, TestResult_NegCopay);
            Assert.AreEqual(1, TestResult_NegPercent);
            Assert.AreEqual(0, TestResult_ZeroCopay);
            Assert.AreEqual(0, TestResult_ZeroPercent);
            Assert.AreEqual(1, TestResult_AbovePercent);
        }
    }
}