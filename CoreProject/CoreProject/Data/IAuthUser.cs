using CoreProject.Data.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data
{
    /// <summary>
    /// A user that can be authenticated with a user name and password 
    /// </summary>
    public interface IAuthUser
    {
        bool ValidPass(
            string password, 
            string confPass, 
            CreationException exception );
        bool ValidUser(
            string userName,
            CreationException exception );
        IAuthUser Login(string userName,
            string password,
            AuthenticationException exception);
    }
}
