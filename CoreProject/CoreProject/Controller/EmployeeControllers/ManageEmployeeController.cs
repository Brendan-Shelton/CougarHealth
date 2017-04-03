using CoreProject.Data;
using CoreProject.Data.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Controller.EmployeeControllers
{
    public class ManageEmployeeController
    {
        public DbMgr Mgr { get; set; } = DbMgr.Instance;

        public string[] EmployeeMenu()
        {
            IEnumerable<Employee> emps = Mgr.GetAllEmployees();
            return emps.Select( emp => emp.UserName).ToArray();
        }

        public Employee GrabInfo(string user)
        {
            return Mgr.GetEmployeeByName(user);
        }

        public int Modify ( 
            string userName, 
            string password, 
            string confPass, 
            string permission, 
            Employee emp )
        {
            Tuple<string, Permission>[] perms = Employee.GetPermissions();
            // container exception for all then errors in the modification 
            CreationException exception = new CreationException();
            bool goodPass = true;
            if ( !string.IsNullOrWhiteSpace(password) )
            {
                goodPass = emp.ValidPass(password, confPass, exception);
            }
            bool goodUser = emp.ValidUser(userName, exception);

            // match the permission string from the view with the correct 
            // permission on the Permission Enum
            Permission suppliedPerm = (from perm in perms
                                       where perm.Item1 == permission
                                       select perm.Item2).FirstOrDefault();

            // default value is 0 or "None"
            if ( suppliedPerm == Permission.None )
            {
                exception.AddError(
                    "Invalid selected permission",
                    "The permission provided wasn't any of Manager, " +
                    "Enrollee Specialist, HSP Specialist, Plan Admin, or" +
                    " Accountant");
            }

            if ( exception.IsProblem )
            {
                throw exception;
            }
            if ( !string.IsNullOrWhiteSpace(password) )
            {
                emp.SetSecurePass(password); 
            }
            emp.NewName = userName;
            emp.Permission = suppliedPerm;
            int id = Mgr.UpdateEmployee(emp);
            return id;
        }
    }
}
