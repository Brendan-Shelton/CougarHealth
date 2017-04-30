using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Data.HealthcareServiceProvider;

namespace CoreProject.Controller.HSPControllers
{
    public class HSPLoginController
    {
        public DbMgr Mgr { get; set; } = DbMgr.Instance;

        /// <summary>
        /// Find the HSP corresponding to the companyName and try to log it in
        /// returns null if the login fails 
        /// </summary>
        /// <param name="companyName"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        public HSP Login( string companyName, string pin )
        {
            HSP hsp = Mgr.GrabHspByName(companyName);
            // we could have not recieved an HSP back, so we need to use the 
            // null conditional operator 
            bool? isLogged = hsp?.Login(companyName, pin);

            // isLogged could be null so we need to compare it with true
            return (isLogged == true) ? hsp : null;
        }
    }
}
