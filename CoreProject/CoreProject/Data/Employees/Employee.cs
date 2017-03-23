using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.Employees
{
    /// <summary>
    /// An employee from cougar health 
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// What the employee can do 
        /// </summary>
        public Permission Permission { get; set; }
        /// <summary>
        /// The username used to identify the employee stored in the database 
        /// </summary>
        public string UserName { get; set; }

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
                _password = this.Passwordify(value);
            }
        }

        /// <summary>
        /// hash and salt the password of the employee 
        /// </summary>
        /// <param name="plainPass">plain text password</param>
        /// <returns>hashed password</returns>
        private string Passwordify(string plainPass)
        {
            return plainPass;
        }
    }
}
