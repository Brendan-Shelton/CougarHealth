using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data;
using CoreProject.Present;
using CoreProject.Data.Enrollee;
namespace CoreProject.Controller.EmployeeControllers
{
    public class CougarCostsController
    {

        public DbMgr dbmgr { get; private set; }
        private IEnumerable<InsurancePlan> Plans { get; }
        public CougarCostsController()
        {
            this.dbmgr = DbMgr.Instance;
            this.Plans = dbmgr.GetPlans();
        }
        

        public IEnumerable<InsurancePlan> GetPlans()
        {
            return Plans;
        }

        public InsurancePlan GetPlan(String name)
        {
            return dbmgr.GetPlanByType(name);
        }

        public double GetNum(string name, string type, bool isPercent)
        {
            var plan = dbmgr.GetPlanByType(type);
            double retVal = 0;

            switch (name)
            {
                case "Plan Year Max Benefit": retVal = plan.PYMB;
                    break;
                case "Out of Pocket Maximum Per Enrollee": retVal = plan.OPMIndividual;
                    break;
                case "Out of Pocket Maximum Per Family": retVal = plan.OPMFamily;
                    break;
                case "Annual Plan Deductable": retVal = plan.APD;
                    break;
                case "Primary Enrollee Fee": retVal = plan.PrimaryFee;
                    break;
                case "Primary Enrollee Change Fee": retVal = plan.PrimaryChangeFee;
                    break;
                case "Dependent Enrollee Fee": retVal = plan.DependentFee;
                    break;
                case "Dependent Enrollee Change Fee": retVal = plan.DependentChangeFee;
                    break;
                default:
                    for (int i = 0; i < plan.ServiceCosts.Length; i++)
                    {
                        if (plan.ServiceCosts[i].Name.Equals(name))
                        {
                            if (isPercent)
                            {
                                retVal = plan.ServiceCosts[i].PercentCoverage;
                            }
                            else
                            {
                                retVal = plan.ServiceCosts[i].RequiredCopayment;
                            }
                        }
                    }
                    break;
            }

            return retVal;
        }

