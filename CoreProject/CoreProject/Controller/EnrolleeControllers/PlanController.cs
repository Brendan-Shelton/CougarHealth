﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Present;
using CoreProject.Data.HealthcareServiceProvider;
using CoreProject.Data.Enrollee;

namespace CoreProject.Controller.EnrolleeControllers
{


    public class PlanController
    {
        public DbMgr dbmgr { get; private set; }
        public readonly int _primaryId;
        private bool _isPrimary; 
        public IEnumerable<EnrolleePlan> AvailablePlans { get; set; }
        public bool MultiplePlans {
            get
            {
                return AvailablePlans == null || AvailablePlans.Count() > 1;
            }
        }

        private String _email;


        public PlanController(int primary, String email, bool isPrimary)
        {
            this._primaryId = primary;
            this._isPrimary = isPrimary;
            this.dbmgr = DbMgr.Instance;
            this.AvailablePlans = this.dbmgr.GetPlanByPrimary(this._primaryId);
        }

        public void addBill(Bill bill)
        {
            dbmgr.addBill(bill);
        }

        public void update( EnrolleeCosts costs, int planNum )
        {
            var enrolleePlan = dbmgr.GetPolicyByID(planNum);
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

            double totalCharges = 0;

            if (_isPrimary)
            {
                var bills = dbmgr.GetBillsById(_primaryId);


                for (int i = 0; i < bills.Count; i++)
                {
                    costs.addBillRow(bills.ElementAt(i));
                    totalCharges += bills.ElementAt(i).enrolleeBillAmount;
                }
            } else
            {
                var depBills = dbmgr.GetBillsByEmail(_email);

                for (int i = 0; i < depBills.Length; i++)
                {
                    costs.addBillRow(depBills[i]);
                    totalCharges += depBills[i].enrolleeBillAmount;
                }
            }

            costs.setTotalCharges(totalCharges);

            }
        }





    }

