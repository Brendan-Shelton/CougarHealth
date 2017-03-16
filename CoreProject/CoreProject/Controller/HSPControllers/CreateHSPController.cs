using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Data.HealthcareServiceProvider;

namespace CoreProject.Controller.HSPControllers
{
    public class CreateHSPController
    {
        private readonly DbMgr _mgr;

        public struct BankInfo
        {
            public int Routing;
            public int Account;
            public string Name;
        }

        public HSP Hsp { get; private set; }

        public CreateHSPController()
        {
            this._mgr = DbMgr.Instance;
        }

        /// <summary>
        /// Does a length check on the phone number provided by the personel
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool CheckPersonelPhone(string phone)
        {
            return phone.Trim().Length == 14;
        }

        /// <summary>
        /// Creates a new instance of HSP and saves it into the database 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="services"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <param name="pin"></param>
        /// <param name="netowrkStatus"></param>
        /// <param name="info"></param>
        // ReSharper disable once InconsistentNaming
        public int CreateHSP(
            string name, 
            List<string> services, 
            string address, 
            string phone,
            string pin, 
            bool netowrkStatus, 
            BankInfo? info )
        {
            var phoneCheck = CheckPersonelPhone(phone);

            if (!phoneCheck)
            {
                throw new ArgumentException("The provided phone number should be a valid US phone number");                
            }

            this.Hsp = new HSP(pin, netowrkStatus)
            {
                Name = name,
                ServicesOffered = services,
                Address = address,
            };

            this._mgr.SaveHsp(this.Hsp);

            return this.Hsp.Id;
        }
    }
}
