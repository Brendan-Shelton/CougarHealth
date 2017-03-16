using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Controller.EnrolleeControllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Data.Enrollee;

namespace CoreProject.Controller.EnrolleeControllers.Tests
{
    [TestClass()]
    public class EnrollControllerTests
    {
        [TestMethod()]
        public void CreatePrimaryEnrolleeTest()
        {
            // arrange
            var ctrl = new EnrollController();
            var first = "Michael";
            var last = "Rhodes";
            var email = "me@michaelrhodes.us";
            var billing = "804 n ealy";
            var hyphenPhone = "1214-291-3214";
            var home = "2142913214";
            var ssn = "222101923";
            var hyphenSsn = "222-10-1923";
            var pin = "9253";
            string mailing = "";
            string mobile = "";

            var testEnrollee = new PrimaryEnrollee(pin)
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

            var ctrlContact = new EnrollController.Contact
            {
                email = email,
                homePhone = hyphenPhone,
                mobilePhone = mobile
            };

            // act
            ctrl.CreatePrimaryEnrollee(
                first,
                last,
                hyphenSsn,
                mailing,
                billing,
                pin,
                ctrlContact
            );

            //assert
            Assert.IsNotNull(ctrl.PrimaryEnrollee);
            Assert.AreEqual(ctrl.PrimaryEnrollee, testEnrollee);
        }

