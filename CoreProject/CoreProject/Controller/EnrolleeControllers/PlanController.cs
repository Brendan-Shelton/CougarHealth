using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Present;

namespace CoreProject.Controller.EnrolleeControllers
{

   
    public class PlanController
    {
        public DbMgr dbmgr { get; private set; }
        private int _primaryId;

        public PlanController(int primary)
        {
            this._primaryId = primary;
            this.dbmgr = DbMgr.Instance;
        }

        
        public void update(EnrolleeCosts costs)
        {
           var enrollee = dbmgr.FindPrimaryById(_primaryId);

           

        }


    }
}
