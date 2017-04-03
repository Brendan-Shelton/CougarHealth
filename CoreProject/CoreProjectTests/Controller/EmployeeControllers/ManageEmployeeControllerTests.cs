using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Controller.EmployeeControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Employees;
using System.Data;

namespace CoreProject.Controller.EmployeeControllers.Tests
{
    [TestClass()]
    public class ManageEmployeeControllerTests
    {
        /// <summary>
        /// Put in the write credentials for modifying an employee account 
        /// </summary>
        [TestMethod()]
        public void ModifyTest()
        {
            var ctrl = new ManageEmployeeController();
            var employee = new Employee()
            {
                UserName = "michael_rhodes_",
                Permission = Permission.Accountant,
            };
            employee.SetSecurePass("2spooky4you");
            // manually add the employee in order to create less of a dependency
            // on CreateEmployeeController
            ctrl.Mgr.EmployeeSet.Add(employee);
            var newUser = "michael_rhodes";
            var newPass = "2great5you";
            var newConfPass = "2great5you";
            var newPermission = "Manager";
            var newNewPermission = "Plan Admin";


            // if this fails an exception will be fired
            int success = ctrl.Modify(
                newUser, 
                newPass, 
                newConfPass, 
                newPermission, 
                employee
            );

            int successAgain = ctrl.Modify(
                userName: newUser,
                password: "",
                confPass: "",
                permission: newNewPermission,
                emp: employee
            );

            Assert.AreEqual(success, successAgain);
            Assert.AreEqual(newUser, employee.UserName);
            Assert.AreEqual(Permission.PlanAdmin, employee.Permission);
        }

        /// <summary>
        /// Try to modify a user that is not in the database 
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(DataException))]
        public void ModifyWrongTest()
        {
            var ctrl = new ManageEmployeeController();
            var employee = new Employee()
            {
                UserName = "michael_rhodes_",
                Permission = Permission.Accountant,
            };
            employee.SetSecurePass("2spooky4you");
                
            // manually add the employee in order to create less of a dependency
            // on CreateEmployeeController
            ctrl.Mgr.EmployeeSet.Add(employee);

            var WrongEmployee = new Employee()
            {
                UserName = "michael_rhodes",
                Permission = Permission.Accountant,
            };
            WrongEmployee.SetSecurePass("2spooky4you");
            var newUser = "michael_rho";
            var newPass = "2great5you";
            var newConfPass = "2great5you";
            var newPermission = "Manager";

            ctrl.Modify(
                userName: newUser,
                password: newPass,
                confPass: newConfPass,
                permission: newPermission,
                emp: WrongEmployee
            );
        }
        /// <summary>
        /// Try to modify a user with wrong passwords 
        /// INTEGRATION TEST WITH EMPLOYEE
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(CreationException))]
        public void ModifyInvalidTest()
        {
            var ctrl = new ManageEmployeeController();
            var employee = new Employee()
            {
                UserName = "michael_rhodes_",
                Permission = Permission.Accountant,
            };
            employee.SetSecurePass("2spooky4you");
                
            // manually add the employee in order to create less of a dependency
            // on CreateEmployeeController
            ctrl.Mgr.EmployeeSet.Add(employee);
            var newUser = "michael_rho";
            var newPass = "2great5you";
            var newConfPass = "2great5you";
            var newPermission = "Manager";

            ctrl.Modify(
                userName: newUser,
                password: newPass,
                confPass: "somethign",
                permission: newPermission,
                emp: employee
            );
        }
    }
}