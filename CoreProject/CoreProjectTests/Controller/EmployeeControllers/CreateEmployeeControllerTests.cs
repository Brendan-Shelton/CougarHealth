using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Controller.EmployeeControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Employees;
using CoreProject.Data;
using System.Data;

namespace CoreProject.Controller.EmployeeControllers.Tests
{
    [TestClass()]
    public class CreateEmployeeControllerTests
    {
        /// <summary>
        /// Test it works under correct conditions
        /// </summary>
        [TestMethod()]
        public void CreateTest()
        {
            var ctrl = new CreateEmployeeController();
            var mgr = DbMgr.Instance;
            var username = "michael_rhodes_";
            var password = "12345678";
            var confpass = "12345678";

            int newId = ctrl.Create(username, password, confpass, "Manager");
            Employee justCreated = mgr.GetEmployeeById(newId);

            Assert.IsNotNull(justCreated);
        }

        /// <summary>
        /// Make sure it causes an exception to have mismatched passwords 
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(CreationException))]
        public void CreateMismatchTest()
        {
            var ctrl = new CreateEmployeeController();
            var mgr = DbMgr.Instance;
            var username = "michael_rhodes_";
            var password = "12345678";
            var confpass = "12345278";

            int newId = ctrl.Create(username, password, confpass, "Manager");
        }
        /// <summary>
        /// test that an exception fires when we fail one of our data checks 
        /// (ValidUser from Employee.cs)
        /// INTEGRATION TEST with EMPLOYEE
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(CreationException))]
        public void CreateInvalidTest()
        {
            var ctrl = new CreateEmployeeController();
            var mgr = DbMgr.Instance;
            var username = "michael rhodes_";
            var password = "12345678";
            var confpass = "12345678";

            int newId = ctrl.Create(username, password, confpass, "Manager");
        }

        /// <summary>
        /// Choose a permission that doesn't exist - cause an exception
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(CreationException))]
        public void CreateBadPermTest()
        {
            var ctrl = new CreateEmployeeController();
            var mgr = DbMgr.Instance;
            var username = "michael_rhodes_";
            var password = "12345678";
            var confpass = "12345678";

            int newId = ctrl.Create(username, password, confpass, "Dragon Slayer");
        }

        /// <summary>
        /// Cause a data exception by saving the same employee twice 
        /// INTEGRATION TEST WITH EMPLOYEE AND DBMGR
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(DataException))]
        public void CreateDoubleTest()
        {
            var ctrl = new CreateEmployeeController();
            var mgr = DbMgr.Instance;
            var username = "michael_rhodes_";
            var password = "12345678";
            var confpass = "12345678";

            int newId = ctrl.Create(username, password, confpass, "Manager");
            int duplicate = ctrl.Create(username, password, confpass, "Manager");
        }
    }
}