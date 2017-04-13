using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Present;
using CoreProject.Data.HealthcareServiceProvider;

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

        public void addBill(Bill bill)
        {
            dbmgr.addBill(bill);
        }

        public void update(EnrolleeCosts costs)
        {
            var enrolleePlan = dbmgr.GetPlanByPrimary(_primaryId);
            var plan = dbmgr.GetPlanByType(enrolleePlan.Type);

            costs.setPolicyNumber(_primaryId);

            costs.setTotalCharges(enrolleePlan.TotalCost);
            costs.setPlanYearMaxBen(plan.PYMB);
            costs.setPlanYearMaxRemain(plan.PYMB - enrolleePlan.TotalCost);
            costs.setOutPocketInd(plan.OPMIndividual);
            costs.setOutPocketFam(plan.OPMFamily);
            costs.setOutPockeRem(enrolleePlan.OPMFRemainder);
            costs.setAPD(plan.APD);
            costs.setAPDRem(enrolleePlan.APDRemainder);


            for (int i = 0; i < plan.ServiceCosts.Count; i++)
            {
                switch(plan.ServiceCosts[i].Category)
                {
                    case "Hospital":
                        costs.addHospitalService(plan.ServiceCosts[i]);
                        break;
                    case "Physician":
                        costs.addPhysicianService(plan.ServiceCosts[i]);
                        break;
                    case "Other":
                        costs.addOtherService(plan.ServiceCosts[i]);
                        break;
                                       
                }
            }

            var bills = dbmgr.getBillsById(_primaryId);

            for (int i = 0; i < bills.Length; i++)
            {
                costs.addBillRow(bills[i]);
            }

            }
        }





    }

