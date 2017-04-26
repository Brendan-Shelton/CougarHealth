using CoreProject.Data.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data
{
    /// <summary>
    /// A user that can be authenticated with a user name and password 
    /// </summary>
    public abstract class AuthUser
    {
        public byte[] Salt { get; private set; }

        /// <summary>
        /// encrypt password for local machine accessibility 
        /// </summary>
        /// <param name="plainPass">plain text password</param>
        /// <returns>hashed password</returns>
        public string Passwordify (
            string plainPass, 
            byte[] salt = null
        )
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
                int saltLen = rand.Next(minSalt, maxSalt);
                salt = new byte[saltLen];
                var rng = new RNGCryptoServiceProvider();
                rng.GetNonZeroBytes(salt);
                this.Salt = salt;
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
        /// Compares the hashed password "mine" vs the non-hashed password "theirs"
        /// </summary>
        /// <param name="mine"></param>
        /// <param name="theirs"></param>
        /// <returns></returns>
        public bool ComparePassword( string mine, string theirs )
        {
            int shaLen = 32;

            // grab the salt from the password 
            byte[] passBytes = Convert.FromBase64String(mine);
            var salt = new byte[passBytes.Length - shaLen];
            for ( int i = 0; i < salt.Length; i++ )
            {
                // copy the salt bytes 
                salt[i] = passBytes[i + shaLen];
            }

            var hashed = Passwordify(theirs, salt);

            return hashed.Equals(mine);

        }
        public abstract bool ValidPass(
            string password, 
            string confPass, 
            CreationException exception );
        public abstract bool ValidUser(
            string userName,
            CreationException exception );
        public abstract bool Login(string userName, string password);
    }
}
