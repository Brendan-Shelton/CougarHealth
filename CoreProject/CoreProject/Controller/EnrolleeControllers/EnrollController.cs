using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CoreProject.Data;
using CoreProject.Data.Enrollee;

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

        public string[] Relationships => new[]
        {
            "Significant Other",
            "Child"
        };

        public IEnumerable<InsurancePlan> Plans { get; private set; }
        public DbMgr Mgr { get; private set; }
        public EnrollController()
        {
            this.Mgr = DbMgr.Instance;
            this.Plans = this.Mgr.GetPlans();
        }

        public PrimaryEnrollee PrimaryEnrollee { get; set; }
        public DependentEnrollee DependentEnrollee { get; set; }
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

        /// <summary>
        /// creates a container for contact information.
        /// </summary>
        /// <param name="home"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <returns></returns>
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

        /// <summary>
        /// remove the leading one, hyphens, and spaces from the inputted phone
        /// </summary>
        private string TransformPhone( string inputPhone )
        {
            return Regex.Replace(inputPhone, "^1", "")
                        .Replace("-", "")
                        .Replace(" ", ""); 
        }
        /// <summary>
        /// Create an enrollee object matching a unifying format and store it 
        /// into the database. Unifying format means no extra characters in 
        /// ssn, homephone, or mobilephone
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="ssn"></param>
        /// <param name="mailingAddr"></param>
        /// <param name="billingAddr"></param>
        /// <param name="pin"></param>
        /// <param name="contactInfo"></param>
        public void CreatePrimaryEnrollee(
            string firstName, 
            string lastName, 
            string ssn,
            string mailingAddr, 
            string billingAddr, 
            string pin,
            Contact contactInfo )
        {
            // the ssn can come in a variety formats and I need to make sure 
            // they all just end up in the format NNNNNNNNN
            var transformedSSN = ssn.Replace(" ", "").Replace("-", "");
            var transformedHome = TransformPhone(contactInfo.homePhone);
            var transformedMobile = TransformPhone(contactInfo.mobilePhone);

            this.PrimaryEnrollee = new PrimaryEnrollee(pin)
            {
                BillingAddr = billingAddr,
                Email = contactInfo.email,
                FirstName = firstName,
                HomePhone = transformedHome,
                LastName = lastName,
                MailingAddr = mailingAddr,
                MobilePhone = transformedMobile,
                SSN = transformedSSN
            };
            Mgr.SaveEnrollee(this.PrimaryEnrollee);
        }

        /// <summary>
        /// Pick a plan and attach it to an PrimaryEnrollee based on it's identifier
        /// </summary>
        /// <param name="type"></param>
        public int PickPlan( string type )
        {
            if ( this.PrimaryEnrollee == null ) throw new ArgumentException("There is no enrollee");
            var planPicked = Mgr.GetPlanByType(type);
            if (planPicked != null)
            {
                var enrolleePlan = new EnrolleePlan(this.PrimaryEnrollee, planPicked);
                Mgr.SaveEnrolleePlan(enrolleePlan);
                return enrolleePlan.PlanNum;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Gets all plans from the Database and returns a array of 2-tuples that 
        /// have the primary key of the plan as item1 and the name of the plan as 
        /// item2
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ShowPlans()
        {
            // looks like something that should be in dbmgr but I chose here
            // because I am essentailly calling a map function on the plans set
            var planIdentifiers = from plan in Plans select plan.Type;
            return planIdentifiers;
        }

        /// <summary>
        /// gets the plan corresponding to the plan selected and returns it  
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public Service[] ShowPlanDetails(string identifier)
        {
            var planToShow = Mgr.GetPlanByType(identifier);
            if (planToShow == null)
            {
                throw new NullReferenceException();
            }

            return planToShow.ServiceCosts;
        }

        /// <summary>
        /// Gets the first name and last name of the primary enrollee
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            if ( this.PrimaryEnrollee == null ) throw new ArgumentException("There is no enrollee");
            return this.PrimaryEnrollee.FirstName + " " + this.PrimaryEnrollee.LastName;
        }

        public int? LoginPrimary(string email, string pin)
        {
            return Mgr.Login(email, pin);
        }

        /// <summary>
        /// Creates a new dependent object and attaches it to the the enrollee 
        /// of the primary enrollee pointed to by primaryId 
        /// </summary>
        /// <param name="primaryId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="ssn"></param>
        /// <param name="relationship"></param>
        /// <param name="pin"></param>
        /// <param name="contact"></param>
        /// <returns></returns>
        public int CreateDependent(
            int primaryId,
            string firstName, 
            string lastName, 
            string ssn,
            string relationship,
            string pin,
            Contact contact
        )
        {
            var enrolleePlan = Mgr.GetPlanByPrimary(primaryId);
            enrolleePlan.AddDependent(new DependentEnrollee (pin)
            {
                Email = contact.email,
                FirstName = firstName,
                HomePhone = contact.homePhone,
                LastName = lastName,
                MobilePhone = contact.mobilePhone,
                Relationship = relationship,
                SSN = ssn
            });

            return enrolleePlan.PlanNum;
        }
    }
}
