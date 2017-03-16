using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Present;
namespace CoreProject.Controller.EmployeeControllers
{
    public class CougarCostsController
    {

        public DbMgr dbmgr { get; private set; }

        public CougarCostsController()
        {
            this.dbmgr = DbMgr.Instance;
        }

        public void update(CougarCosts costs)
        {
                        

        }
    }
}
