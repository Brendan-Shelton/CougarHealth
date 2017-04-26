using CoreProject.Data;
using CoreProject.Data.Employees;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Controller.EmployeeControllers
{
    /// <summary>
    /// Makes sure the employee exists in the database and that their password 
    /// is the same as they entered 
    /// </summary>
    public class EmployeeLoginController
    {
        private DbMgr Mgr { get; set; }
        public EmployeeLoginController()
        {
            this.Mgr = DbMgr.Instance;
        }

        /// <summary>
        /// Find the employee in the database corresponding to the provided 
        /// username, and authenticate the employee with the passwd. If no 
        /// match found we throw an exception
        /// </summary>
        /// <param name="user">username</param>
        /// <param name="passwd"></param>
        /// <returns></returns>
        public Employee Login ( string user, string passwd )
        {
            Employee toLogin = Mgr.GetEmployeeByName(user);
            bool? logged = toLogin?.Login(user, passwd);
            

            // since logged could be null we need to check if it is true
            return (logged == true) ? toLogin : null;
        }
    }
}
