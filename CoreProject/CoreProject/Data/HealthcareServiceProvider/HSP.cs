using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.HealthcareServiceProvider
{
    public class HSP
    {
        //Todo: 

        /// <summary>
        /// Required fields
        /// </summary>
        public String Name { get; set; }
        public List<String> ServicesOffered { get; set; }
        public List<String> personnel { get; set; }
        public String Address { get; set; }

        /// <summary>
        /// Optional fields
        /// </summary>
        public String BankName { get; set; } = null;
        public int AccountNum { get; set; }
        public int RoutingNum { get; set; }

        private static int idCount = 0;

        /// <summary>
        /// Unique to each HSP/OHSP
        /// </summary>
        public int Id { get; }
        private string _pin;

        /// <summary>
        /// Basically a password for the enrollee that allows them to log in 
        /// with their email.
        /// TODO: hash the password when set
        /// </summary>
        public string Pin
        {
            get { return _pin; }
            private set
            {
                if (_pin == value)
                    throw new ArgumentException("Pin can't be the same as previous");
                _pin = value;
            }
        }

        public HSP()
        {
            this.Id = ++idCount;
        }

        public void changePIN(string newPin)
        {
            this.Pin = newPin;
        }
    }
}
