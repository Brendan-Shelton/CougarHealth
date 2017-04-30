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
        public void findBillTest()
        {
            PlanController plnCtrl = new PlanController(1, "me@me", true);
            DbMgr dbmgr = DbMgr.Instance;
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
            String email = "me@me";
            double totalBillAmount = 1000;
            double enrolleeBillAmount = 460;


            var bill = new Bill(date, hsp.Id, dbmgr.GetPlanByPrimary(enrolleeId).ElementAt(0).PlanNum, service.Id, enrolleeId, email, totalBillAmount, enrolleeBillAmount);

            plnCtrl.addBill(bill);

            var retBill = dbmgr.GetBillsById(0);

            Assert.AreEqual((double)1000, retBill.ElementAt(0).totalBillAmount);
            Assert.AreEqual((double)460, retBill.ElementAt(0).enrolleeBillAmount);
            Assert.AreEqual("Inpatient", dbmgr.GetServiceById(retBill.ElementAt(0).serviceId).Name);
            Assert.AreEqual(date.Date, retBill.ElementAt(0).date.Date);
            Assert.AreEqual(hsp, dbmgr.GrabHspById( retBill.ElementAt(0).hspId));

        }
    }
}
