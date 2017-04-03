﻿using System;
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
    public class Employee : IAuthUser
    {
        /// <summary>
        /// What the employee can do 
        /// </summary>
        public Permission Permission { get; set; }
        /// <summary>
        /// The username used to identify the employee stored in the database 
        /// </summary>
        public string UserName { get; set; }
        public string RealName { get; set; }
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
        public byte[] Salt { get; private set; }

        /// <summary>
        /// encrypt password for local machine accessibility 
        /// </summary>
        /// <param name="plainPass">plain text password</param>
        /// <returns>hashed password</returns>
        private string Passwordify(string plainPass, byte[] salt = null )
        {
            if ( string.IsNullOrWhiteSpace(plainPass) )
            {
                throw new ArgumentException("plainPass is empty");
            }

            
            // we only want to salt once 
            if ( this.Salt == null && salt == null )
            {
                /*
                 * generate salt 
                 */
                int minSalt = 4;
                int maxSalt = 8;

                var rand = new Random();
                // random number between 4 and 8 will be the length of the salt
                int saltLen = rand.Next(minSalt, minSalt);
                this.Salt = new byte[saltLen];
                var rng = new RNGCryptoServiceProvider();
                rng.GetNonZeroBytes(this.Salt);
            }
            else if ( this.Salt != null && salt == null )
            {
                salt = this.Salt; 
            }

            /*
             * generate hash 
             */
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainPass);
            // what we are actually going to hash 
            IEnumerable<byte> plainWithSalt = plainBytes.Concat(salt);
            var algo = new SHA256Managed();
            byte[] hash = algo.ComputeHash(plainWithSalt.ToArray());
            // store salt alongside hash so we can use it for retrieval 
            hash = hash.Concat(salt).ToArray();

            // in order to store as VARCHAR we need to convert to string
            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptedPass"></param>
        /// <returns></returns>
        private bool CheckPass (string providedPass )
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

        

        public bool CheckPass ( 
            string password, 
            string confPass, 
            CreationException exception )
        {
            throw new NotImplementedException();
        }

        public bool CheckUser ( string userName, CreationException exception )
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="confPass"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public bool ValidPass(string password, string confPass, CreationException exception)
        {
            var valid = confPass == password && password.Length >= 8;
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
        public bool ValidUser(string userName, CreationException exception)
        {
            // one or more alphanumeric characters and an underscore
            Regex validUser = new Regex(@"^[a-zA-Z0-9_]+$");
            // don't count the beginning and ending whitespace
            userName = userName.Trim();
            int userMax = 256;
            int userMin = 3;
            bool valid = validUser.IsMatch(userName) && 
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
        public IAuthUser Login(
            string userName, 
            string password, 
            AuthenticationException exception )
        {
            throw new NotImplementedException();
        }

    }
}
