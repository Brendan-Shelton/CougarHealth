using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;
using CoreProject.Data;

namespace CoreProject.Controller.HSPControllers
{


    public class BillController
    {
        public DbMgr Mgr;
        public List<InsurancePlan> Plans;
        public Type planType;
        public Enrollee enrollee;
        public EnrolleePlan enrolleePlan;
        public InsurancePlan plan;

        public BillController()
        {
            this.Mgr = DbMgr.Instance;
            this.Plans = (List<InsurancePlan>)Mgr.GetPlans();
        }



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

        public bool CheckEnrollee(String name)
        {
            String[] nameArr = new String[2];
            nameArr = name.Split();
            if (Mgr.GetEnrolleeByName(nameArr[0], nameArr[1]) == null)
            {
                return false;
            }
            else
                enrollee = Mgr.GetEnrolleeByName(nameArr[0], nameArr[1]);
            return true;
        }

        public void getPlan()
        {
            Type type = enrolleePlan.GetType();
            plan = new Data.Enrollee.InsurancePlan();

            if ((type.ToString()).Equals(Plans[0].Type))
                plan = Plans[0];
            else
                plan = Plans[1];
        }







        public double[,] HSPCalculate(List<String> s, List<int> c)
        {
            // For each service, check plan, and what they pay, max allowed, then calculate based on charge and service provided

            String[] services = s.ToArray();
            int[] charges = c.ToArray();

            int serviceID = 0;
            double adjustedCharge = 0, enrolleeCharge = 0, HSPCharge = 0;
            getPlan();

            double[,] returnArr = new double[services.Length, 3];

            for (int i = 0; i < services.Length; i++)
            {
                for (int j = 0; j < plan.ServiceCosts.Length; j++)
                {
                    Console.WriteLine(services[i]);
                    Console.WriteLine(plan.ServiceCosts[j].Name);
                    if (plan.ServiceCosts[j].Name.Equals(services[i]))
                    {
                        serviceID = j;
                        break;
                    }
                }

                if (charges[i] > plan.ServiceCosts[serviceID].InNetMax.Item1)
                {
                    adjustedCharge = plan.ServiceCosts[serviceID].InNetMax.Item1;
                }
                else
                {
                    adjustedCharge = charges[i];
                }


                enrolleeCharge = ((adjustedCharge * (1 - plan.ServiceCosts[serviceID].PercentCoverage)) + plan.ServiceCosts[serviceID].RequiredCopayment);
                HSPCharge = (adjustedCharge * plan.ServiceCosts[serviceID].PercentCoverage);

                returnArr[i, 0] = adjustedCharge;
                returnArr[i, 1] = enrolleeCharge;
                returnArr[i, 2] = HSPCharge;
            }

            return returnArr;


        }

        public double[,] OHSPCalculate(String[] services, int[] charges)
        {
            getPlan();
            double[,] returnArr = new double[services.Length, 3];
            int serviceID = 0;

            for (int i = 0; i < services.Length; i++)
            {
                for (int j = 0; j < plan.ServiceCosts.Length; j++)
                {
                    if (plan.ServiceCosts[j].Name.Equals(services[i]))
                    {
                        serviceID = j;
                    }
                }



            }
            return returnArr;
        }
    }
}
