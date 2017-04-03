using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;
using CoreProject.Data.HealthcareServiceProvider;
using CoreProject.Data.Employees;

namespace CoreProject.Data
{
    public class DbMgr
    {
        private static DbMgr _instance;

        private int AdminPassKey = 1234;

        

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
        public HashSet<EnrolleePlan> PlanSet { get; set; }
        /// <summary>
        /// A fake DB set for primary enrollees that we create
        /// </summary>
        public HashSet<PrimaryEnrollee> PrimaryEnrolleeSet { get; set; }

        public HashSet<DependentEnrollee> DependentEnrolleSet { get; set; }


        public HashSet<HSP> HspSet { get; }
        public HashSet<Employee> EmployeeSet { get; } = new HashSet<Employee>()
        {
            // the test employee.
            new Employee
            {
                UserName = "Guest",
                Password = "guest",
                Permission = Permission.Manager
            }
        };
        /// <summary>
        /// TEMP method to allow logging in as guest when no one is in the system 
        /// </summary>
        /// <returns></returns>
        internal Employee GetGuest()
        {
            return ( from employee in EmployeeSet
                     where employee.UserName == "Guest"
                     select employee )?.FirstOrDefault();
        }
        /// <summary>
        /// a fake DB set for the different types of insurance plans and their 
        /// services 
        /// </summary>
        public List<InsurancePlan> Plans => new List<InsurancePlan>()
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
        /// Saves an entire employee object into the database. If the employee 
        /// was already inserted it throws a DataException
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int SaveEmployee(Employee employee)
        {

            if ( !EmployeeSet.Add(employee) )
            {
                throw new DataException($"{employee.UserName} was already in our system");
            }

            return employee.Id;
        }

        public Employee GetEmployeeById ( int id )
        {
            var result = ( from employee in EmployeeSet
                           where employee.Id == id
                           select employee )?.FirstOrDefault();

            return result;
        }

        public void adminUpdateVerify(int passkey, int planType, String category,
            String name, Boolean percent, double val)
        {
            if (passkey == AdminPassKey)
            {
                adminUpdatePlan(planType, category, name, percent, val);
            }
        }



        /// <summary>
        /// Takes an int, String, String, Bool, and int and updates the corresponding values of the insurance plan
        /// </summary>
        /// <param name="planType"></param>
        /// <param name="category"></param>
        /// <param name="name"></param>
        /// <param name="percent"></param>
        /// <param name="val"></param>
        
        private void adminUpdatePlan(int planType, String category, String name, Boolean percent, double val)
        {

            //APD = 250.0,
            //    PYMB = 250000.0,
            //    DependentFee = 20.0,
            //    PrimaryFee = 45.0,
            //    DependentChangeFee = 40.0,
            //    PrimaryChangeFee = 150.0,
            //    OPMFamily = 18000,
            //    OPMIndividual = 9500,


            for (int i = 0; i < 2; i++)
            {
                if (Plans[i].Id == planType)
                {
                    if (category.Equals("Benefits"))
                    {
                        switch (name)
                        {
                            case "APD": Plans[i].APD = val;
                                break;
                            case "PYMB": Plans[i].PYMB = val;
                                break;
                            case "DependentFee": Plans[i].DependentFee = val;
                                break;
                            case "PrimaryFee": Plans[i].PrimaryFee = val;
                                break;
                            case "DependentChangeFee": Plans[i].DependentChangeFee = val;
                                break;
                            case "PrimaryChangeFee": Plans[i].PrimaryChangeFee = val;
                                break;
                            case "OPMFamily": Plans[i].OPMFamily = val;
                                break;
                            case "OPMIndividual": Plans[i].OPMIndividual = val;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < Plans[i].ServiceCosts.Length; j++)
                        {
                            if (Plans[i].ServiceCosts[j].Category.Equals(category) &&
                                Plans[i].ServiceCosts[j].Name.Equals(name))
                            {
                                if (percent == true)
                                {
                                    Plans[i].ServiceCosts[j].PercentCoverage = val;
                                }
                                else
                                {
                                    Plans[i].ServiceCosts[j].RequiredCopayment = val;
                                }
                            }
                        }
                    }
                }

            }
        }


        /// <summary>
        /// For now this is does nothing but it will eventually initialize the
        /// db. We use the singleton pattern for this 
        /// </summary>
        private DbMgr()
        {
            PlanSet = new HashSet<EnrolleePlan>(); 
            DependentEnrolleSet = new HashSet<DependentEnrollee>();
            PrimaryEnrolleeSet = new HashSet<PrimaryEnrollee>();
            HspSet = new HashSet<HSP>();
        }

