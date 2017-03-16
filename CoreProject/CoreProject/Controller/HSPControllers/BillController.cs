﻿using System;
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
        /// <summary>
        /// Creates a new Plans List and DbMGr Instance
        /// </summary>
        public BillController()
        {
            this.Mgr = DbMgr.Instance;
            this.Plans = (List<InsurancePlan>)Mgr.GetPlans();
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
        // Not sure if this is needed
        public void getPlan()
        {
            if (enrolleePlan.Type.Equals(Plans[0].Type))
                plan = Plans[0];
            else
                plan = Plans[1];
        }





        
        /// <summary>
        /// Calculates the costs for In-Network HSPs
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public String[,] HSPCalculate(List<String> s, List<int> c)
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
                enrolleeCharge = ((adjustedCharge * (1 - plan.ServiceCosts[serviceID].PercentCoverage)) + plan.ServiceCosts[serviceID].RequiredCopayment);
                HSPCharge = ((adjustedCharge * plan.ServiceCosts[serviceID].PercentCoverage) - plan.ServiceCosts[serviceID].RequiredCopayment);
                returnArr[i, 0] = plan.ServiceCosts[serviceID].Name;
                returnArr[i, 1] = adjustedCharge.ToString();
                returnArr[i, 2] = enrolleeCharge.ToString();
                returnArr[i, 3] = HSPCharge.ToString();
            }

            return returnArr;


        }
        /// <summary>
        /// Calculates the charge for Out-Of-Network HSPs
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public String[,] OHSPCalculate(List<String> s, List<int> c)
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
                for (int j = 0; j < plan.ServiceCosts.Length; j++)
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
                    enrolleeCharge = ((adjustedCharge * (1 - plan.ServiceCosts[serviceID].PercentCoverage)) + plan.ServiceCosts[serviceID].RequiredCopayment);
                }
                else
                {
                    enrolleeCharge = ((charges[i] - adjustedCharge) + ((adjustedCharge * (1 - plan.ServiceCosts[serviceID].PercentCoverage)) + plan.ServiceCosts[serviceID].RequiredCopayment));
                }
                // Calculate HSP Charge.
                HSPCharge = ((adjustedCharge * plan.ServiceCosts[serviceID].PercentCoverage) - plan.ServiceCosts[serviceID].RequiredCopayment);
                returnArr[i, 0] = plan.ServiceCosts[serviceID].Name;
                returnArr[i, 1] = charges[i].ToString();
                returnArr[i, 2] = enrolleeCharge.ToString();
                enrolleePlan.AddCharge(enrolleeCharge);
                returnArr[i, 3] = HSPCharge.ToString();

            }
            return returnArr;
        }
    }
}
