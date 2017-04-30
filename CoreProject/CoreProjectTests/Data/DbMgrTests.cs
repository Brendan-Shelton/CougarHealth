﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;
using CoreProject.Data.HealthcareServiceProvider;

namespace CoreProject.Data.Tests
{
    [TestClass()]
    public class DbMgrTests
    {

        private PrimaryEnrollee guest = new PrimaryEnrollee("1234")
        {
            MailingAddr = "805 N Guest",
            BillingAddr = "805 N Guest",
            Email = "guest@guest",
            FirstName = "Guest",
            LastName = "Guest",
            HomePhone = "1234567890",
            MobilePhone = "1234567890",
            SSN = "123456789"
        };

        private DbMgr mgr = DbMgr.Instance;

        [TestMethod()]
        public void GetPlanByPrimaryTest()
        {
            int defaultPrimary = 1;

            var enrolleePlan = mgr.GetPlanByPrimary(defaultPrimary);

            // make sure pulling a normal enrollee plan works 
            Assert.AreEqual(250000.0000, enrolleePlan.ElementAt(0).PYMBRemainder);
            // make sure we are pulling the bills
            Assert.AreEqual(enrolleePlan.ElementAt(0).Charges[0].Id, 3);
            // check if we are pulling the dependents from
            Assert.AreEqual(enrolleePlan.ElementAt(0).Dependents[0], 1);
        }

        [TestMethod()]
        public void FindPrimaryByIdTest()
        {
            var goodPrimary = mgr.FindPrimaryById(1);
            var badPrimary = mgr.FindPrimaryById(5);

            Assert.IsNull(badPrimary);
            Assert.AreEqual(guest, goodPrimary);
        }

        //[TestMethod()]
        //public void LoginTest()
        //{
        //    mgr.PrimaryEnrolleeSet.Add(primary);

        //    var primaryId = mgr.Login("me@michaelrhodes.us", "2104");
        //    var notPrimary = mgr.Login("fake", "credentials");

        //    Assert.AreEqual(primaryId, primary.Id);
        //    Assert.IsNull(notPrimary);
        //}

        [TestMethod()]
        public void GetEnrolleeByEmailTest()
        {
            // the guest account is put into the Primary Enrollee table 
            // that is where I am looking 
            var email = "guest@guest";
            var depEmail = "dude@mcguy";
            var not = "this@doesnotexist.com";

            var enrollee = mgr.GetEnrolleeByEmail(email);
            var depEnrollee = mgr.GetEnrolleeByEmail(depEmail);
            var notEnrollee = mgr.GetEnrolleeByEmail(not);

            Assert.IsNotNull(enrollee);
            Assert.AreEqual(enrollee.Email, "guest@guest");
            Assert.IsInstanceOfType(enrollee, typeof(PrimaryEnrollee));
            Assert.IsInstanceOfType(depEnrollee, typeof(DependentEnrollee));
            Assert.IsNull(notEnrollee);
        }

        /// <summary>
        /// Checks if saving the enrollee will result with a primary enrollee
        /// stored into the PrimaryEnrollee table. It also checks if the 
        /// enrollee that we put in is the same as we get out 
        /// </summary>
        [TestMethod()]
        public void SaveEnrolleeTest()
        {
            var newDude = new PrimaryEnrollee("1234")
            {
                MailingAddr = "805 N Guest",
                BillingAddr = "805 N Guest",
                Email = "new@dude.com",
                FirstName = "Guest",
                LastName = "Guest",
                HomePhone = "1234567890",
                MobilePhone = "1234567890",
                SSN = "123456788"
            };

            var myId = mgr.SaveEnrollee(newDude);
            PrimaryEnrollee saved = null;

            if (myId != null)
            {
                saved = mgr.FindPrimaryById(myId.Value);
            }

            Assert.IsNotNull(myId);
            Assert.IsNotNull(saved);
            Assert.AreEqual(myId.Value, saved.Id);
            Assert.AreEqual(newDude, saved);
        }

        /// <summary>
        /// Updates the plan information that the Admin entered
        /// </summary>
        [TestMethod()]
        public void AdminUpdatePlanTest()
        {

            // Update APD
            var ret = mgr.AdminUpdatePlan("Basic", "Benefits", "APD", false, false, 50);
            var Plan = mgr.GetPlanByType("Basic");

            Assert.IsNotNull(ret);
            Assert.AreEqual(50, Plan.APD);
        }

