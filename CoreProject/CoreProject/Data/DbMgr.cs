using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;

namespace CoreProject.Data
{
    class DbMgr
    {
        private static DbMgr _instance;
        /// <summary>
        /// get the single instance of DbMgr allowed in the application
        /// 
        /// a bit about the C# magic: this is a static readonly property of 
        /// DbMgr class. The arrow is a lambda express (think of a one line 
        /// function) that returns the private _instance static field if it 
        /// is not null (that is what the '??' operator is for). If it is null
        /// it instantiates the _instance field and then returns it 
        /// </summary>
        public static DbMgr Instance => _instance ?? (_instance = new DbMgr());

        /// <summary>
        /// For now this is does nothing but it will eventually initialize the
        /// db. We use the singleton pattern for this 
        /// </summary>
        private DbMgr()
        {
            
        }

        /// <summary>
        /// Method stub that will eventually retrieve an enrollee from the database 
        /// </summary>
        /// <param name="enrollee"></param>
        public void SaveEnrollee(Enrollee.Enrollee enrollee) { }

        public IEnumerable<Enrollee.InsurancePlan> GetPlans()
        {
            return new List<InsurancePlan>()
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
                    ServiceCosts = new[]
                    {
                        new Service
                        {
                            Category = "Hospital",
                            Name = "inpatient",
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
                    ServiceCosts = new[]
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
                }
            }; // List<InsurancePlan
        }
    }
}
