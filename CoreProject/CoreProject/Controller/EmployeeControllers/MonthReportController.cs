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
            public int totalBasicIncome;
            public int totalExtendedIncome;
            public int numIHSPBills;
            public int numOHSPBills;
            public int IHSPhospitalCosts;
            public int OHSPhospitalCosts;
            public int IHSPPhysicianCosts;
            public int OHSPPhysicianCosts;
            public int IHSPOtherCosts;
            public int OHSPOtherCosts;
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

            report.setBasicEnrollNum(funds.numBasicEnrollees);
            report.setExtendedErollNum(funds.numExtendedEnrollees);

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
            temp.numIHSPBills = 200;
            temp.numOHSPBills = 120;
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
