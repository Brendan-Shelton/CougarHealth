using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Present;

namespace CoreProject.Controller.EmployeeControllers
{
    public class RangeReportController
    {
        private double basicPayments;
        private double extendedPayments;
        private double percentBasic;
        private double percentExtended;

        private int numBasicBills;
        private int numExtendBills;

        private DateTime begDate;
        private DateTime endDate;

        //bill[] rangeBills;

        public struct bill
        {
            public int amount;
            public int planType; //0 is for basic, 1 is for extended
            public DateTime dateOfBill;
            public String location; // Hospital, Physician, etc.

        }

        //public DbMgr Mgr { get; private set; }

        public RangeReportController()
        {
            //this.Mgr = DbMgr.Instance;
        }
        public void setDates(DateTime bDate, DateTime eDate)
        {
            if (bDate < eDate)
            {
                begDate = bDate;
                endDate = eDate;
            } else
            {
                endDate = bDate;
                begDate = eDate;
            }
        }
        // This method will talk to the DbMgr and will send the beginning date, and ending date, and
        //      pull all bills in between. It will save an array of Bills.
        //
        public bill[] retrieveRangedData(DateTime bDate, DateTime eDate)
        {
            begDate = bDate;
            endDate = eDate;
            //rangeBills = Mgr.getBillRange(bDate, eDate);  Commented out until DbMgr function ready

            //This is all dummy Data!!!!
            //----------------------------------------------------------------------
            bill[] rangeBills = new bill[5];
            rangeBills[0].amount = 400;
            rangeBills[0].dateOfBill = new DateTime(2017, 3, 2);
            rangeBills[0].location = "Hospital";
            rangeBills[0].planType = 0;

            rangeBills[1].amount = 90000;
            rangeBills[1].dateOfBill = new DateTime(2017, 3, 4);
            rangeBills[1].location = "Physician";
            rangeBills[1].planType = 1;

            rangeBills[2].amount = 449;
            rangeBills[2].dateOfBill = new DateTime(2017, 2, 26);
            rangeBills[2].location = "Other";
            rangeBills[2].planType = 0;

            rangeBills[3].amount = 200;
            rangeBills[3].dateOfBill = new DateTime(2017, 2, 1);
            rangeBills[3].location = "Hospital";
            rangeBills[3].planType = 1;

            rangeBills[4].amount = 1000;
            rangeBills[4].dateOfBill = new DateTime(2017, 2, 20);
            rangeBills[4].location = "Physician";
            rangeBills[4].planType = 0;
            //----------------------------------------------------------------------
            return rangeBills;
        }

        public double[] checkBills()
        {
            basicPayments = 0;
            extendedPayments = 0;

            bill[] rangeBills = retrieveRangedData(begDate, endDate);

            
            if (rangeBills != null) 
            for (int i = 0; i < rangeBills.Length; i++)
            {
                if (rangeBills[i].planType == 0 && rangeBills[i].dateOfBill > begDate && 
                        rangeBills[i].dateOfBill < endDate)
                    {
                        basicPayments += rangeBills[i].amount;
                    }
                if(rangeBills[i].planType == 1 && rangeBills[i].dateOfBill > begDate && 
                        rangeBills[i].dateOfBill < endDate)
                    {
                        extendedPayments += rangeBills[i].amount;
                    }    
            }

            

            int yearTotalBasic = 0;
            int yearTotalExtended = 0;

            DateTime now = DateTime.Now;
            DateTime pcyStart;

            if (DateTime.Now < new DateTime(now.Year, 7, 1))
            {
                pcyStart = new DateTime(now.Year - 1, 7, 1);
            } else
            {
                pcyStart = new DateTime(now.Year, 7, 1);
            }

            bill[] allBills = retrieveRangedData(pcyStart, now);

            for (int i = 0; i < allBills.Length; i++)
            {
                if (allBills[i].planType == 0 && allBills[i].dateOfBill > pcyStart && 
                    allBills[i].dateOfBill < now)
                {
                    yearTotalBasic += allBills[i].amount;
                } else if (allBills[i].planType == 1 && allBills[i].dateOfBill > pcyStart &&
                    allBills[i].dateOfBill < now)
                {
                    yearTotalExtended += allBills[i].amount;
                }
            }
           
            double basicPercent = (basicPayments / yearTotalBasic) * 100;
            if (yearTotalBasic == 0)
            {
                basicPercent = 0;
            }

            double extendPercent = (extendedPayments / yearTotalExtended) * 100;
            if (yearTotalExtended == 0)
            {
                extendPercent = 0;
            }

            double[] temp = { basicPercent, extendPercent, basicPayments, extendedPayments };
            return temp;
        }
       
        public void outputBillsToForm(ExpenseReport expGUI, double basic, double extend, double basicPayments, double extendPayments)
        {

            expGUI.changeBeginningDateLabel(begDate.ToShortDateString());
            expGUI.changeEndDateLabel(endDate.ToShortDateString());

            expGUI.setBasicPercentage(basic);
            expGUI.setExtendedPercentage(extend);

            expGUI.setBasicTotal(basicPayments);
            expGUI.setExtendedTotal(extendedPayments);
        }

    }
}
