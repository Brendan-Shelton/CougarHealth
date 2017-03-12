using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;

namespace CoreProject.Controller.HSPControllers
{
    public class BillController
    {
        public bool checkPolicy(String policy)
        {
            return true;
        }

        public bool checkEnrollee(String enrollee)
        {
            return true;
        }

        public void HSPCalculate(InsurancePlan plan, String[] services, int[] charges)
        {
            // For each service, check plan, and what they pay, max allowed, then calculate based on charge and service provided
            Type type = plan.GetType();
            
            for(int i = 0; i < services.Length; i++)
            {
                //if(charges[i] > plan.getServiceCost(services[i]))
                //{
                //    adjustedCharge = plan.getService(services[i]);
                //}

                //int enrolleeCharge = (charges[i] * (1 - getService(services[i]).getPercentCoverage())) + getService(services[i]).getRequiredCopayment();
                //int HSPCharge = (charges[i] * getService(services[i]).getPercentCoverage());

            }

            
                

        }

        public void OHSPCalculate()
        {
            //if(amount > allowedAmount)
            //{
            ///    enrolleeOverage = amount - allowedAmount;
            //}
        }
    }
}
