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
        public IEnumerable<InsurancePlan> Plans;
        public Type planType;
        public Enrollee enrollee;
        public EnrolleePlan enrolleePlan;

        public BillController()
        {
            this.Mgr = DbMgr.Instance;
            this.Plans = Mgr.GetPlans();
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

        public bool checkEnrollee(String name)
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

        
        
        

        
        


        public void HSPCalculate(InsurancePlan plan, String[] services, int[] charges)
        {
            // For each service, check plan, and what they pay, max allowed, then calculate based on charge and service provided
            Type type = plan.GetType();
            
            for(int i = 0; i < services.Length; i++)
            {
                if(charges[i] > plan.getServiceCost(services[i]))
                {
                    double adjustedCharge = plan.getService(services[i]);
                }

                double enrolleeCharge = (charges[i] * (1 - getService(services[i]).getPercentCoverage())) + getService(services[i]).getRequiredCopayment();
                double HSPCharge = (charges[i] * getService(services[i]).getPercentCoverage());

            }

            
                

        }

        public void OHSPCalculate()
        {
            
        }
    }
}
