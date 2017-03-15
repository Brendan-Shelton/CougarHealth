using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;

namespace CoreProject.Data
{
    public class DbMgr
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
        public List<EnrolleePlan> PlanSet { get; set; }
        /// <summary>
        /// A fake DB set for primary enrollees that we create
        /// </summary>
        public List<PrimaryEnrollee> PrimaryEnrolleeSet { get; set; }

        public List<DependentEnrollee> DependentEnrolleSet { get; set; }
        /// <summary>
        /// a fake DB set for the different types of insurance plans and their 
        /// services 
        /// </summary>
        public IEnumerable<InsurancePlan> Plans => new List<InsurancePlan>()
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
            } // Extended
        }; // Plan

        /// <summary>
        /// For now this is does nothing but it will eventually initialize the
        /// db. We use the singleton pattern for this 
        /// </summary>
        private DbMgr()
        {
            PlanSet = new List<EnrolleePlan>(); 
            DependentEnrolleSet = new List<DependentEnrollee>();
            PrimaryEnrolleeSet = new List<PrimaryEnrollee>();
        }

        Enrollee.Enrollee e = new Enrollee.Enrollee();

        /// <summary>
        /// Method stub that will eventually retrieve an enrollee from the database 
        /// </summary>
        /// <param name="enrollee"></param>
        public void SaveEnrollee(PrimaryEnrollee enrollee)
        {
            PrimaryEnrolleeSet.Add(enrollee);    
        }

        public void SaveEnrolleePlan(EnrolleePlan plan)
        {
            PlanSet.Add(plan); 
        }

        public Enrollee.InsurancePlan GetPlanByType( string type )
        {
            
            return (from plan in Plans
                         where plan.Type == type
                         select plan).FirstOrDefault();
        }

        public IEnumerable<Enrollee.InsurancePlan> GetPlans()
        {
            return Plans;
        }

        /// <summary>
        /// Find the enrollee with the matching email and password. If no 
        /// enrollee exists then the query will return 0 and in which case 
        /// we return null.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        public int? Login(string email, string pin)
        {
            var resultId =  (from enrollee in PrimaryEnrolleeSet
                where enrollee.Email == email && enrollee.Pin == pin
                select enrollee.Id).FirstOrDefault();
            // zero is default for set and not a valid id 
            if (resultId == 0) return null;
            return resultId;

        }

        /// <summary>
        /// get the primary enrollee object corresponding to the id provided
        /// </summary>
        /// <param name="primaryId"></param>
        /// <returns></returns>
        public PrimaryEnrollee FindPrimaryById(int primaryId)
        {
            return (from enrollee in PrimaryEnrolleeSet
                where enrollee.Id == primaryId
                select enrollee).FirstOrDefault();
        }

        /// <summary>
        /// Gets the EnrolleePlan object for the primary enrollee corresponding
        /// to the given primary id 
        /// </summary>
        /// <param name="primaryId"></param>
        /// <returns></returns>
        public EnrolleePlan GetPlanByPrimary(int primaryId)
        {
            return (from plan in PlanSet
                where plan.PrimaryEnrollee == primaryId
                select plan).FirstOrDefault();
        }
        public void SaveEnrollee(Enrollee.Enrollee enrollee) { }

        public Enrollee.Enrollee GetEnrolleeByName(String f, String l)
        {
            
            e.FirstName = "First";
            e.LastName = "Last";
            return e;
        }

        public Enrollee.EnrolleePlan GetPolicyByID(int ID)
        {
            Enrollee.InsurancePlan plan = new Enrollee.InsurancePlan();
            Enrollee.PrimaryEnrollee e = new Enrollee.PrimaryEnrollee();
            e.FirstName = "First";
            e.LastName = "Last";
            plan.Type = "Basic";
            Enrollee.EnrolleePlan r = new Enrollee.EnrolleePlan(e, plan);

            return r;
        }

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
                            Name = "Diagnostic Lab & X-Ray",
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
                            Name = "Diagnostic Lab & X-Ray",
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
