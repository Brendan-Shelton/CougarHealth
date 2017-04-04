using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Controller.EmployeeControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Controller.EmployeeControllers;
using CoreProject.Data.Enrollee;
namespace CoreProject.Controller.EmployeeControllers.Tests
{
    [TestClass()]
    public class RemovePlanControllerTests
    {
        DbMgr mgr = DbMgr.Instance;
        IEnumerable<InsurancePlan> Plans;
        
        [TestMethod()]
        public void RemoveTest()
        {
            var RemoveCtrl = new RemovePlanController();
            Plans = mgr.GetPlans();

            RemoveCtrl.Remove("WRONG");
            var TestResult_wrong = Plans.Count();
            RemoveCtrl.Remove("");
            var TestResult_empty = Plans.Count();
            RemoveCtrl.Remove(null);
            var TestResult_null = Plans.Count();
            RemoveCtrl.Remove("Basic");
            var TestResult_right = Plans.Count();

            Assert.AreEqual(2, TestResult_wrong);
            Assert.AreEqual(2, TestResult_empty);
            Assert.AreEqual(2, TestResult_null);
            Assert.AreEqual(1, TestResult_right);

        }
    }
}