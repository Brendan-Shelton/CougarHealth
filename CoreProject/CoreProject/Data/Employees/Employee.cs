using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CoreProject.Data.Employees
{
    /// <summary>
    /// An employee from cougar health 
    /// </summary>
    public class Employee : AuthUser
    {
        /// <summary>
        /// What the employee can do 
        /// </summary>
        public Permission Permission { get; set; }
        /// <summary>
        /// The username used to identify the employee stored in the database 
        /// </summary>
        public string UserName { get; set; }
        public string NewName { get; set; }
        private string _password;
        /// <summary>
        /// The hashed password stored in the database 
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        private static int _idCount = 0;
        /// <summary>
        /// Id from the database 
        /// </summary>
        public int Id { get; set; }

        public Employee()
        {
            this.Id = ++_idCount;
        }

        public static Tuple<string, Permission>[] GetPermissions()
        {
            return new Tuple<string, Permission>[]
            {
                Tuple.Create("Plan Admin", Permission.PlanAdmin),
                Tuple.Create("Enrollee Support", Permission.EnrolleeSupport),
                Tuple.Create("HSP Support", Permission.HSPSupport),
                Tuple.Create("Accountant", Permission.Accountant),
                Tuple.Create("Manager", Permission.Manager)
            };
        }

        public void SetSecurePass(string password)
        {
            this.Password = Passwordify(password);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptedPass"></param>
        /// <returns></returns>
        public bool CheckPass (string providedPass )
        {
            // password is stored as a hash 
            byte[] hashAndSalt = Convert.FromBase64String(this.Password);
            // size of hash in bytes
            int hashSize = 32;

            // get the salt from the byte array of the hash and salt 
            var salt = new byte[hashAndSalt.Length - hashSize];
            for (int i = 0; i < salt.Length; i++)
            {
                salt[i] = hashAndSalt[hashSize + i];
            }

            string expected = Passwordify(providedPass, salt);

            return this.Password == expected;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="confPass"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override bool ValidPass(string password, string confPass, CreationException exception)
        {
            var valid = confPass == password && password?.Length >= 8;
            if ( !valid )
            {
                exception.AddError("Invalid password", "Please enter a " +
                    "password with 8 or more characters");
            }
            return valid;
        }

        /// <summary>
        /// cannot have spaces, must be alphanumeric, can have underscore, 
        /// and cannot have more than 24 characters 
        /// </summary>
        /// <param name="userName">The user name supplied by view</param>
        /// <param name="exception">Error message container</param>
        /// <returns>Wether the user name is valid</returns>
        public override bool ValidUser(string userName, CreationException exception)
        {
            // one or more alphanumeric characters and an underscore
            Regex validUser = new Regex(@"^[a-zA-Z0-9_]+$");
            // don't count the beginning and ending whitespace
            userName = userName?.Trim();
            int userMax = 256;
            int userMin = 3;
            bool valid = userName != null && 
                         validUser.IsMatch(userName) &&
                         userName.Length > userMin && 
                         userName.Length < userMax;
            if ( !valid )
            {
                exception.AddError("Invalid user name", "A user name can only" +
                    $" have alphanumeric characters, be less than {userMax} " +
                    $"characters, and be more than {userMin} characters");
            }

            return valid;
        }

        /// <summary>
        /// Login an employee from the database 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override bool Login( string userName, string password )
        {

            return (this.UserName.Equals("Guest") && this.Password.Equals("guest")) || (this.UserName.Equals(userName) &&
                this.ComparePassword(this.Password, password));

        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Employee)obj;

            return other.Id == this.Id || other.UserName == this.UserName;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.UserName.GetHashCode();
        }

    }
}
