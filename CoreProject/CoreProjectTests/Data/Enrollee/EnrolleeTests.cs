using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Data.Enrollee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.Enrollee.Tests
{
    [TestClass()]
    public class EnrolleeTests
    {
        private DbMgr mgr = DbMgr.Instance; 

        [TestMethod()]
        public void LoginTest()
        {
            var primary = new PrimaryEnrollee("2103")
            {
                MailingAddr = "805 N Ealy",
                Email = "me@michaelrhodes.us",
                FirstName = "Michael",
                LastName = "Rhodes",
                HomePhone = "2178214819",
                SSN = "555102104"
            };

            var isLogged = primary.Login("me@michaelrhodes.us", "2103");

            Assert.IsTrue(isLogged);
        }
    }
}