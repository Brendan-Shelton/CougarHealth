using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.Employees
{
    /// <summary>
    /// The permission of an employee allows to only be able to do certain 
    /// things
    /// PlanAdmin - can access the CougarCostsController
    /// EnrolleeSupport - can access EnrolleeSupportController
    /// HSPSupport - can access HSPSupportController
    /// Accountant - can access the RangeReportController and MonthReportController
    /// Manager - can do anything plus ManageEmployeeController and CreateEmployeeController
    /// </summary>
    public enum Permission
    {
        PlanAdmin,
        EnrolleeSupport,
        HSPSupport,
        Accountant,
        Manager,
        Other
    }
}
