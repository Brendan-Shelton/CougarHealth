using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;

namespace CoreProject.Data.HealthcareServiceProvider
{
    public class Bill
    {
        public int Id { get; private set; }
        public bool IsPrimary { get; set; }
        public DateTime date { get; private set; }
        public HSP hsp { get; private set; }
        public int serviceId { get; private set; }
        public int enrolleeId { get; private set; }
        public double totalBillAmount { get; private set; }
        public double enrolleeBillAmount { get; private set; }
        public String enrolleeEmail { get; private set; }

        public Bill(DateTime date, HSP hsp, int serviceId, int enrolleeId, String enrolleeEmail, double totalBillAmount, double enrolleeBillAmount)
        {

            this.date = date;
            this.hsp = hsp;
            this.serviceId = serviceId;
            this.enrolleeId = enrolleeId;
            this.totalBillAmount = totalBillAmount;
            this.enrolleeBillAmount = enrolleeBillAmount;
            this.enrolleeEmail = enrolleeEmail;
        }

        /// <summary>
        /// Database ctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="hsp"></param>
        /// <param name="service"></param>
        /// <param name="enrolleeId"></param>
        /// <param name="isPrimary"></param>
        /// <param name="totalBillAmount"></param>
        /// <param name="enrolleeBillAmount"></param>
        public Bill(
            int id, 
            DateTime date, 
            HSP hsp, 
            int serviceId, 
            int enrolleeId, 
            bool isPrimary, 
            double totalBillAmount, 
            double enrolleeBillAmount )
        {
            this.Id = id;
            this.date = date;
            this.hsp = hsp;
            this.serviceId = serviceId;
            this.enrolleeId = enrolleeId;
            this.totalBillAmount = totalBillAmount;
            this.enrolleeBillAmount = enrolleeBillAmount;
            this.IsPrimary = isPrimary;
        }



    }
}
