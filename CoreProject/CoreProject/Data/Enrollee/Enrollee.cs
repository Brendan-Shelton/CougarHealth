using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Employees;
using System.Security.Cryptography;

namespace CoreProject.Data.Enrollee
{
    public abstract class Enrollee: AuthUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// optional for the enrollee to have
        /// </summary>
        public string MobilePhone { get; set; } = null;


        public int Id { get; set; }
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
                if ( _pin == value )
                    throw new ArgumentException("Pin can't be the same as previous");
                _pin = value;
            }
        }

        /// <summary>
        /// A abstract readonly property that is implemented in the 
        /// subclasses. 
        /// </summary>
        public abstract bool IsPrimary { get; }

        private string _ssn;
        /// <summary>
        /// Can only be set once because it is unique to the PrimaryEnrollee
        /// </summary>
        public string SSN {
            set
            {
                if ( _ssn != null )
                    throw new ArgumentException("SSN can only be set once");

                _ssn = value;
            }
            get { return _ssn; }
        }

        public Enrollee( string pin )
        {
            
            this.Pin = Passwordify(pin);
        }

        /// <summary>
        /// If the SSN of that is the same as the SSN this then they are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var that = (Enrollee) obj;
            // optional members

            return that.SSN == this.SSN;
        }

        /// <summary>
        /// Each enrollee has a unique SSN
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.SSN.GetHashCode();
        }

        public override bool ValidPass(string password, string confPass, CreationException exception)
        {
            throw new NotImplementedException();
        }

        public override bool ValidUser(string userName, CreationException exception)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// checks if the supplied username and password match this enrollee's
        /// Email and Pin 
        /// </summary>
        /// <param name="userName">enrollee Email</param>
        /// <param name="password">enrollee Pin</param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override bool Login(string userName, string password)
        {

            return this.Email.Equals(userName) && 
                this.ComparePassword(this.Pin, password);
        }
    }
}
