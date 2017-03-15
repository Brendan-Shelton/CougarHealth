using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Present;

namespace CoreProject.Controller.EmployeeControllers
{
   public class MonthReportController
    {

        public struct financeSystem
        {
            public int numBasicEnrollees;
            public int numExtendedEnrollees;
            public int numEnrolleeBills;
            public double totalBasicIncome;
            public double totalExtendedIncome;
            public int numIHSPHospitalBills;
            public int numOHSPHospitalBills;
            public int numIHSPPhysicianBills;
            public int numOHSPPhysicianBills;
            public int numIHSPOtherBills;
            public int numOHSPOtherBills;
            public double IHSPhospitalCosts;
            public double OHSPhospitalCosts;
            public double IHSPPhysicianCosts;
            public double OHSPPhysicianCosts;
            public double IHSPOtherCosts;
            public double OHSPOtherCosts;
        }

        //public DbMgr Mgr { get; private set; }

        public MonthReportController()
        {
            //this.Mgr = DbMgr.Instance;
        }

        private String updateMonth(DateTime date)
        {
            String temp = "";
            temp += date.Month;
            

            switch (temp)
            {
                case "1": temp = "January";
                    break;
                case "2": temp = "February";
                    break;
                case "3": temp = "March";
                    break;
                case "4": temp = "April";
                    break;
                case "5": temp = "May";
                    break;
                case "6": temp = "June";
                    break;
                case "7": temp = "July";
                    break;
                case "8": temp = "August";
                    break;
                case "9": temp = "September";
                    break;
                case "10": temp = "October";
                    break;
                case "11": temp = "November";
                    break;
                default: temp = "December";
                    break;
            }

            temp += " ";
            temp += date.Year;

            return temp;
        }

        public void update(MonthlyReport report)
        { 
           report.setMonth(updateMonth(DateTime.Now));
            financeSystem funds = retrieveFinances(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), DateTime.Now);

            double amountOwedIHSP = 0;
            double amountOwedOHSP = 0;

            report.setBasicEnrollNum(funds.numBasicEnrollees);
            report.setExtendedErollNum(funds.numExtendedEnrollees);

            report.setBasicTotalIncome(funds.totalBasicIncome);
            report.setExtendTotalIncome(funds.totalExtendedIncome);
            report.setTotalEnrolleePayments(funds.numEnrolleeBills);

            report.setIHSPNumHospBills(funds.numIHSPHospitalBills);
            report.setOHSPNumHospBills(funds.numOHSPHospitalBills);

            report.setIHSPNumPhysBills(funds.numIHSPPhysicianBills);
            report.setOHSPNumPhysBills(funds.numOHSPPhysicianBills);

            report.setIHSPNumOtherBills(funds.numIHSPOtherBills);
            report.setOHSPNumOtherBills(funds.numOHSPOtherBills);

            report.setHospitalIHSP(funds.IHSPhospitalCosts);
            report.setHospitalOHSP(funds.OHSPhospitalCosts);
            amountOwedIHSP += funds.IHSPhospitalCosts;
            amountOwedOHSP += funds.OHSPhospitalCosts;

            report.setPhysicianIHSP(funds.IHSPPhysicianCosts);
            report.setPhysicianOHSP(funds.OHSPPhysicianCosts);
            amountOwedIHSP += funds.IHSPPhysicianCosts;
            amountOwedOHSP += funds.OHSPPhysicianCosts;

            report.setOtherIHSP(funds.IHSPOtherCosts);
            report.setOtherOHSP(funds.OHSPOtherCosts);
            amountOwedIHSP += funds.IHSPOtherCosts;
            amountOwedOHSP += funds.OHSPOtherCosts;

            report.setAmountOwedIHSP(amountOwedIHSP);
            report.setAmountOwedOHSP(amountOwedOHSP);

            double paidPercentage = 0;

            paidPercentage = (amountOwedIHSP + amountOwedOHSP) / (2000*funds.numIHSPHospitalBills + 150*funds.numIHSPPhysicianBills
                + 300*funds.numIHSPOtherBills + amountOwedOHSP);

            paidPercentage = paidPercentage * 100;
            report.setMaxPercentBillable(paidPercentage);

            double totalCosts = 0;

            totalCosts += amountOwedIHSP;
            totalCosts += amountOwedOHSP;

            report.setTotalCosts(totalCosts);

        }

        private financeSystem retrieveFinances(DateTime bDate, DateTime eDate)
        {
            financeSystem temp = new financeSystem();
            //  Will use DbMgr when merged with upper branches
            //
            //temp = Mgr.retrieveFinances(bDate, eDate);

            //This is all dummy data!!
            //-----------------------------------------------
            temp.numBasicEnrollees = 120;
            temp.numExtendedEnrollees = 58;
            temp.numEnrolleeBills = 259;
            temp.numIHSPHospitalBills = 200;
            temp.numOHSPHospitalBills = 120;
            temp.numIHSPPhysicianBills = 50;
            temp.numOHSPPhysicianBills = 25;
            temp.numIHSPOtherBills = 47;
            temp.numOHSPOtherBills = 34;
            temp.OHSPPhysicianCosts = 2000;
            temp.IHSPhospitalCosts = 56000;
            temp.OHSPhospitalCosts = 12000;
            temp.IHSPPhysicianCosts = 3500;
            temp.IHSPOtherCosts = 4200;
            temp.OHSPOtherCosts = 1000;
            temp.totalBasicIncome = 58000;
            temp.totalExtendedIncome = 34000;
            
            //-----------------------------------------------

            return temp;
        }
    }
}
