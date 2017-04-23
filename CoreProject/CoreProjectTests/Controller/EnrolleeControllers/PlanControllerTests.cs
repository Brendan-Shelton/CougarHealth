using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Controller.EnrolleeControllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Data.HealthcareServiceProvider;
using CoreProject.Data.Enrollee;
using CoreProject.Data;

namespace CoreProjectTests.Controller.EnrolleeControllers
{
    [TestClass()]
    public class PlanControllerTests
    {
        [TestMethod()]
        public void addBillTest()
        {
            DateTime date = DateTime.Now;
            var hsp = new HSP("1234", true);
            var service = new Service
            {
                Category = "Hospital",
                Name = "Inpatient",
                PercentCoverage = 0.9,
                RequiredCopayment = 400.0,
                InNetMax = new Tuple<double, Service.MaxPayRate>(
                            2000,
                            Service.MaxPayRate.Day
                        )
            };
            int enrolleeId = 1;
            double totalBillAmount = 1000;
            double enrolleeBillAmount = 460;


            var bill = new Bill(date, hsp, service, enrolleeId, totalBillAmount, enrolleeBillAmount);

            Assert.AreEqual((double)1000, bill.totalBillAmount);
            Assert.AreEqual((double)460, bill.enrolleeBillAmount);
            Assert.AreEqual("Inpatient", bill.service.Name);
            Assert.AreEqual(date.Date, bill.date.Date);
            Assert.AreEqual(hsp, bill.hsp);

        }

        [TestMethod()]
        public void findBillTest()
        {
            PlanController plnCtrl = new PlanController(1, true);
            DbMgr dbMgr = DbMgr.Instance;
            DateTime date = DateTime.Now;
            var hsp = new HSP("1234", true);
            var service = new Service
            {
                Category = "Hospital",
                Name = "Inpatient",
                PercentCoverage = 0.9,
                RequiredCopayment = 400.0,
                InNetMax = new Tuple<double, Service.MaxPayRate>(
                            2000,
                            Service.MaxPayRate.Day
                        )
            };
            int enrolleeId = 1;
            double totalBillAmount = 1000;
            double enrolleeBillAmount = 460;


            var bill = new Bill(date, hsp, service, enrolleeId, totalBillAmount, enrolleeBillAmount);

            plnCtrl.addBill(bill);

            var retBill = dbMgr.getBillsById(1);

            Assert.AreEqual((double)1000, retBill[0].totalBillAmount);
            Assert.AreEqual((double)460, retBill[0].enrolleeBillAmount);
            Assert.AreEqual("Inpatient", retBill[0].service.Name);
            Assert.AreEqual(date.Date, retBill[0].date.Date);
            Assert.AreEqual(hsp, retBill[0].hsp);

        }
    }
}
