using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Present;

namespace CoreProject.Controller.EnrolleeControllers
{


    public class PlanController
    {
        public DbMgr dbmgr { get; private set; }
        private int _primaryId;


        public PlanController(int primary)
        {
            this._primaryId = primary;
            this.dbmgr = DbMgr.Instance;
        }


        public void update(EnrolleeCosts costs)
        {
            var enrolleePlan = dbmgr.GetPlanByPrimary(_primaryId);
            var plan = dbmgr.GetPlanByType(enrolleePlan.Type);

            costs.setTotalCharges(enrolleePlan.TotalCost);
            costs.setPlanYearMaxBen(plan.PYMB);
            costs.setPlanYearMaxRemain(plan.PYMB - enrolleePlan.TotalCost);
            costs.setOutPocketInd(plan.OPMIndividual);
            costs.setOutPocketFam(plan.OPMFamily);
            costs.setOutPockeRem(enrolleePlan.OPMRemainder);
            costs.setAPD(plan.APD);
            costs.setAPDRem(enrolleePlan.APDRemainder);


            for (int i = 0; i < plan.ServiceCosts.Length; i++)
            {
                switch (plan.ServiceCosts[i].Name)
                {
                    case "Inpatient":
                        costs.setInpatientPercent(plan.ServiceCosts[i].PercentCoverage);
                        costs.setInpatientCopay(plan.ServiceCosts[i].RequiredCopayment);
                        break;
                    case "Inpatient (Behavioral Health":
                        costs.setInpatientBHPercent(plan.ServiceCosts[i].PercentCoverage);
                        costs.setInpatientBHCopay(plan.ServiceCosts[i].RequiredCopayment);
                        break;
                    case "Emergency Room":
                        costs.setEmergencyRoomPercent(plan.ServiceCosts[i].PercentCoverage);
                        costs.setEmergencyRoomCopay(plan.ServiceCosts[i].RequiredCopayment);
                        break;
                    case "Outpatient Surgery":
                        costs.setOutpatientPercent(plan.ServiceCosts[i].PercentCoverage);
                        costs.setOutpatientCopay(plan.ServiceCosts[i].RequiredCopayment);
                        break;
                    
                }

                //    if (plan.ServiceCosts[j].Category.Equals(category) &&
                //        plan.ServiceCosts[j].Name.Equals(name))
                //    {
                //        if (percent == true)
                //        {
                //            plan.ServiceCosts[j].PercentCoverage = val;
                //        }
                //        else
                //        {
                //            plan.ServiceCosts[j].RequiredCopayment = val;
                //        }
                //    }
            }
        }





    }
}
