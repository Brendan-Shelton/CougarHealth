using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Data.Enrollee;

namespace CoreProject.Controller.EmployeeControllers
{
    public class CreatePlanController
    {
        DbMgr Mgr;
        public CreatePlanController()
        {
            Mgr = DbMgr.Instance;
        }
        /// <summary>
        /// Creates a plan and then sends to DbMgr to be saved
        /// </summary>
        /// <param name="name"></param>
        /// <param name="PYMB"></param>
        /// <param name="APD"></param>
        /// <param name="OPMI"></param>
        /// <param name="OPMF"></param>
        /// <param name="priamryFee"></param>
        /// <param name="dependentFee"></param>
        /// <param name="primaryChange"></param>
        /// <param name="dependentChange"></param>
        /// <param name="optional"></param>
        /// <returns></returns>
        public bool CreatePlan(String name, double PYMB, double APD, double OPMI,
                            double OPMF, double primaryFee, double dependentFee,
                            double primaryChange, double dependentChange, bool optional,
                            List<Service> serviceList)
        {
            //error checking here
            if (name != null && name != "" && PYMB >= 0 && APD >= 0 && OPMI >= 0 && OPMF >= 0
               && primaryChange >= 0 && dependentChange >= 0)
            {
                // create a new insurance plan
                InsurancePlan plan = new InsurancePlan
                {
                    Type = name,
                    PYMB = PYMB,
                    APD = APD,
                    OPMIndividual = OPMI,
                    OPMFamily = OPMF,
                    PrimaryFee = primaryFee,
                    DependentFee = dependentFee,
                    PrimaryChangeFee = primaryChange,
                    DependentChangeFee = dependentChange,
                    Optional = optional,
                    ServiceCosts = serviceList
                };

                Mgr.AddPlan(plan);

                return true;
            }

            else
            {
                return false;
            }
        }
        /// <summary>
        /// Creates a new service and returns it to the GUI to be displayed
        /// </summary>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <param name="copay"></param>
        /// <param name="percent"></param>
        /// <param name="max"></param>
        /// <param name="maxPayRate"></param>
        /// <returns></returns>
        public Service AddService(string name, string category, double copay,
                               double percent, double max, string maxPayRate)
        {
            // error check here

            Service.MaxPayRate maxPayEnum;

            if (maxPayRate.Equals("Day"))
                maxPayEnum = Service.MaxPayRate.Day;
            else if (maxPayRate.Equals("Session"))
                maxPayEnum = Service.MaxPayRate.Session;
            else
                maxPayEnum = Service.MaxPayRate.PCY;

            return new Service
            {
                Name = name,
                Category = category,
                PercentCoverage = percent,
                RequiredCopayment = copay,
                InNetMax = new Tuple<double, Service.MaxPayRate>(max, maxPayEnum)
            };
        }
    }
}
