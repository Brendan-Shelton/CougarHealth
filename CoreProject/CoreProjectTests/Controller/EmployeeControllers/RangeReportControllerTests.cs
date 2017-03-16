using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Controller.EmployeeControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Controller.EmployeeControllers.Tests
{
    [TestClass()]
    public class RangeReportControllerTests
    {
        private RangeReportController _ctrl = new RangeReportController();

        [TestMethod()]
        public void checkBillsTest()
        {
            //rangeBills[0].amount = 400;
            //rangeBills[0].dateOfBill = new DateTime(2017, 3, 2);
            //rangeBills[0].location = "Hospital";
            //rangeBills[0].planType = 0;

            //rangeBills[1].amount = 90000;
            //rangeBills[1].dateOfBill = new DateTime(2017, 3, 4);
            //rangeBills[1].location = "Physician";
            //rangeBills[1].planType = 1;

            //rangeBills[2].amount = 449;
            //rangeBills[2].dateOfBill = new DateTime(2017, 2, 26);
            //rangeBills[2].location = "Other";
            //rangeBills[2].planType = 0;

            //rangeBills[3].amount = 200;
            //rangeBills[3].dateOfBill = new DateTime(2017, 2, 1);
            //rangeBills[3].location = "Hospital";
            //rangeBills[3].planType = 1;

            //rangeBills[4].amount = 1000;
            //rangeBills[4].dateOfBill = new DateTime(2017, 2, 20);
            //rangeBills[4].location = "Physician";
            //rangeBills[4].planType = 0;
            double[] correctOutput = { (1000 + 400 + 449)/(400 + 449 + 1000) * 100, (200 + 90000 )/(90000 + 200) * 100, 1849, 90200 };

            DateTime begin, end;

            begin = new DateTime(2017, 1, 25);
            end = DateTime.Now;
            _ctrl.setDates(begin, end);

            double[] test = _ctrl.checkBills();

            for (int i = 0; i < test.Length; i++)
            {
            Assert.AreEqual(correctOutput[i], test[i]);
            }
   
        }
    }
}