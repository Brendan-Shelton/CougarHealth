using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Data.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.Employees.Tests
{
    [TestClass()]
    public class EmployeeTests
    {
        [TestMethod()]
        public void ValidUserTest()
        {
            // arrange
            var employee = new Employee();
            // good values - can only be alphanumeric with underscores
            var goodUser = "michael_rhodes_";
            var goodNoUnder = "michaelrhodes";
            var goodNumber = "michael1234";
            var goodCapital = "MichaelRhodes";
            // bad values - no spaces, cannot be empty, cannot be null, no special chars
            var badSpace = "Michael Rhodes";
            var badEmpty = "";
            string badNull = null;
            var badSpecial = "Michael@";
            var throwaway = new CreationException();

            var validGood = employee.ValidUser(goodUser, throwaway);
            var validUnder = employee.ValidUser(goodNoUnder, throwaway);
            var validNumber = employee.ValidUser(goodNumber, throwaway);
            var validCapital = employee.ValidUser(goodCapital, throwaway);
            var invalidSpace = employee.ValidUser(badSpace, throwaway);
            var invalidEmpty = employee.ValidUser(badEmpty, throwaway);
            var invalidNull = employee.ValidUser(badNull, throwaway);
            var invalidSpecial = employee.ValidUser(badSpecial, throwaway);

            Assert.IsTrue(validGood);
            Assert.IsTrue(validCapital);
            Assert.IsTrue(validNumber);
            Assert.IsTrue(validUnder);
            Assert.IsFalse(invalidEmpty);
            Assert.IsFalse(invalidSpace);
            Assert.IsFalse(invalidSpecial);
            Assert.IsFalse(invalidNull);

        }

        [TestMethod()]
        public void ValidPassTest()
        {
            var employee = new Employee();
            // good values - needs to be more than 8 characters and conf needs 
            // to match original 
            var goodPass = "michael_rhodes_";
            var goodConf = "michael_rhodes_";
            // bad values - less than 8 characters and null
            string badNull = null;
            var badLen = "michael";
            var badConf = "michael-rhodes-";
            var throwaway = new CreationException();

            var validPass = employee.ValidPass(goodPass, goodConf, throwaway);
            var invalidMismatch = employee.ValidPass(goodPass, badConf, throwaway);
            var invalidLen = employee.ValidPass(badLen, badLen, throwaway);
            var invalidNull = employee.ValidPass(badNull, badNull, throwaway);

            Assert.IsTrue(validPass);
            Assert.IsFalse(invalidMismatch);
            Assert.IsFalse(invalidNull);
            Assert.IsFalse(invalidLen);
        }

        [TestMethod()]
        public void CheckPassTest()
        {
            var employee = new Employee();
            var goodPass = "michael_rhodes_";
            var badPass = "michael-rhodes-";
            employee.Password = goodPass;

            bool match = employee.CheckPass(goodPass);
            bool noMatch = employee.CheckPass(badPass);

            Assert.IsTrue(match);
            Assert.IsFalse(noMatch);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckPassEmptyTest()
        {
            var employee = new Employee();
            var goodPass = "michael_rhodes_";
            var empty = " ";
            employee.Password = goodPass;

            // passwordify doesn't work with empty strings
            employee.CheckPass(empty);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckPassNullTest()
        {
            var employee = new Employee();
            var goodPass = "michael_rhodes_";
            string nullstr = null;
            employee.Password = goodPass;

            // passwordify doesn't work with null strings
            employee.CheckPass(nullstr);
        }

        [TestMethod()]
        public void PasswordifyTest()
        {
            // arrange 
            var employee = new Employee();
            var password = "michael_rhodes_";
            var notPass= "michael-rhodes-";
            var sha256Bytes = 32;


            string hashPass = employee.Passwordify(password);
            string notHash = employee.Passwordify(notPass);
            byte[] hashBytes = Convert.FromBase64String(hashPass);

            var salt = new byte[hashBytes.Length - sha256Bytes];
            for (int i = 0; i < salt.Length; i++)
            {
                salt[i] = hashBytes[sha256Bytes + i];
            }
            string rePassword = employee.Passwordify(password, salt);

            // test length of hash to make sure it is over 32 bytes (SHA256)
            Assert.IsTrue(hashBytes.Length > sha256Bytes);
            // there is atleast 4 bytes of salt 
            Assert.IsTrue(hashBytes.Length >= sha256Bytes + 4);
            // assure no basic collisions 
            Assert.IsFalse(hashPass == notHash);
            // assure using the same salt for hash will produce the same hash
            Assert.IsTrue(hashPass == rePassword);
        }
    }
}