using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Employees;

namespace CoreProject.Data.HealthcareServiceProvider
{
    public class HSP : AuthUser
    {
        //Todo: 

        /// <summary>
        /// Required fields
        /// </summary>
        public string Name { get; set; }
        public List<string> ServicesOffered { get; set; }
        public string Personnel { get; set; }
        public string Address { get; set; }
        public bool InNetwork { get; private set; }
        /// <summary>
        /// Optional fields
        /// </summary>
        public string BankName { get; set; } = null;
        public int AccountNum { get; set; }
        public int RoutingNum { get; set; }


        /// <summary>
        /// Unique to each HSP/OHSP
        /// </summary>
        public int Id { get; }
        private string _pin;

        /// <summary>
        /// Basically a password for the HSP that allows them to log in 
        /// with their company name.
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

        public HSP(string pin, bool isNetwork)
        {
            this.InNetwork = isNetwork;
            this.ChangePIN(pin);
        }

        /// <summary>
        /// Database ctor 
        /// </summary>
        internal HSP(
            int id, 
            int routingNum, 
            int accountNum, 
            string pin, 
            string bankName, 
            string personelContact, 
            string name, 
            string address, 
            bool isInNetwork )
        {
            this.Id = id;
            this.RoutingNum = routingNum;
            this.AccountNum = accountNum;
            this.BankName = bankName;
            this.Pin = pin;
            this.Personnel = personelContact;
            this.Name = name;
            this.Address = address;
            this.InNetwork = isInNetwork; 
        }

        public void ChangePIN(string newPin)
        {
            this.Pin = Passwordify(newPin);
        }

        public void ChangeNetworkStatus()
        {
            this.InNetwork = !InNetwork;
        }

        public override bool Equals(object obj)
        {
            var that = (HSP) obj;
            return that.Name == this.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        /// <summary>
        /// This method is not used for HSP 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="exception"></param>
        public override bool ValidPass(string password, string confPass, CreationException exception)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not used for HSP 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override bool ValidUser(string userName, CreationException exception)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// return wether the supplied pin and company name combo matches this 
        /// HSP's pin and company name 
        /// </summary>
        /// <param name="userName">company name</param>
        /// <param name="password">pin</param>
        /// <returns></returns>
        public override bool Login(string userName, string password)
        {
            return this.Name.Equals(userName) && 
                this.ComparePassword(this.Pin, password);
        }
    }
}
