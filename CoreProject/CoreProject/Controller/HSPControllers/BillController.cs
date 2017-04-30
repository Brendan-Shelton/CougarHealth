using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;
using CoreProject.Data;
using CoreProject.Data.HealthcareServiceProvider;

namespace CoreProject.Controller.HSPControllers
{


    public class BillController
    {
        public DbMgr Mgr { get; private set; }
        private List<InsurancePlan> Plans;
        private Enrollee enrollee;
        private EnrolleePlan enrolleePlan;
        private InsurancePlan plan;
        private HSP hsp;
        /// <summary>
        /// Creates a new Plans List and DbMGr Instance
        /// </summary>
        public BillController()
        {
            this.Mgr = DbMgr.Instance;
            this.Plans = (List<InsurancePlan>)Mgr.GetPlans();
        }

        public void setHSP(HSP hsp)
        {
            this.hsp = hsp;
        }

        /// <summary>
        /// Checks to see if the policy is valid.
        /// </summary>
        /// <param name="policyID"></param>
        /// <returns></returns>
        public bool CheckPolicy(int policyID)
        {
            if (Mgr.GetPolicyByID(policyID) == null)
            {
                return false;
            }
            else
            {
                enrolleePlan = Mgr.GetPolicyByID(policyID);
                return true;
            }

        }
        /// <summary>
        ///  Checks to see if Enrollee is valid.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckEnrollee(String email)
        {
            
                if (Mgr.GetEnrolleeByEmail(email) == null)
                {
                    return false;
                }
                else
                {
                    enrollee = Mgr.GetEnrolleeByEmail(email);
                    return true;
                }

        }

        public bool CheckHSP(String hspName)
        {
            if (Mgr.GrabHspByName(hspName) == null)
            {
                return false;
            }
            else
            {
                hsp = Mgr.GrabHspByName(hspName);
                return true;
            }
        }

        public bool getHspType()
        {
            return hsp.InNetwork;
        }
        // Not sure if this is needed
        public void getPlan()
        {
            List<EnrolleePlan> ePlan = (List<EnrolleePlan>)Mgr.GetPlanByPrimary(enrollee.Id);

            List<Service> services;
            foreach(var item in ePlan)
            {
                services = (List<Service>)Mgr.GetServicesByPlan(item.Plan.Type);
                Service service = services.ElementAt(0);
                plan = Mgr.GetPlanByType(item.Type);
                if (service.insurancePlanId == item.Plan.Id)
                {
                    break;
                }

                
                

            }
            
        }





        
        /// <summary>
        /// Calculates the costs for In-Network HSPs
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public String[,] HSPCalculate(List<String> s, List<int> c, DateTime date)
        {
            // For each service, check plan, and what they pay, max allowed, then calculate based on charge and service provided

            String[] services = s.ToArray();
            int[] charges = c.ToArray();

            int serviceID = 0;
            double adjustedCharge = 0, enrolleeCharge = 0, HSPCharge = 0;
            getPlan();

            String[,] returnArr = new String[services.Length, 4];

            for (int i = 0; i < services.Length; i++)
            {
                // find service ID
                for (int j = 0; j < plan.ServiceCosts.Count(); j++)
                {
                    Console.WriteLine(services[i]);
                    Console.WriteLine(plan.ServiceCosts[j].Name);
                    if (plan.ServiceCosts[j].Name.Equals(services[i]))
                    {
                        serviceID = j;
                        break;
                    }
                }
                //Adjusts charge if charge is greater than the In Network Maximum.
                if (charges[i] > plan.ServiceCosts[serviceID].InNetMax.Item1)
                {
                    adjustedCharge = plan.ServiceCosts[serviceID].InNetMax.Item1;
                }
                else
                {
                    adjustedCharge = charges[i];
                }

                // Calculate enrolleeCharge and HSPCharge
                enrolleeCharge = (((adjustedCharge - plan.ServiceCosts[serviceID].RequiredCopayment) * (1 - plan.ServiceCosts[serviceID].PercentCoverage)) + plan.ServiceCosts[serviceID].RequiredCopayment);
                HSPCharge = ((adjustedCharge - plan.ServiceCosts[serviceID].RequiredCopayment) * plan.ServiceCosts[serviceID].PercentCoverage);
                returnArr[i, 0] = plan.ServiceCosts[serviceID].Name;
                returnArr[i, 1] = adjustedCharge.ToString();
                returnArr[i, 2] = enrolleeCharge.ToString();
                returnArr[i, 3] = HSPCharge.ToString();
                enrolleePlan.AddCharge(date, hsp, plan.ServiceCosts[serviceID], enrollee.Id, enrollee.Email, adjustedCharge, enrolleeCharge);
            }

            return returnArr;


        }
        /// <summary>
        /// Calculates the charge for Out-Of-Network HSPs
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public String[,] OHSPCalculate(List<String> s, List<int> c, DateTime date)
        {
            String[] services = s.ToArray();
            int[] charges = c.ToArray();

            getPlan();
            String[,] returnArr = new String[services.Length, 4];
            double enrolleeCharge = 0, HSPCharge = 0, adjustedCharge = 0;
            int serviceID = 0;

            for (int i = 0; i < services.Length; i++)
            {
                // Find service ID
                for (int j = 0; j < plan.ServiceCosts.Count(); j++)
                {
                    if (plan.ServiceCosts[j].Name.Equals(services[i]))
                    {
                        serviceID = j;
                        break;
                    }
                }
                adjustedCharge = plan.ServiceCosts[serviceID].InNetMax.Item1;
                //Calculate enrolleeCharge differently if charges is more than the max allowed vs less.
                if (charges[i] < adjustedCharge)
                {
                    adjustedCharge = charges[i];
                    enrolleeCharge = (((adjustedCharge - plan.ServiceCosts[serviceID].RequiredCopayment) * (1 - plan.ServiceCosts[serviceID].PercentCoverage)) + plan.ServiceCosts[serviceID].RequiredCopayment);
                }
                else
                {
                    enrolleeCharge = ((charges[i] - adjustedCharge) + (((adjustedCharge - plan.ServiceCosts[serviceID].RequiredCopayment) * (1 - plan.ServiceCosts[serviceID].PercentCoverage)) + plan.ServiceCosts[serviceID].RequiredCopayment));
                }
                // Calculate HSP Charge.
                HSPCharge = ((adjustedCharge - plan.ServiceCosts[serviceID].RequiredCopayment) * plan.ServiceCosts[serviceID].PercentCoverage);
                returnArr[i, 0] = plan.ServiceCosts[serviceID].Name;
                returnArr[i, 1] = charges[i].ToString();
                returnArr[i, 2] = enrolleeCharge.ToString();
               
                returnArr[i, 3] = HSPCharge.ToString();
                enrolleePlan.AddCharge(date, hsp, plan.ServiceCosts[serviceID], enrollee.Id, enrollee.Email, adjustedCharge, enrolleeCharge);
            }
            return returnArr;
        }
    }
}
