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
        public void AddBenefitTest_Plan()
        {
            Plan = mgr.GetPlanByType("Basic");
            var ChangeCtrl = new ChangeBenefitsController();
            int prevCountRight = Plan.ServiceCosts.Count();

            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", 15, 150, 1500);
            var TestResult_right = Plan.ServiceCosts.Count();
            
            var prevCountWrong = Plan.ServiceCosts.Count();

            ChangeCtrl.AddBenefit(null, "New Item", "Hospital", 15, 150, 1500);
            var TestResult_wrong = Plan.ServiceCosts.Count();

            Assert.AreEqual(prevCountRight + 1, TestResult_right);
            Assert.AreEqual(prevCountWrong, TestResult_wrong);
        }

        [TestMethod()]
        public void AddBenefitTest_Name()
        {
            Plan = mgr.GetPlanByType("Basic");
            var ChangeCtrl = new ChangeBenefitsController();
            int prevCountRight = Plan.ServiceCosts.Count();

            //Correctly formatted name
            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", 15, 150, 1500);
            var TestResult_right = Plan.ServiceCosts.Count();
            
            var prevCountEmpty = Plan.ServiceCosts.Count();
            
            // Empty name
            ChangeCtrl.AddBenefit(Plan, "", "Hospital", 15, 150, 1500);
            var TestResult_empty = Plan.ServiceCosts.Count();
            
            var prevCountNull = Plan.ServiceCosts.Count();
            // Null name
            ChangeCtrl.AddBenefit(Plan, null, "Hospital", 15, 150, 1500);
            var TestResult_null = Plan.ServiceCosts.Count();


            Assert.AreEqual(prevCountRight + 1, TestResult_right);
            Assert.AreEqual(prevCountEmpty, TestResult_empty);
            Assert.AreEqual(prevCountNull, TestResult_null);

        }

        [TestMethod()]
        public void AddBenefitTest_Category()
        {
            Plan = mgr.GetPlanByType("Basic");
            var ChangeCtrl = new ChangeBenefitsController();
            int prevCountRight = Plan.ServiceCosts.Count();

            //Correctly formatted category
            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", 15, 150, 1500);
            var TestResult_right = Plan.ServiceCosts.Count();
           
            var prevCountEmpty = Plan.ServiceCosts.Count();
            
            // Empty category
            ChangeCtrl.AddBenefit(Plan, "New Item", "", 15, 150, 1500);
            var TestResult_empty = Plan.ServiceCosts.Count();
            
            var prevCountNull = Plan.ServiceCosts.Count();
            // Null category
            ChangeCtrl.AddBenefit(Plan, "New Item", null, 15, 150, 1500);
            var TestResult_null = Plan.ServiceCosts.Count();
           

            Assert.AreEqual(prevCountRight + 1, TestResult_right);
            Assert.AreEqual(prevCountEmpty + 1, TestResult_empty);
            Assert.AreEqual(prevCountNull, TestResult_null);
        }

        [TestMethod()]
        public void AddBenefitTest_Percent()
        {
            Plan = mgr.GetPlanByType("Basic");
            var ChangeCtrl = new ChangeBenefitsController();
            int prevCountLessZero = Plan.ServiceCosts.Count();

            //BVA and Equivalance Partitioning

            // Less than 0: -1, 0, 1
            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", -1, 150, 1500);
            var TestResult_LessZero = Plan.ServiceCosts.Count();
            
            var prevCountZero = Plan.ServiceCosts.Count();
            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", 0, 150, 1500);
            var TestResult_Zero = Plan.ServiceCosts.Count();
            
            var prevCountGreaterZero = Plan.ServiceCosts.Count();
            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", 1, 150, 1500);
            var TestResult_GreaterZero = Plan.ServiceCosts.Count();
            
            var prevCountLessHundred = Plan.ServiceCosts.Count();
            // greater than 100: 99, 100, 101
            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", 99, 150, 1500);
            var TestResult_LessHundred = Plan.ServiceCosts.Count();
            
            var prevCountHundred = Plan.ServiceCosts.Count();
            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", 100, 150, 1500);
            var TestResult_Hundred = Plan.ServiceCosts.Count();
            
            var prevCountGreaterHundred = Plan.ServiceCosts.Count();
            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", 101, 150, 1500);
            var TestResult_GreaterHundred = Plan.ServiceCosts.Count();


            Assert.AreEqual(prevCountLessZero, TestResult_LessZero);
            Assert.AreEqual(prevCountZero + 1, TestResult_Zero);
            Assert.AreEqual(prevCountGreaterZero + 1, TestResult_GreaterZero);
            Assert.AreEqual(prevCountLessHundred + 1, TestResult_LessHundred);
            Assert.AreEqual(prevCountHundred + 1, TestResult_Hundred);
            Assert.AreEqual(prevCountGreaterHundred, TestResult_GreaterHundred);
        }

        [TestMethod()]
        public void AddBenefitTest_Copay()
        {
            Plan = mgr.GetPlanByType("Basic");
            var ChangeCtrl = new ChangeBenefitsController();
            int prevCountLessZero = Plan.ServiceCosts.Count();

            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", 15, -1, 1500);
            var TestResult_LessZero = Plan.ServiceCosts.Count();
            
            var prevCountZero = Plan.ServiceCosts.Count();
            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", 15, 0, 1500);
            var TestResult_Zero = Plan.ServiceCosts.Count();
           
            var prevCountGreaterZero = Plan.ServiceCosts.Count();
            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", 15, 1, 1500);
            var TestResult_GreaterZero = Plan.ServiceCosts.Count();

            Assert.AreEqual(prevCountLessZero, TestResult_LessZero);
            Assert.AreEqual(prevCountZero + 1, TestResult_Zero);
            Assert.AreEqual(prevCountGreaterZero + 1, TestResult_GreaterZero);

        }

        [TestMethod()]
        public void AddBenefitTest_MaxPay()
        {
            Plan = mgr.GetPlanByType("Basic");
            var ChangeCtrl = new ChangeBenefitsController();
            int prevCountLessZero = Plan.ServiceCosts.Count();

            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", 15, 150, -1);
            var TestResult_LessZero = Plan.ServiceCosts.Count();
            
            var prevCountZero = Plan.ServiceCosts.Count();
            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", 15, 150, 00);
            var TestResult_Zero = Plan.ServiceCosts.Count();
            
            var prevCountGreaterZero = Plan.ServiceCosts.Count();
            ChangeCtrl.AddBenefit(Plan, "New Item", "Hospital", 15, 150, 1);
            var TestResult_GreaterZero = Plan.ServiceCosts.Count();

            Assert.AreEqual(prevCountLessZero, TestResult_LessZero);
            Assert.AreEqual(prevCountZero + 1, TestResult_Zero);
            Assert.AreEqual(prevCountGreaterZero + 1, TestResult_GreaterZero);
        }

        [TestMethod()]
        public void RemoveBenefitTest()
        {
            Plan = mgr.GetPlanByType("Basic");
            var ChangeCtrl = new ChangeBenefitsController();
            int prevCountRight = Plan.ServiceCosts.Count();

            ChangeCtrl.RemoveBenefit(Plan, "Inpatient");
            var TestResult_right = Plan.ServiceCosts.Count();
            
            var prevCountEmpty = Plan.ServiceCosts.Count();

            ChangeCtrl.RemoveBenefit(Plan, "");
            var TestResult_empty = Plan.ServiceCosts.Count();
            
            var prevCountNull = Plan.ServiceCosts.Count();

            ChangeCtrl.RemoveBenefit(Plan, null);
            var TestResult_null = Plan.ServiceCosts.Count();

            Assert.AreEqual(prevCountRight - 1, TestResult_right);
            Assert.AreEqual(prevCountEmpty, TestResult_empty);
            Assert.AreEqual(prevCountNull, TestResult_null);

        }

        [TestMethod()]
        public void RemoveBenefitTest_Plan()
        {
            Plan = mgr.GetPlanByType("Basic");
            var ChangeCtrl = new ChangeBenefitsController();
            int prevCountRight = Plan.ServiceCosts.Count();

            ChangeCtrl.RemoveBenefit(Plan, "Inpatient");
            var TestResult_right = Plan.ServiceCosts.Count();
            
            var prevCountWrong = Plan.ServiceCosts.Count();

            ChangeCtrl.RemoveBenefit(null, "Inpatient");
            var TestResult_wrong = Plan.ServiceCosts.Count();

            Assert.AreEqual(prevCountRight - 1, TestResult_right);
            Assert.AreEqual(prevCountWrong, TestResult_wrong);

            
        }
    }


}