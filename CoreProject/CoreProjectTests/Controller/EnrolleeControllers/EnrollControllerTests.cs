using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Controller.EnrolleeControllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;

namespace CoreProject.Controller.EnrolleeControllers.Tests
{
    [TestClass()]
    public class EnrollControllerTests
    {
        [TestMethod()]
        public void CreateEnrolleeTest()
        {
            // arrange
            var ctrl = new EnrollController();
            var first = "Michael";
            var last = "Rhodes";
            var email = "me@michaelrhodes.us";
            var billing = "804 n ealy";
            var home = "2142913214";
            var ssn = "222101923";
            var pin = "9253";
            string mailing = null;
            string mobile = null;
            
            var testEnrollee = new Enrollee
            {
                BillingAddr = billing,
                Email = email,
                FirstName = first,
                LastName = last,
                HomePhone = home,
                MailingAddr = mailing,
                SSN = ssn,
                MobilePhone = mobile
            };
            testEnrollee.changePIN(pin);

            // act
            var ctrlContact = new EnrollController.Contact
            {
                email = email,
                homePhone = home,
                mobilePhone = null
            };
            ctrl.CreateEnrollee(
                first, 
                last, 
                ssn, 
                null, 
                billing, 
                pin, 
                ctrlContact
            );

            //assert
            Assert.IsNotNull(ctrl.Enrollee);
            Assert.AreEqual(ctrl.Enrollee, testEnrollee);
        }
    }
}