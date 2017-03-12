﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.Enrollee
{
    public class Enrollee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomePhone { get; set; }
        /// <summary>
        /// optional for the enrollee to have
        /// </summary>
        public string MobilePhone { get; set; } = null;

        /// <summary>
        /// Place holder for the database 
        /// </summary>
        private static int idCount = 0;

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
                if ( _pin == value )
                    throw new ArgumentException("Pin can't be the same as previous");
                _pin = value;
            }
        }

        private string _ssn;
        /// <summary>
        /// Can only be set once because it is unique to the Enrollee
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
        public string MailingAddr { get; set; }
        /// <summary>
        /// optional for the enrollee to have
        /// </summary>
        public string BillingAddr { get; set; } = null;

        public string Email { get; set; }

        public Enrollee()
        {
            this.Id = ++idCount;
        }

        public void changePIN(string newPin)
        {
            //TODO: hash pin 
            this.Pin = newPin;
        }

        public override bool Equals(object obj)
        {
            var that = (Enrollee) obj;
            // optional members
            var mobileEqual = that.MobilePhone?.Equals(this.MobilePhone) ?? true;
            var billingEqual = that.BillingAddr?.Equals(this.BillingAddr) ?? true;

            return that.Email.Equals(this.Email) &&
                   that.FirstName.Equals(this.FirstName) &&
                   that.LastName.Equals(this.LastName) &&
                   billingEqual &&
                   that.Pin.Equals(this.Pin) &&
                   that.HomePhone.Equals(this.HomePhone) &&
                   that.SSN.Equals(this.SSN) &&
                   mobileEqual;
        }
    }
}
