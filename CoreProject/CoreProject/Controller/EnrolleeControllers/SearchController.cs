using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Data.Enrollee;

namespace CoreProject.Controller.EnrolleeControllers
{
    public class SearchController
    {
        DbMgr Mgr = DbMgr.Instance;

        public List<Service> GetServices() {
            return Mgr.GetServices();
        }

        public void defaultLayout() {

        }

        public void dentalPlanClicked() {

        }
    }
}