        //replace with a more universal approach (ability for more than 2 plans)
        public void Update(CougarCosts costs)
        {
            dbmgr.adminUpdateVerify(1234, 1, "Benefits", "APD", false, costs.getAPDBasic());
            dbmgr.adminUpdateVerify(1234, 2, "Benefits", "APD", false, costs.getAPDExtend());

            dbmgr.adminUpdateVerify(1234, 1, "Benefits", "PYMB", false, costs.getPYMBBasic());
            dbmgr.adminUpdateVerify(1234, 2, "Benefits", "PYMB", false, costs.getPYMBExtend());

            dbmgr.adminUpdateVerify(1234, 1, "Benefits", "PrimaryFee", false, costs.getPrimaryBasicFee());
            dbmgr.adminUpdateVerify(1234, 2, "Benefits", "PrimaryFee", false, costs.getPrimaryExtendFee());

            dbmgr.adminUpdateVerify(1234, 1, "Benefits", "PrimaryChangeFee", false, costs.getPrimaryBasicFee());
            dbmgr.adminUpdateVerify(1234, 2, "Benefits", "PrimaryChangeFee", false, costs.getPrimaryExtendFee());

            dbmgr.adminUpdateVerify(1234, 1, "Benefits", "OPMFamily", false, costs.getOPMFBasic());
            dbmgr.adminUpdateVerify(1234, 2, "Benefits", "OPMFamily", false, costs.getOPMFExtend());

            dbmgr.adminUpdateVerify(1234, 1, "Benefits", "OPMIndividual", false, costs.getOPMIBasic());
            dbmgr.adminUpdateVerify(1234, 2, "Benefits", "OPMIndividual", false, costs.getOPMIExtend());

            dbmgr.adminUpdateVerify(1234, 1, "Hospital", "Inpatient", true, costs.getInpatientBasicPercent()/100);
            dbmgr.adminUpdateVerify(1234, 2, "Hospital", "Inpatient", true, costs.getInpatientExtendPercent()/100);

            dbmgr.adminUpdateVerify(1234, 1, "Hospital", "Inpatient", false, costs.getInpatientBasicCopay());
            dbmgr.adminUpdateVerify(1234, 2, "Hospital", "Inpatient", false, costs.getInpatientExtendCopay());

            dbmgr.adminUpdateVerify(1234, 1, "Hospital", "Inpatient (Behavioral Health", true, costs.getIBHBasicPercent()/100);
            dbmgr.adminUpdateVerify(1234, 2, "Hospital", "Inpatient (Behavioral Health", true, costs.getIBHExtendPercent()/100);

            dbmgr.adminUpdateVerify(1234, 1, "Hospital", "Inpatient (Behavioral Health", false, costs.getIBHBasicCopay());
            dbmgr.adminUpdateVerify(1234, 2, "Hospital", "Inpatient (Behavioral Health", false, costs.getIBHExtendCopay());

            dbmgr.adminUpdateVerify(1234, 1, "Hospital", "Emergency Room", true, costs.getERBasicPercent()/100);
            dbmgr.adminUpdateVerify(1234, 2, "Hospital", "Emergency Room", true, costs.getERExtendPercent()/100);

            dbmgr.adminUpdateVerify(1234, 1, "Hospital", "Emergency Room", false, costs.getERBasicCopay());
            dbmgr.adminUpdateVerify(1234, 2, "Hospital", "Emergency Room", false, costs.getERExtendCopay());

            dbmgr.adminUpdateVerify(1234, 1, "Hospital", "Outpatient Surgery", true, costs.getOSBasicPercent()/100);
            dbmgr.adminUpdateVerify(1234, 2, "Hospital", "Outpatient Surgery", true, costs.getOSExtendPercent()/100);

            dbmgr.adminUpdateVerify(1234, 1, "Hospital", "Outpatient Surgery", false, costs.getOSBasicCopay());
            dbmgr.adminUpdateVerify(1234, 2, "Hospital", "Outpatient Surgery", false, costs.getOSExtendcopay());

            dbmgr.adminUpdateVerify(1234, 1, "Hospital", "Diagnostic Lab and x-ray", true, costs.getDLXrayBasic()/100);
            dbmgr.adminUpdateVerify(1234, 2, "Hospital", "Diagnostic Lab and x-ray", true, costs.getDLXrayExtend() / 100);

            dbmgr.adminUpdateVerify(1234, 1, "Physician", "Office Visit", true, costs.getPOVBasicPercent() / 100);
            dbmgr.adminUpdateVerify(1234, 2, "Physician", "Office Visit", true, costs.getPOVExtendPercent() / 100);
            dbmgr.adminUpdateVerify(1234, 2, "Physician", "Office Visit", false, costs.getPOVExtendCopay());

            dbmgr.adminUpdateVerify(1234, 1, "Physician", "Specialist Visit", true, costs.getSOVBasicPercent() / 100);
            dbmgr.adminUpdateVerify(1234, 2, "Physician", "Specialist Visit", true, costs.getSOVExtendPercent() / 100);
            dbmgr.adminUpdateVerify(1234, 2, "Physician", "Specialist Visit", false, costs.getSOVExtendCopay());

            dbmgr.adminUpdateVerify(1234, 1, "Physician", "Preventive Services", true, costs.getPSBasicPercent() / 100);
            dbmgr.adminUpdateVerify(1234, 2, "Physician", "Preventive Services", true, costs.getPSExtendPercent() / 100);

            dbmgr.adminUpdateVerify(1234, 1, "Physician", "Baby Services", true, costs.getBCBasicPercent() / 100);
            dbmgr.adminUpdateVerify(1234, 2, "Physician", "Baby Services", true, costs.getBCExtendPercent() / 100);

            dbmgr.adminUpdateVerify(1234, 1, "Other", "Durable Medical Equipment", true, costs.getDMEBasicPercent() / 100);
            dbmgr.adminUpdateVerify(1234, 2, "Other", "Durable Medical Equipment", true, costs.getDMEExtendPercent() / 100);

            dbmgr.adminUpdateVerify(1234, 1, "Other", "Nursing Facility", true, costs.getNFBasicPercent() / 100);
            dbmgr.adminUpdateVerify(1234, 2, "Other", "Nursing Facility", true, costs.getNFExtendPercent() / 100);

            dbmgr.adminUpdateVerify(1234, 1, "Other", "Physical Therapy", true, costs.getPTBasicPercent() / 100);
            dbmgr.adminUpdateVerify(1234, 2, "Other", "Physical Therapy", true, costs.getPTExtendPercent() / 100);
            dbmgr.adminUpdateVerify(1234, 2, "Other", "Physical Therapy", false, costs.getPTExtendCopay());
           
        }
    }
}
