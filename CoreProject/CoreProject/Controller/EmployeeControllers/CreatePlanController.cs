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
            List<InsurancePlan> plans = (List<InsurancePlan>)Mgr.GetPlans();
           
            //error checking here
            if (name != null && name != "" && PYMB >= 0 && APD >= 0 && OPMI >= 0 && OPMF >= 0
               && primaryChange >= 0 && dependentChange >= 0)
            {
                foreach(var item in plans)
                {
                    if (name.Equals(item.Type))
                        return false;
                }
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
            Service service = null;
            Service.MaxPayRate maxPayEnum;
            if (name != null && name != "" && category != null && category != "" && percent <= 100 
                && percent >= 0 && copay >= 0 && max >= 0 && maxPayRate != "" && maxPayRate != null)
            {
                if (maxPayRate.Equals("Day"))
                    maxPayEnum = Service.MaxPayRate.Day;
                else if (maxPayRate.Equals("Session"))
                    maxPayEnum = Service.MaxPayRate.Session;
                else
                    maxPayEnum = Service.MaxPayRate.PCY;

                if (percent >= 1)
                    percent = percent / 100;


                service = new Service
                {
                    Name = name,
                    Category = category,
                    PercentCoverage = percent,
                    RequiredCopayment = copay,
                    InNetMax = new Tuple<double, Service.MaxPayRate>(max, maxPayEnum)
                };
            }

            return service;
            
        }
    }
}
