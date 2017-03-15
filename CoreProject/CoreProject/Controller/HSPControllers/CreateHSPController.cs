using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Data.HealthcareServiceProvider;

namespace CoreProject.Controller.HSPControllers
{
    public class CreateHSPController
    {
        public DbMgr Mgr;

        public HSP hsp;

        public CreateHSPController()
        {
            this.Mgr = DbMgr.Instance;
        }

        // TODO: Validation of inputs

        public void CreateHSP(string name, List<string> services, string address, string pin)
        {
            this.hsp = new HSP(pin)
            {
                Name = name,
                ServicesOffered = services,
                Address = address,
            };
        }
    }
}