        /// <summary>
        /// Method stub that will eventually save an enrollee from the database 
        /// if the enrollee already exists we throw a data exception
        /// </summary>
        /// <param name="enrollee"></param>
        public void SaveEnrollee(PrimaryEnrollee enrollee)
        {
            if ( !PrimaryEnrolleeSet.Add(enrollee) )
            {
                throw new DataException($"{enrollee.FirstName} was already in our system");
            }
        }

        /// <summary>
        /// Save an enrollee plan into the database if  
        /// </summary>
        /// <param name="plan"></param>
        public void SaveEnrolleePlan(EnrolleePlan plan)
        {
            if ( !PlanSet.Add(plan) )
            {
                var updatePlan = ( from policy in PlanSet
                                   where policy.PrimaryEnrollee == plan.PrimaryEnrollee
                                   select policy ).First();
                plan.PlanNum = updatePlan.PlanNum;
                PlanSet.Remove(updatePlan);
            PlanSet.Add(plan); 
        }
        }

        /// <summary>
        /// Adds a new HSP object into the database if it doesn't already exist
        /// in the database. If the hsp object already exists in the database 
        /// then it'll throw a DataException
        /// </summary>
        /// <param name="hsp"></param>
        public void SaveHsp( HSP hsp )
        {
            if ( !HspSet.Add(hsp) )
            {
                throw new DataException("Hsp already exists in the database"); 
            }
        }

        /// <summary>
        /// grabs a hsp object by it's primary key 
        /// </summary>
        /// <param name="hspId"></param>
        /// <returns></returns>
        public HSP GrabHspById( int hspId )
        {
            return ( from hsp in HspSet
                     where hsp.Id == hspId
                     select hsp ).FirstOrDefault();
        }

        /// <summary>
        /// grabs a hsp object by it's uniquely identifiable name
        /// </summary>
        /// <param name="hspId"></param>
        /// <returns></returns>
        public HSP GrabHspByName( string hspName )
        {
            return ( from hsp in HspSet
                     where hsp.Name == hspName
                     select hsp ).FirstOrDefault();
        }

        public Enrollee.InsurancePlan GetPlanByType( string type )
        {
            
            return ( from plan in Plans
                     where plan.Type == type
                     select plan ).FirstOrDefault();
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
            var resultId =  ( from enrollee in PrimaryEnrolleeSet
                              where enrollee.Email == email && enrollee.Pin == pin
                              select enrollee.Id ).FirstOrDefault();
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
            return ( from enrollee in PrimaryEnrolleeSet
                     where enrollee.Id == primaryId
                     select enrollee ).FirstOrDefault();
        }

        /// <summary>
        /// Gets the EnrolleePlan object for the primary enrollee corresponding
        /// to the given primary id 
        /// </summary>
        /// <param name="primaryId"></param>
        /// <returns></returns>
        public EnrolleePlan GetPlanByPrimary(int primaryId)
        {
            return ( from plan in PlanSet
                     where plan.PrimaryEnrollee == primaryId
                     select plan ).FirstOrDefault();
        }
        public void SaveEnrollee(Enrollee.Enrollee enrollee) { }

        public Enrollee.Enrollee GetEnrolleeByName(String f, String l)
        {
            var primary = ( from enrollee in this.PrimaryEnrolleeSet
                            where f == enrollee.FirstName && l == enrollee.LastName
                            select enrollee ).FirstOrDefault();
            return primary;
        }

        public Enrollee.EnrolleePlan GetPolicyByID(int ID)
        {
            var r = ( from plan in PlanSet
                      where plan.PlanNum == ID
                      select plan ).FirstOrDefault();
            return r;
        }

        /// <summary>
        /// Search for the user name and password of the employee 
        /// provided through the database
        /// </summary>
        /// <param name="checkEmployee">The employee encapsulating the info we are searching for</param>
        /// <returns>The employee match (could be null)</returns>
        public Employee EmployeeLogin(Employee checkEmployee)
        {
            var employeeResult = ( from employee in EmployeeSet
                                   where checkEmployee.UserName == employee.UserName &&
                                         checkEmployee.Password == employee.Password
                                   select employee )?.FirstOrDefault();
            return employeeResult;
        }

    }
}
