using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Controller.HSPControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;
using CoreProject.Data;
namespace CoreProject.Controller.HSPControllers.Tests
{
    [TestClass()]
    public class BillControllerTests
    {

        /// <summary>
        /// Check policy that has been created and one that has not
        /// </summary>
        [TestMethod()]
        public void CheckPolicyTest()
        {

            DbMgr Mgr;
            Mgr = DbMgr.Instance;
            InsurancePlan p = new InsurancePlan();
            PrimaryEnrollee e = new PrimaryEnrollee("0");
            EnrolleePlan eP = new EnrolleePlan(e, p);

            Mgr.SaveEnrolleePlan(eP);

            var bill = new BillController();
            bool notTrue = bill.CheckPolicy(2);
            bool soTrue = bill.CheckPolicy(1);

            Assert.IsFalse(notTrue);
            Assert.IsTrue(soTrue);
        }
        /// <summary>
        /// Check enrollee that has been created and one that has not
        /// </summary>
        [TestMethod()]
        public void CheckEnrolleeTest()
        {
            DbMgr Mgr;
            Mgr = DbMgr.Instance;
            PrimaryEnrollee e = new PrimaryEnrollee("0");
            e.FirstName = "A";
            e.LastName = "B";
            e.SSN = "123456778";

            Mgr.SaveEnrollee(e);

            var bill = new BillController();
            bool notTrue = bill.CheckEnrollee("A");
            bool soTrue = bill.CheckEnrollee("A B");

            Assert.IsFalse(notTrue);
            Assert.IsTrue(soTrue);
        }
        /// <summary>
        /// Check charge that is more than max and one that is less
        /// </summary>
        [TestMethod()]
        public void HSPCalculateTest()
        {
            DbMgr Mgr;
            Mgr = DbMgr.Instance;
            InsurancePlan p = new InsurancePlan();
            p.Type = "Basic";
            PrimaryEnrollee e = new PrimaryEnrollee("0");
            EnrolleePlan eP = new EnrolleePlan(e, p);

            Mgr.SaveEnrolleePlan(eP);
            

            var bill = new BillController();
            List<String> s = new List<String>();
            s.Add("Inpatient");
            s.Add("Inpatient");
            List<int> c = new List<int>();
            c.Add(2500);
            c.Add(1500);
            bill.CheckEnrollee("A B");
            bill.CheckPolicy(1);
            
            String[,] returnArr = new String[2,4];
            returnArr = bill.HSPCalculate(s, c, DateTime.Now);

            Assert.AreEqual("2000", returnArr[0, 1]);
            Assert.AreEqual("560", returnArr[0, 2]);
            Assert.AreEqual("1440", returnArr[0, 3]);

            Assert.AreEqual("1500", returnArr[1, 1]);
            Assert.AreEqual("510", returnArr[1, 2]);
            Assert.AreEqual("990", returnArr[1, 3]);
        }
        /// <summary>
        /// Check charge that is more than max and one that is less
        /// </summary>
        [TestMethod()]
        public void OHSPCalculateTest()
        {
            DbMgr Mgr;
            Mgr = DbMgr.Instance;
            InsurancePlan p = new InsurancePlan();
            p.Type = "Basic";
            PrimaryEnrollee e = new PrimaryEnrollee("0");
            EnrolleePlan eP = new EnrolleePlan(e, p);

            Mgr.SaveEnrolleePlan(eP);


            var bill = new BillController();
            List<String> s = new List<String>();
            s.Add("Inpatient");
            s.Add("Inpatient");
            List<int> c = new List<int>();
            c.Add(2500);
            c.Add(1500);
            bill.CheckEnrollee("A B");
            bill.CheckPolicy(1);

            String[,] returnArr = new String[2, 4];
            returnArr = bill.OHSPCalculate(s, c, DateTime.Now);

            Assert.AreEqual("2500", returnArr[0, 1]);
            Assert.AreEqual("1060", returnArr[0, 2]);
            Assert.AreEqual("1440", returnArr[0, 3]);
            Assert.AreEqual("1500", returnArr[1, 1]);
            Assert.AreEqual("510", returnArr[1, 2]);
            Assert.AreEqual("990", returnArr[1, 3]);
        }
    }
}