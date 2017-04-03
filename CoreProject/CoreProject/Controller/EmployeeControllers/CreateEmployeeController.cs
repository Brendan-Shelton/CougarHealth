using CoreProject.Data;
using CoreProject.Data.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreProject.Controller.EmployeeControllers
{
    public class CreateEmployeeController
    {
        public DbMgr Mgr { get; } = DbMgr.Instance;

        public CreateEmployeeController()
        {

        }


        

        /// <summary>
        /// Check if the information provided by view is valid and if it is:
        /// create an employee and send back it's id 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="confPass"></param>
        /// <param name="permission"></param>
        public int Create(
            string userName,
            string password,
            string confPass,
            string permission)
        {
            // trim any whitespace that can come up with winforms 
            userName = userName.Trim();
            password = password.Trim();
            confPass = confPass.Trim();
            permission = permission.Trim();
            var perm = Permission.None;
            var employee = new Employee();
            // if there is an exception with creating the account 
            CreationException except = new CreationException();
            switch (permission)
            {
                case "Plan Admin":
                    perm = Permission.PlanAdmin;
                    break;
                case "Enrollee Support":
                    perm = Permission.EnrolleeSupport;
                    break;
                case "HSP Support":
                    perm = Permission.HSPSupport;
                    break;
                case "Accountant":
                    perm = Permission.Accountant;
                    break;
                case "Manager":
                    perm = Permission.Manager;
                    break;
                default:
                    var msg = "Invalid permission";
                    var caption = "You pick a permission that wasn't Manager, " +
                        "Accountant, HSP Support, Enrollee Support, or Plan " +
                        "Administrator";
                    except.AddError(msg, caption);
                    break;

            } // switch on Permission


            var validPass = employee.ValidPass(password, confPass, except);
            var validUser = employee.ValidUser(userName, except);

            if ( except.IsProblem )
            {
                throw except;
            }

            employee.UserName = userName;
            employee.SetSecurePass(password);
            employee.Permission = perm;
            return Mgr.SaveEmployee(employee);
        }
    }
}