        /// <summary>
        /// Grabs how many plans we currently have in the database and asserts
        /// that, after removing a plan, the count of plans goes down
        /// </summary>
        [TestMethod()]
        public void RemovePlanTest()
        {
            var beforeCount = mgr.GetPlans().Count();
            mgr.RemovePlan("Basic");
            var afterCount = mgr.GetPlans().Count();

            Assert.IsTrue(afterCount < beforeCount);
        }

        /// <summary>
        /// Get the Extended InsurancePlan 
        /// </summary>
        [TestMethod()]
        public void GetPlanByTypeTest()
        {
            var extended = mgr.GetPlanByType("Extended");
            Assert.IsNotNull(extended);
            Assert.AreEqual(extended.Type, "Extended");
        }

        /// <summary>
        /// Asserts that we get a not null list back, that the list is of type 
        /// List&lt;InsurancePlan%gt;, and that there is more than one plan in 
        /// the list
        /// </summary>
        [TestMethod()]
        public void GetPlansTest()
        {
            var plans = mgr.GetPlans();

            Assert.IsNotNull(plans);
            Assert.IsInstanceOfType(plans, typeof(List<InsurancePlan>));
            Assert.IsTrue(plans.Any());
        }

        [TestMethod()]
        public void GetPolicyByIDTest()
        {
            int goodid = 1;
            int badid = 0;

            var plan = mgr.GetPolicyByID(goodid);
            var notPlan = mgr.GetPolicyByID(badid);

            Assert.IsNotNull(plan);
            Assert.AreEqual(plan.TotalCost, 0);
            Assert.AreEqual(plan.Type, "Basic");
            Assert.IsTrue(plan.Dependents.Any());
            Assert.IsNull(notPlan);
        }

        [TestMethod()]
        public void GrabHspByNameTest()
        {
            string validName = "Name";
            string notValid = "michael";

            var hsp = mgr.GrabHspByName(validName);
            var notHsp = mgr.GrabHspByName(notValid);

            Assert.IsNotNull(hsp);
            Assert.AreEqual(hsp.Personnel, "Contact");
            Assert.IsTrue(hsp.ServicesOffered.Any());
            Assert.IsNull(notHsp);

        }

        [TestMethod()]
        public void GrabHspByIdTest()
        {
            int validId = 2;
            int notValid = 0;

            var hsp = mgr.GrabHspById(validId);
            var notHsp = mgr.GrabHspById(notValid);

            Assert.IsNotNull(hsp);
            Assert.AreEqual(hsp.Personnel, "Contact");
            Assert.IsTrue(hsp.ServicesOffered.Any());
            Assert.IsNull(notHsp);
        }

        [TestMethod()]
        public void SaveBillTest()
        {

            HSP hsp = new HSP("1234", true)
            {
                Name = "zach",
                ServicesOffered = new List<string>() { "Inpatient" },
                Address = "Address",
                BankName = "Name",
                Personnel = "Contact",
                RoutingNum = 123456,
                AccountNum = 123456
            };

            mgr.SaveHsp(hsp);

            var guest = new PrimaryEnrollee("1234")
            {
                Email = "guest@guest",
                FirstName = "Guest",
                LastName = "Guest",
                HomePhone = "5555555555",
                MobilePhone = "5555555555",
                BillingAddr = "666 Avenue St.",
                MailingAddr = "666 Avenue St.",
                SSN = "123456789"
            };

            mgr.SaveEnrollee(guest);

            var plan = mgr.GetServicesByPlan

            var bill = new Bill(
                                DateTime.Now,
                                hsp,
                                ,
                                guest.Id,
                                guest.Email,
                                2000,
                                500
                                );

            Bill dbBill = null;

            mgr.addBill(bill);
        }


        [TestMethod()]
        public void SaveHspTest()
        {
            var serviceName = "Inpatient";
            HSP hsp = new HSP("1234", true)
            {
                Name = "michael",
                ServicesOffered = new List<string>() { serviceName },
                Address = "Address",
                BankName = "Name",
                Personnel = "Contact",
                RoutingNum = 123456,
                AccountNum = 123456
            };

            HSP dbHsp = null;

            mgr.SaveHsp(hsp);
            if ( hsp.Id > 0 )
            {
                dbHsp = mgr.GrabHspById(hsp.Id);
            }

            // zero is default value for int, so make sure the id is updated 
            Assert.IsTrue(hsp.Id > 0);
            Assert.IsNotNull(dbHsp);
            Assert.AreEqual(hsp.Name, dbHsp.Name);
            Assert.AreEqual(dbHsp.ServicesOffered[0], serviceName);
        }
    }
}