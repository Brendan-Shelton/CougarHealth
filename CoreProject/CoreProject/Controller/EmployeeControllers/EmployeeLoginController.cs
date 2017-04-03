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
        public Employee ToLogin { get; set; }
        public EmployeeLoginController()
        {
            this.Mgr = DbMgr.Instance;
            this.ToLogin = new Employee();
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
            this.ToLogin.Password = passwd;
            this.ToLogin.UserName = user;
            Employee logged = this.Mgr.EmployeeLogin(this.ToLogin);
            
            if ( logged == null )
            {
                throw new DataException("Invalid login credentials");
            }

            return logged;
        }
    }
}
