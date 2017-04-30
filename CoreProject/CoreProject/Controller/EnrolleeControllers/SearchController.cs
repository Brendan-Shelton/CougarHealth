using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Data.Enrollee;
using CoreProject.Data.HealthcareServiceProvider;

namespace CoreProject.Controller.EnrolleeControllers
{
    public class SearchController
    {
        DbMgr Mgr = DbMgr.Instance;

        private InsurancePlan localPlan;

        public InsurancePlan getLocalPlan() { return localPlan; }
        public void setLocalPlan(InsurancePlan plan) { localPlan = plan; }

        public InsurancePlan GetPlan(string name)
        {
            if (name == null)
            {
                return null;
            }
            else if (name.Equals(""))
            {
                return null;
            }
            else
            {
                var plan = Mgr.GetPlanByType(name);
                setLocalPlan(plan);
                return plan;
            }
        }

        public IEnumerable<InsurancePlan> GetPlans()
        {
            return Mgr.GetPlans();
        }

        public IEnumerable<HSP> GetProviders(string name)
        {
            if (name == null)
            {
                return null;
            }
            else if (name.Equals(""))
            {
                return null;
            }
            else
            {
                Service serviceFound = null;

                if (localPlan != null)
                {

                    foreach (var service in localPlan.ServiceCosts)
                    {
                        if (service.Name.Equals(name))
                        {
                            serviceFound = service;
                        }
                    }
                    if (serviceFound != null)
                    {
                        return Mgr.GetProviders(serviceFound);
                    }
                }
                return null;
            }
        }
    }
}
