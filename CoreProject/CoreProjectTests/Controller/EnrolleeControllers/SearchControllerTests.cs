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
            //Arrange
            var ctrl = new SearchController();
            string nullName = null;
            string emptyName = "";
            string isName = "Basic";
            string random = "aaaaaaa";

            //Act
            InsurancePlan nullPlan = ctrl.GetPlan(nullName);
            InsurancePlan emptyPlan = ctrl.GetPlan(emptyName);
            InsurancePlan truePlan = ctrl.GetPlan(isName);
            InsurancePlan randomPlan = ctrl.GetPlan(random);

            //Assert
            Assert.IsNull(nullPlan);
            Assert.IsNull(emptyPlan);
            Assert.IsNotNull(truePlan);
            Assert.AreEqual("Basic", truePlan.Type);
            Assert.IsNull(randomPlan);
        }

        [TestMethod()]
        public void GetPlansTest()
        {
            //Arrange
            var ctrl = new SearchController();


            List<InsurancePlan> results = null;

            //Act

            results = (List<InsurancePlan>)ctrl.GetPlans();

            //Assert

            Assert.IsNotNull(results);
        }

        [TestMethod()]
        public void GetProvidersTest()
        {
            //Arange
            var ctrl = new SearchController();
            var plan = ctrl.GetPlan("Basic");
            string testName = "Name";

            string trueService = "Inpatient";
            string nullService = null;
            string emptyService = "";
            string randomService = "BlahBlah";

            List<HSP> trueResults = null;
            List<HSP> nullResults = null;
            List<HSP> emptyResults = null;
            List<HSP> randomResults = null;

            //Act

            trueResults = (List<HSP>)ctrl.GetProviders(trueService);
            nullResults = (List<HSP>)ctrl.GetProviders(nullService);
            emptyResults = (List<HSP>)ctrl.GetProviders(emptyService);
            randomResults = (List<HSP>)ctrl.GetProviders(randomService);

            //Assert

            Assert.IsNotNull(trueResults);
            Assert.AreEqual(testName, trueResults[0].Name);
            Assert.IsNull(nullResults);
            Assert.IsNull(emptyResults);
            Assert.IsNull(randomResults);

        }
    }
}