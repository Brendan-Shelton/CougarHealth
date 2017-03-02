using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CoreProject.Controller.EnrolleeControllers
{
    public class EnrollController
    {
        public struct Contact
        {
            public string email;
            public string mobilePhone;
            public string homePhone;
            public string errMsg;
        }
        /// <summary>
        /// Uses regex to verify if the social security number is correct 
        /// TODO: in database implementation we need to check ssn in the database
        /// </summary>
        /// <param name="ssn">A text box string with the social security number</param>
        /// <returns></returns>
        public bool CheckSSN( String ssn )
        {
            // matches either NNN-NN-NNNN or NN NNN NNNN or NNNNNNNNN
            var ssnPat = new Regex(@"^\d{3}(-|\s)?\d{2}(-|\s)?\d{4}$", RegexOptions.Singleline);
            return ssnPat.IsMatch(ssn);
        }

        public Contact NewContact(string home, string mobile, string email)
        {
            return new Contact() {email = email, mobilePhone = mobile, homePhone = home};
        }

        /// <summary>
        /// checks if the contact struct is has valid home phone, 
        /// mobile phone, and email fields. Adds an error message otherwise.
        /// </summary>
        /// <param name="contactInfo"></param>
        /// <returns></returns>
        public bool VerifyContact(ref Contact contactInfo)
        {
            // matches email addresses have the pattern username@site.tld
            var emailPat = new Regex(@"^\w+@\w+\.\w+$",
                RegexOptions.Singleline);
            // matches a US telephone number optionally prefixed with 1
            var phonePat = new Regex(@"^(\(?1\)?)?\d{3}(-|\s)?\d{3}(-|\s)?\d{4}$", 
                RegexOptions.Singleline);

            bool validEmail = emailPat.IsMatch(contactInfo.email);
            bool validHome = phonePat.IsMatch(contactInfo.homePhone);
            // mobile phones are not required, but if we got them we got to 
            // make sure they work 
            bool validMobile = contactInfo.mobilePhone == "" || 
                phonePat.IsMatch(contactInfo.mobilePhone);

            if ( !validEmail )
            {
                contactInfo.errMsg = "A valid email is required";
            }
            else if ( !validHome )
            {
                contactInfo.errMsg = "A valid US based home phone is required";
            }
            else if (!validMobile)
            {
                contactInfo.errMsg = "A valid US based mobile phone is required" +
                                     "\n(you could also leave the field blank)";
            }
            else
            {
                // all of our checks were successful 
                return true;
            }

            // one of our checks didn't work
            return false;
        }

        public void CreateEnrollee(
            string firstName, 
            string lastName, 
            string ssn,
            string mailingAddr, 
            string billingAddr, 
            string pin,
            Contact contactInfo )
        {
          
        }
    }
}
