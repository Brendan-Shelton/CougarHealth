using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Controller.EmployeeControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;
using CoreProject.Data;
using CoreProject.Controller.EmployeeControllers;

namespace CoreProject.Controller.EmployeeControllers.Tests
{
    [TestClass()]
    public class CreatePlanControllerTests
    {
        /// <summary>
        /// Testing all variables with correct input, invalid input, and/or null/empty
        /// </summary>
        [TestMethod()]
        public void CreatePlanTest()
        {
            CreatePlanController CreatePlanCtrl = new CreatePlanController();

            // VALID variables
            string nameCorrect = "Correct";
            double PYMBValid = 1000;
            double APDValid = 1000;
            double OPMIValid = 1000;
            double OPMFValid = 1000;
            double primaryFeeValid = 10;
            double dependentFeeValid = 10;
            double primaryChangeValid = 10;
            double dependentChangeValid = 10;
            bool optionalTrue = true;
            List<Service> servicesValid = new List<Service>
            {
                new Service
                {
                    Name = "test",
                    Category = "test",
                    PercentCoverage = 0.8,
                    RequiredCopayment = 100,
                    InNetMax = new Tuple<double, Service.MaxPayRate>(100, Service.MaxPayRate.PCY)
                }
            };

            // empty variables
            string nameEmpty = "";
            List<Service> servicesEmpty = new List<Service>();

            // null variables
            string nameNull = null;
            List<Service> servicesNull = null;

            // BVA and Equivalance Paritioning on boundary 0, partitions: less than 0, greater than or equal to 0
            double PYMBZero = 0;
            double APDZero = 0;
            double OPMIZero = 0;
            double OPMFZero = 0;
            double primaryFeeZero = 0;
            double dependentFeeZero = 0;
            double primaryChangeZero = 0;
            double dependentChangeZero = 0;

            double PYMBNeg = -1;
            double APDNeg = -1;
            double OPMINeg = -1;
            double OPMFNeg = -1;
            double primaryFeeNeg = -1;
            double dependentFeeNeg = -1;
            double primaryChangeNeg = -1;
            double dependentChangeNeg = -1;


            // run tests

            // valid
            bool validTest = CreatePlanCtrl.CreatePlan(nameCorrect, PYMBValid, APDValid, OPMIValid,
                                                       OPMFValid, primaryFeeValid, dependentFeeValid,
                                                       primaryChangeValid, dependentChangeValid, optionalTrue,
                                                       servicesValid);
            // empty variables
            bool testEmpty = CreatePlanCtrl.CreatePlan(nameEmpty, PYMBValid, APDValid, OPMIValid,
                                                       OPMFValid, primaryFeeValid, dependentFeeValid,
                                                       primaryChangeValid, dependentChangeValid, optionalTrue,
                                                       servicesEmpty);

            // null vars
            bool testNull = CreatePlanCtrl.CreatePlan(nameNull, PYMBValid, APDValid, OPMIValid,
                                                       OPMFValid, primaryFeeValid, dependentFeeValid,
                                                       primaryChangeValid, dependentChangeValid, optionalTrue,
                                                       servicesNull);

            // BVA testing
            bool testZero = CreatePlanCtrl.CreatePlan(nameCorrect, PYMBZero, APDZero, OPMIZero,
                                                       OPMFZero, primaryFeeZero, dependentFeeZero,
                                                       primaryChangeZero, dependentChangeZero, optionalTrue,
                                                       servicesValid);

            bool testNeg = CreatePlanCtrl.CreatePlan(nameCorrect, PYMBNeg, APDNeg, OPMINeg,
                                                       OPMFNeg, primaryFeeNeg, dependentFeeNeg,
                                                       primaryChangeNeg, dependentChangeNeg, optionalTrue,
                                                       servicesValid);

            Assert.IsTrue(validTest);
            Assert.IsFalse(testEmpty);
            Assert.IsFalse(testNull);
            Assert.IsTrue(testZero);
            Assert.IsFalse(testNeg);



        }
        /// <summary>
        /// Testing all variables for correct input, invalid input, and/or null/empty inputs
        /// </summary>
        [TestMethod()]
        public void AddServiceTest()
        {
            CreatePlanController CreatePlanCtrl = new CreatePlanController();

            // VALID variables
            string nameValid = "Test";
            string categoryValid = "Test";
            string maxPayRateValid = "Day";
            double percentValid = 1;
            double copayValid = 50;
            double maxValid = 100;
            

            // empty strings
            string nameEmpty = "";
            string categoryEmpty = "";
            string maxPayRateEmpty = "";

            // null variabels
            string nameNull = null;
            string categoryNull = null;
            string maxPayRateNull = null;

            // BVA and Equivalance Partitioning on all values

            // For copay and max, must be >= 0
            double copayZero = 0;
            double maxZero = 0;

            // negative
            double copayNeg = -1;
            double maxNeg = -1;

            // For percent, must be <= 0 and >= 1

            //This will be converted to less than 1
            double percentGreaterOne = 1.01;

            double percentLessOne = 0.99;

            double percentGreaterZero = 0.01;
            double percentZero = 0;
            double percentLessZero = -0.01;

            // Tests
            Service testValid = CreatePlanCtrl.AddService(nameValid, categoryValid, copayValid,
                                                       percentValid, maxValid, maxPayRateValid);

            Service testEmpty = CreatePlanCtrl.AddService(nameEmpty, categoryEmpty, copayValid,
                                                      percentValid, maxValid, maxPayRateEmpty);

            Service testNull = CreatePlanCtrl.AddService(nameNull, categoryNull, copayValid,
                                                      percentValid, maxValid, maxPayRateNull);

            Service testZero = CreatePlanCtrl.AddService(nameValid, categoryValid, copayZero,
                                                      percentZero, maxZero, maxPayRateValid);

            Service testNeg = CreatePlanCtrl.AddService(nameValid, categoryValid, copayNeg,
                                                      percentLessZero, maxNeg, maxPayRateValid);

            Service testPercentGreaterOne = CreatePlanCtrl.AddService(nameValid, categoryValid, copayValid,
                                                      percentGreaterOne, maxValid, maxPayRateValid);

            Service testPercentLessOne = CreatePlanCtrl.AddService(nameValid, categoryValid, copayValid,
                                                      percentLessOne, maxValid, maxPayRateValid);

            Service testPercentGreaterZero = CreatePlanCtrl.AddService(nameValid, categoryValid, copayValid,
                                                      percentGreaterZero, maxValid, maxPayRateValid);

            Assert.AreEqual("Test", testValid.Name);
            Assert.AreEqual("ERROR", testEmpty.Name);
            Assert.AreEqual("ERROR", testNull.Name);
            Assert.AreEqual("Test", testZero.Name);
            Assert.AreEqual("ERROR", testNeg.Name);
            Assert.AreEqual("Test", testPercentGreaterOne.Name);
            Assert.AreEqual("Test", testPercentLessOne.Name);
            Assert.AreEqual("Test", testPercentGreaterZero.Name);


        }
    }
}