        /// <summary>
        /// Make sure we get a data exception if we try to create a primary
        /// enrollee if they already exist
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(DataException))]
        public void CreateDuplicatePrimaryEnrolleeTest()
        {
            // arrange
            var ctrl = new EnrollController();
            var first = "Michael";
            var last = "Rhodes";
            var email = "me@michaelrhodes.us";
            var billing = "804 n ealy";
            var hyphenPhone = "1214-291-3214";
            var home = "2142913214";
            var ssn = "222101923";
            var hyphenSsn = "222-10-1923";
            var pin = "9253";
            string mailing = "";
            string mobile = "";
            var ctrlContact = new EnrollController.Contact
            {
                email = email,
                homePhone = hyphenPhone,
                mobilePhone = mobile
            };

            ctrl.CreatePrimaryEnrollee(
                first,
                last,
                hyphenSsn,
                mailing,
                billing,
                pin,
                ctrlContact
            );

            ctrl.CreatePrimaryEnrollee(
                first,
                last,
                hyphenSsn,
                mailing,
                billing,
                pin,
                ctrlContact
            );
        }

        [TestMethod()]
        public void CheckSSNTest()
        {
            var ctrl = new EnrollController();
            // The check should pass with any 9 digit number with optional
            // hyphens or spaces
            var basicSsn = "229689130";
            var ssnWithHyphens = "259-98-9730";
            var ssnWithSpaces = "333 68 0137";
            var ssnMix = "345-12 9823";
            // too long so should not pass
            var badSsn = "2214183193";
            // not too long, but it has a letter
            var badSsnLetters = "22141831x3";


            bool basicCheck = ctrl.CheckSSN(basicSsn);
            bool hyphenCheck = ctrl.CheckSSN(ssnWithHyphens);
            bool spaceCheck = ctrl.CheckSSN(ssnWithSpaces);
            bool mixCheck = ctrl.CheckSSN(ssnMix);
            bool tooLongCheck = ctrl.CheckSSN(badSsn);
            bool letterCheck = ctrl.CheckSSN(badSsnLetters);

            // good values
            Assert.IsTrue(basicCheck);
            Assert.IsTrue(hyphenCheck);
            Assert.IsTrue(spaceCheck);
            Assert.IsTrue(mixCheck);
            // bad values 
            Assert.IsFalse(tooLongCheck);
            Assert.IsFalse(letterCheck);
        }

        /// <summary>
        /// Testing good and bad contact information. Mobile phones are 
        /// optional, email address should have a site, and phone numbers 
        /// should be of US format with hyphens and spaces allowed
        /// </summary>
        [TestMethod()]
        public void VerifyContactTest()
        {
            var ctrl = new EnrollController();
            // all fields inputted and valid 
            var basicContact = new EnrollController.Contact
            {
                email = "me@michaelrhodes.us",
                errMsg = null,
                mobilePhone = "2192011021",
                homePhone = "2173277777"
            };
            // mobile phone is optional so this should pass
            var noMobile = new EnrollController.Contact
            {
                email = "me@michaelrhodes.us",
                errMsg = null,
                mobilePhone = "",
                homePhone = "2173277777"
            };
            // the leading one in US phone numbers are optional
            var leadingOne = new EnrollController.Contact
            {
                email = "me@michaelrhodes.us",
                errMsg = null,
                mobilePhone = "",
                homePhone = "12173277777"
            };
            // Hyphens and spaces are optional
            var spacedPhone = new EnrollController.Contact
            {
                email = "me@michaelrhodes.us",
                errMsg = null,
                mobilePhone = "",
                homePhone = "217 327 7777"
            };
            var hyphennedPhone = new EnrollController.Contact
            {
                email = "me@michaelrhodes.us",
                errMsg = null,
                mobilePhone = "",
                homePhone = "217-327-7777"
            };
            // wrong email syntax: should fail
            var badEmail = new EnrollController.Contact
            {
                email = "me@michaelrhodesus",
                errMsg = null,
                mobilePhone = "2192011021",
                homePhone = "2173277777"
            };
            // used british phone number: should fail
            var britishPhone = new EnrollController.Contact
            {
                email = "me@michaelrhodes.us",
                errMsg = null,
                // even though mobile is optional, non-us phone numbers are not allowed
                mobilePhone = "4402071234567",
                homePhone = "2173277777"
            };
            // home and email fields are required so emmitting them should fail
            var noHome = new EnrollController.Contact
            {
                email = "me@michaelrhodes.us",
                errMsg = null,
                mobilePhone = "2192011021",
                homePhone = ""
            };
            var noEmail = new EnrollController.Contact
            {
                email = "",
                errMsg = null,
                mobilePhone = "2192011021",
                homePhone = "2173277777"
            };

            // good values
            bool checkAllFilled = ctrl.VerifyContact(ref basicContact);
            bool checkNoMobile = ctrl.VerifyContact(ref noMobile);
            bool checkUSCode = ctrl.VerifyContact(ref leadingOne);
            bool checkSpace = ctrl.VerifyContact(ref spacedPhone);
            bool checkHyphen = ctrl.VerifyContact(ref hyphennedPhone);
            // bad values
            bool checkInvalidEmail = ctrl.VerifyContact(ref badEmail);
            bool checkBritish = ctrl.VerifyContact(ref britishPhone);
            bool checkNoHome = ctrl.VerifyContact(ref noHome);
            bool checkNoEmail = ctrl.VerifyContact(ref noEmail);

            Assert.IsTrue(checkAllFilled);
            Assert.IsTrue(checkNoMobile);
            Assert.IsTrue(checkUSCode);
            Assert.IsTrue(checkSpace);
            Assert.IsTrue(checkHyphen);
            Assert.IsFalse(checkInvalidEmail);
            Assert.IsFalse(checkBritish);
            Assert.IsFalse(checkNoHome);
            Assert.IsFalse(checkNoEmail);
            Assert.AreEqual(noEmail.errMsg, "A valid email is required");
            Assert.AreEqual(noHome.errMsg, "A valid US based home phone is required");
            Assert.AreEqual(britishPhone.errMsg, "A valid US based mobile phone is required" +
                                     "\n(you could also leave the field blank)");
            Assert.AreEqual(badEmail.errMsg, "A valid email is required");

        }

        /// <summary>
        /// Make sure we output a Service array and check that we get something
        /// back 
        /// </summary>
        [TestMethod()]
        public void ShowPlanDetailsTest()
        {
            var ctrl = new EnrollController();
            // should work properly 
            string goodPlan = "Basic";
            DbMgr mgr = DbMgr.Instance;

            var beBasic = ctrl.ShowPlanDetails(goodPlan);

            Assert.IsNotNull(beBasic);
            Assert.IsInstanceOfType(beBasic, typeof(Service[]));
        }

        /// <summary>
        /// Throws a null reference because there is no insurance plan for 
        /// "bad"
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShowPlanDetailsTestException()
        {
            const string badPlan = "bad";
            var ctrl = new EnrollController();
            ctrl.ShowPlanDetails(badPlan);
        }

        /// <summary>
        /// Their is no PrimaryEnrollee attached to the ctrl so this should be an 
        /// invalid call
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GetNameTest()
        {
            var ctrl = new EnrollController();
            ctrl.GetName();
        }

        [TestMethod()]
        public void CreateDependentTest()
        {
            // set up 
            var ctrl = new EnrollController();
            var mgr = DbMgr.Instance;
            var primary = new PrimaryEnrollee("2103")
            {
                MailingAddr = "805 N Ealy",
                Email = "me@michaelrhodes.us",
                FirstName = "Michael",
                LastName = "Rhodes",
                HomePhone = "2178214819",
                SSN = "555102104"
            };
            mgr.PrimaryEnrolleeSet.Add(primary);
            var plan = mgr.Plans.ElementAt(0);
            var enrolleePlan = new EnrolleePlan(primary, plan);
            mgr.PlanSet.Add(enrolleePlan);


            // testing 
            var planId = ctrl.CreateDependent(
                primary.Id,
                "Dude",
                "McGuy",
                "334102341",
                "Significant Other",
                "2341",
                new EnrollController.Contact
                {
                    email = "dude@mcguy.us",
                    homePhone = "2178214819"
                }
            );

            Assert.AreEqual(planId, enrolleePlan.PlanNum);
        }

        /// <summary>
        /// Trying to create duplicate plans 
        /// </summary>
        [TestMethod()]
        public void PickPlanTest()
        {
            var ctrl = new EnrollController();
            var mgr = DbMgr.Instance;
            var primary = new PrimaryEnrollee("2103")
            {
                MailingAddr = "805 N Ealy",
                Email = "me@michaelrhodes.us",
                FirstName = "Michael",
                LastName = "Rhodes",
                HomePhone = "2178214819",
                SSN = "555102104"
            };
            var plan = mgr.Plans.ElementAt(0);
            ctrl.PrimaryEnrollee = primary;

            var enrolleePlan = ctrl.PickPlan($"{plan.Type}");
            var dupEnrolleePlan = ctrl.PickPlan($"{plan.Type}");

            Assert.AreEqual(enrolleePlan, dupEnrolleePlan);
        }
    }
}