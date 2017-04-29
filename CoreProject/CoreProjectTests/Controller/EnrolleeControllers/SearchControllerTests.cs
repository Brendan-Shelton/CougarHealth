using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Controller.EnrolleeControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;
using CoreProject.Data.HealthcareServiceProvider;
using System.Collections;

namespace CoreProject.Controller.EnrolleeControllers.Tests
{
    [TestClass()]
    public class SearchControllerTests
    {
        [TestMethod()]
        public void GetPlanTest()
        {
            ////Arrange
            //string typeTest = "Basic";
            //string idTest = "1";
            //var ctrl = new SearchController();
            //InsurancePlan ctrlResult = null;

            

            ////Act

            //ctrlResult = ctrl.GetPlan(typeTest);

            ////Assert

            //Assert.AreEqual(testPlan.Id, ctrlResult.Id);
            //Assert.AreEqual(testPlan.Type, ctrlResult.Type);
            ////            Assert.Fail();
        }

        [TestMethod()]
        public void GetPlansTest()
        {
            ////Arrange
            //var ctrl = new SearchController();


            //List<InsurancePlan> results;

            ////Act

            //results = (List<InsurancePlan>)ctrl.GetPlans();

            ////Assert

            //Assert.AreEqual(testPlans.ToString(), results.ToString());
            ////        Assert.Fail();
        }

        [TestMethod()]
        public void GetProvidersTest()
        {
//            //Arange
//            var ctrl = new SearchController();
//            var plan = ctrl.GetPlan("Basic");

//            string service = "Inpatient";

//            List<HSP> results;

            

//            //Act

//            results = (List<HSP>)ctrl.GetProviders(service);

//            //Assert

//            Assert.AreEqual(testHSP[0].Name, results[0].Name);

////            Assert.Fail();
        }
    }
}