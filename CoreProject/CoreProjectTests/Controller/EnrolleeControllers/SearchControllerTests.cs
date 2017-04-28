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
            string typeTest = "Basic";
            var ctrl = new SearchController();
            InsurancePlan ctrlResult = null;

            InsurancePlan testPlan = new InsurancePlan()
            {
                Id = 1,
                Type = "Basic",
                APD = 250.0,
                PYMB = 250000.0,
                DependentFee = 20.0,
                PrimaryFee = 45.0,
                DependentChangeFee = 40.0,
                PrimaryChangeFee = 150.0,
                OPMFamily = 18000,
                OPMIndividual = 9500,
                ServiceCosts = new List<Service>
                {
                    new Service
                    {
                        Category = "Hospital",
                        Name = "Inpatient",
                        PercentCoverage = 0.9,
                        RequiredCopayment = 400.0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            2000,
                            Service.MaxPayRate.Day
                        )
                    },
                    new Service
                    {
                        Category = "Hospital",
                        Name = "Inpatient (Behavioral Health",
                        PercentCoverage = 0.9,
                        RequiredCopayment = 400.0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            1500,
                            Service.MaxPayRate.Day
                        )
                    },
                    new Service
                    {
                        Category = "Hospital",
                        Name = "Emergency Room",
                        PercentCoverage = 1,
                        RequiredCopayment = 250.0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            1000,
                            Service.MaxPayRate.PCY
                        )

                    },
                    new Service
                    {
                        Category = "Hospital",
                        Name = "Outpatient Surgery",
                        PercentCoverage = 0.9,
                        RequiredCopayment = 250,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            4000,
                            Service.MaxPayRate.PCY
                        )

                    },
                    new Service
                    {
                        Category = "Hospital",
                        Name = "Diagnostic Lab and x-ray",
                        PercentCoverage = .9,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            500,
                            Service.MaxPayRate.PCY
                        )

                    },
                    new Service
                    {
                        Category = "Physician",
                        Name = "Office Visit",
                        PercentCoverage = .9,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            150,
                            Service.MaxPayRate.PCY
                        )
                    },
                    new Service
                    {
                        Category = "Physician",
                        Name = "Specialist Visit",
                        PercentCoverage = .9,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            300,
                            Service.MaxPayRate.PCY
                        )
                    },
                    new Service
                    {
                        Category = "Physician",
                        Name = "Preventive Services",
                        PercentCoverage = 1,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            25,
                            Service.MaxPayRate.PCY
                        )
                    },
                    new Service
                    {
                        Category = "Physician",
                        Name = "Baby Services",
                        PercentCoverage = 1,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            300,
                            Service.MaxPayRate.PCY
                        )
                    },
                    new Service
                    {
                        Category = "Other",
                        Name = "Durable Medical Equipment",
                        PercentCoverage = .8,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            300,
                            Service.MaxPayRate.PCY
                        )
                    },
                    new Service
                    {
                        Category = "Other",
                        Name = "Nursing Facility",
                        PercentCoverage = .9,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            250,
                            Service.MaxPayRate.Day
                        )
                    },
                    new Service
                    {
                        Category = "Other",
                        Name = "Physical Therapy",
                        PercentCoverage = .9,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            100, Service.MaxPayRate.Session
                        )
                    }
                } // ServiceCosts
            };

            //Act

            ctrlResult = ctrl.GetPlan(typeTest);

            //Assert

            Assert.AreEqual(testPlan.Id, ctrlResult.Id);
            Assert.AreEqual(testPlan.Type, ctrlResult.Type);
            //            Assert.Fail();
        }

        [TestMethod()]
        public void GetPlansTest()
        {
            //Arrange
            var ctrl = new SearchController();
            List<InsurancePlan> testPlans = new List<InsurancePlan>()
            {
             new InsurancePlan()
             {
                Id = 1,
                Type = "Basic",
                APD = 250.0,
                PYMB = 250000.0,
                DependentFee = 20.0,
                PrimaryFee = 45.0,
                DependentChangeFee = 40.0,
                PrimaryChangeFee = 150.0,
                OPMFamily = 18000,
                OPMIndividual = 9500,
                ServiceCosts = new List<Service>
                {
                    new Service
                    {
                        Category = "Hospital",
                        Name = "Inpatient",
                        PercentCoverage = 0.9,
                        RequiredCopayment = 400.0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            2000,
                            Service.MaxPayRate.Day
                        )
                    },
                    new Service
                    {
                        Category = "Hospital",
                        Name = "Inpatient (Behavioral Health",
                        PercentCoverage = 0.9,
                        RequiredCopayment = 400.0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            1500,
                            Service.MaxPayRate.Day
                        )
                    },
                    new Service
                    {
                        Category = "Hospital",
                        Name = "Emergency Room",
                        PercentCoverage = 1,
                        RequiredCopayment = 250.0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            1000,
                            Service.MaxPayRate.PCY
                        )

                    },
                    new Service
                    {
                        Category = "Hospital",
                        Name = "Outpatient Surgery",
                        PercentCoverage = 0.9,
                        RequiredCopayment = 250,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            4000,
                            Service.MaxPayRate.PCY
                        )

                    },
                    new Service
                    {
                        Category = "Hospital",
                        Name = "Diagnostic Lab and x-ray",
                        PercentCoverage = .9,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            500,
                            Service.MaxPayRate.PCY
                        )

                    },
                    new Service
                    {
                        Category = "Physician",
                        Name = "Office Visit",
                        PercentCoverage = .9,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            150,
                            Service.MaxPayRate.PCY
                        )
                    },
                    new Service
                    {
                        Category = "Physician",
                        Name = "Specialist Visit",
                        PercentCoverage = .9,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            300,
                            Service.MaxPayRate.PCY
                        )
                    },
                    new Service
                    {
                        Category = "Physician",
                        Name = "Preventive Services",
                        PercentCoverage = 1,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            25,
                            Service.MaxPayRate.PCY
                        )
                    },
                    new Service
                    {
                        Category = "Physician",
                        Name = "Baby Services",
                        PercentCoverage = 1,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            300,
                            Service.MaxPayRate.PCY
                        )
                    },
                    new Service
                    {
                        Category = "Other",
                        Name = "Durable Medical Equipment",
                        PercentCoverage = .8,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            300,
                            Service.MaxPayRate.PCY
                        )
                    },
                    new Service
                    {
                        Category = "Other",
                        Name = "Nursing Facility",
                        PercentCoverage = .9,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            250,
                            Service.MaxPayRate.Day
                        )
                    },
                    new Service
                    {
                        Category = "Other",
                        Name = "Physical Therapy",
                        PercentCoverage = .9,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            100, Service.MaxPayRate.Session
                        )
                    }
                } // ServiceCosts
            }, // Basic 
            new InsurancePlan()
            {
                Id = 2,
                Type = "Extended",
                APD = 0,
                PYMB = 1000000.0,
                DependentFee = 25.0,
                PrimaryFee = 65.0,
                DependentChangeFee = 20.0,
                PrimaryChangeFee = 50.0,
                OPMFamily = 12000,
                OPMIndividual = 6500,
                ServiceCosts = new List<Service>
                {
                    new Service
                    {
                        Category = "Hospital",
                        Name = "Inpatient",
                        PercentCoverage = 1,
                        RequiredCopayment = 300.0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            2000,
                            Service.MaxPayRate.Day
                        )
                    },
                    new Service
                    {
                        Category = "Hospital",
                        Name = "Inpatient (Behavioral Health",
                        PercentCoverage = 1,
                        RequiredCopayment = 300.0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            1500,
                            Service.MaxPayRate.Day
                        )

                    },
                    new Service
                    {
                        Category = "Hospital",
                        Name = "Emergency Room",
                        PercentCoverage = 1,
                        RequiredCopayment = 250.0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            1000,
                            Service.MaxPayRate.PCY
                        )
                    },
                    new Service
                    {
                        Category = "Hospital",
                        Name = "Outpatient Surgery",
                        PercentCoverage = 1,
                        RequiredCopayment = 250,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            4000,
                            Service.MaxPayRate.PCY
                        )

                    },
                    new Service
                    {
                        Category = "Hospital",
                        Name = "Diagnostic Lab and x-ray",
                        PercentCoverage = 1.0,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            500,
                            Service.MaxPayRate.PCY
                        )
                    },
                    new Service
                    {
                        Category = "Physician",
                        Name = "Office Visit",
                        PercentCoverage = 1,
                        RequiredCopayment = 20,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            150,
                            Service.MaxPayRate.PCY
                        )
                    },
                    new Service
                    {
                        Category = "Physician",
                        Name = "Specialist Visit",
                        PercentCoverage = 1,
                        RequiredCopayment = 30,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            300,
                            Service.MaxPayRate.PCY
                        )

                    },
                    new Service
                    {
                        Category = "Physician",
                        Name = "Preventive Services",
                        PercentCoverage = 1,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            25,
                            Service.MaxPayRate.PCY
                        )

                    },
                    new Service
                    {
                        Category = "Physician",
                        Name = "Baby Services",
                        PercentCoverage = 1,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            300,
                            Service.MaxPayRate.PCY
                        )

                    },
                    new Service
                    {
                        Category = "Other",
                        Name = "Durable Medical Equipment",
                        PercentCoverage = .8,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            300,
                            Service.MaxPayRate.PCY
                        )

                    },
                    new Service
                    {
                        Category = "Other",
                        Name = "Nursing Facility",
                        PercentCoverage = 1,
                        RequiredCopayment = 0,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            250,
                            Service.MaxPayRate.Day
                        )

                    },
                    new Service
                    {
                        Category = "Other",
                        Name = "Physical Therapy",
                        PercentCoverage = 1,
                        RequiredCopayment = 30,
                        InNetMax = new Tuple<double, Service.MaxPayRate>(
                            100, Service.MaxPayRate.Session
                        )
                    }
                } // ServiceCosts
            } // Extended
        };

            List<InsurancePlan> results;

            //Act

            results = (List<InsurancePlan>)ctrl.GetPlans();

            //Assert

            Assert.AreEqual(testPlans.ToString(), results.ToString());
            //        Assert.Fail();
        }

        [TestMethod()]
        public void GetProvidersTest()
        {
            //Arange
            var ctrl = new SearchController();
            var plan = ctrl.GetPlan("Basic");

            string service = "Inpatient";

            List<HSP> results;

            List<HSP> testHSP = new List<HSP>
            {
                new HSP("1234", true)
                {
                    Name = "Jones Hospital",
                    ServicesOffered = null/*{ "Inpatient", "Inpatient (Behavioral Health",
                                        "Emergency Room", "Outpatient Surgery", "Diagnostic Lab and x-ray",
                                        "Office Visit", "Specialist Visit", "Preventive Services", "Baby Services",
                                        "Durable Medical Equipment", "Nursing Facility", "Physical Therapy" }*/,
                    Address = "123 North Elm, Anytown, New York"

                },
                new HSP("2345", true)
                {
                    Name = "Mercy Hospital",
                    ServicesOffered = null/*{ "Inpatient", "Inpatient (Behavioral Health",
                                        "Emergency Room", "Outpatient Surgery", "Diagnostic Lab and x-ray",
                                        "Office Visit", "Specialist Visit", "Preventive Services", "Baby Services",
                                        "Durable Medical Equipment"}*/,
                    Address = "555 West Madison, Nowhere, Kansas"
                },
                new HSP("5555", true)
                {
                    Name = "St John's University Hospital",
                    ServicesOffered = null/*{ "Inpatient", "Inpatient (Behavioral Health",
                                        "Emergency Room", "Diagnostic Lab and x-ray",
                                        "Office Visit", "Specialist Visit", "Preventive Services", "Baby Services",
                                        "Durable Medical Equipment", "Physical Therapy" }*/,
                    Address = "420 Baker Street, High Town, Washington"
                }
            };

            //Act

            results = (List<HSP>)ctrl.GetProviders(service);

            //Assert

            Assert.AreEqual(testHSP[0].Name, results[0].Name);

//            Assert.Fail();
        }
    }
}