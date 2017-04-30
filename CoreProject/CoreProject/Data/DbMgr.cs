using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Data.Enrollee;
using CoreProject.Data.HealthcareServiceProvider;
using CoreProject.Data.Employees;
using System.Collections;

namespace CoreProject.Data
{
    public static class SqlClientExtensions
    {
        /// <summary>
        /// Extension method that gets the first element out of a sql data reader
        /// and manipulates it into the object T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rdr"></param>
        /// <param name="manipulator"></param>
        /// <returns></returns>
        public static T Single<T>(
            this SqlDataReader rdr,
            Func<SqlDataReader, T> manipulator
        )
        {
            T result = default(T);
            if (rdr.Read())
            {
                result = manipulator(rdr);
            }

            return result;
        }

        /// <summary>
        /// Executes the SQL command given and returns back the id of the 
        /// object interacted with 
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static int CommandWithId(this SqlCommand cmd)
        {
            cmd.CommandText = cmd.CommandText + "SELECT CAST(scope_identity() AS int)";
            object lastId = cmd.ExecuteScalar();
            if (lastId == DBNull.Value)
            {
                throw new DataException("I tried to insert your thing, but nothing got inserted");
            }

            return Convert.ToInt32(lastId);
        }
    }

    public class DbMgr
    {
        private static DbMgr _instance;

        private int AdminPassKey = 1234;
        /// <summary>
        /// Readonly connection to the CougarHealth.mdf embedded database. 
        /// </summary>
        private SqlConnection Connection { get; }
        /// <summary>
        /// DbMgr class. The arrow is a lambda express (think of a one line 
        /// function) that returns the private _instance static field if it 
        /// is not null (that is what the '??' operator is for). If it is null
        /// it instantiates the _instance field and then returns it 
        /// </summary>
        //public static DbMgr Instance => _instance ?? (_instance = new DbMgr());

        public static DbMgr Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbMgr();
                }
                return _instance;
            }
        }

        /// <summary>
        /// A fake DB set for primary enrollees that we create
        /// </summary>
        //public HashSet<PrimaryEnrollee> PrimaryEnrolleeSet { get; set; } = new HashSet<PrimaryEnrollee>()
        //{
        //    // temp test enrollee 
        //    new PrimaryEnrollee ("1234")
        //    {
        //        Email = "guest@guest",
        //        FirstName = "Guest",
        //        LastName = "Guest",
        //        HomePhone = "5555555555",
        //        MobilePhone = "5555555555",
        //        BillingAddr = "666 Avenue St.",
        //        MailingAddr = "666 Avenue St.",
        //        SSN = "123456789"
        //    }

        //};

        public HashSet<DependentEnrollee> DependentEnrolleeSet { get; set; }

        public HashSet<Bill> BillSet { get; set; }


        public HashSet<HSP> HspSet { get; }

        public HashSet<Employee> EmployeeSet { get; } = new HashSet<Employee>()
        {
            // the test employee.
            new Employee
            {
                UserName = "Guest",
                Password = "guest",
                Permission = Permission.Manager
            }
        };
        /// <summary>
        /// TEMP method to allow logging in as guest when no one is in the system 
        /// </summary>
        /// <returns></returns>
        internal Employee GetGuest()
        {
            return (from employee in EmployeeSet
                    where employee.UserName == "Guest"
                    select employee)?.FirstOrDefault();
        }





        /// <summary>
        /// Allows an addition to the BillSet. Takes in a Bill as a parameter, Void.
        /// </summary>
        /// <param name="bill"></param>
        public void addBill(Bill bill)
        {
            // BillSet.Add(bill);
            int? planNum = null;
           try
            {
                //Try to insert into database
                this.Connection.Open();
                var insertBill = @"INSERT INTO Bill
                                   (
                                        Date,
                                        TotalBillAmount,
                                        EnrolleeBillAmount,
                                        ServiceId,
                                        HSPId,
                                        PrimaryId,
                                        DependentId,
                                        IsPrimary
                                    )
                                    VALUES
                                    (
                                        @date,
                                        @totalBillAmount,
                                        @enrolleeBillAmount,
                                        @serviceId,
                                        @hspId,
                                        @primaryId,
                                        @dependentId,
                                        @isPrimary
                                    );
                                     SELECT CAST(scope_identity() AS int)";

                using (var planCmd = new SqlCommand(insertBill, this.Connection))
                {
                    //object lastId = planCmd.ExecuteScalar();
                    //if (lastId == DBNull.Value)
                    //{
                    //    throw new DataException("I tried to insert your enrollee, but nothing got inserted");
                    // }
                    planCmd.Parameters.AddWithValue("@date", "20000101");
                    planCmd.Parameters.AddWithValue("@totalBillAmount", bill.totalBillAmount);
                    planCmd.Parameters.AddWithValue("@enrolleeBillAmount", bill.enrolleeBillAmount);
                    planCmd.Parameters.AddWithValue("@serviceId", bill.serviceId);
                    planCmd.Parameters.AddWithValue("@hspId", bill.hspId);
                    if (bill.IsPrimary)
                    {
                        planCmd.Parameters.AddWithValue("@primaryId", bill.enrolleeId);
                        planCmd.Parameters.AddWithValue("@dependentId", DBNull.Value);
                    }

                    else
                    {
                        planCmd.Parameters.AddWithValue("@primaryId", DBNull.Value);
                        planCmd.Parameters.AddWithValue("@dependentId", bill.enrolleeId);
                    }
                        
                    planCmd.Parameters.AddWithValue("@isPrimary", bill.IsPrimary);
                    planNum = planCmd.CommandWithId();
                }


            }
            
            finally
            {
                this.Connection.Close();
            }
        }
        /// <summary>
        /// Allows to search for all bills attached to a certain email. This is to find Dependent-specific bills.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Bill[] GetBillsByEmail(String email)
        {
            var bills = new Bill[BillSet.Count];
            int billCount = 0;
            var enumerator = BillSet.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Current.enrolleeEmail.Equals(email))
                {
                    bills[billCount] = enumerator.Current;
                    billCount++;
                }
            }

            var finalBills = new Bill[billCount];

            for (int i = 0; i < finalBills.Length; i++)
            {
                finalBills[i] = bills[i];
            }

            return finalBills;
        }
        /// <summary>
        /// This finds all of the Bills associated with a Primary Id. Used to display primary Enrollee's Bills for everyone on Plan. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HashSet<Bill> GetBillsById(int id)
        {
            string selBill = @"SELECT Id, Date, TotalBillAmount, EnrolleeBillAmount, ServiceId, PlanNum, HSPId, PrimaryId, DependentId, IsPrimary
                               FROM Bill 
                               WHERE PrimaryId = @id";
            HashSet<Bill> bills = new HashSet<Bill>();

            try
            {
                this.Connection.Open();
                using (var cmd = new SqlCommand(selBill, this.Connection))
                {

                    cmd.Parameters.AddWithValue("@id", id);
                    var rdr = cmd.ExecuteReader();

                    

                    while (rdr.Read())
                    {
                        DateTime date = Convert.ToDateTime(rdr["Date"]);
                        HSP hsp = GrabHspById(Convert.ToInt32(rdr["HSPId"]));
                        int service = Convert.ToInt32(rdr["ServiceId"]);
                        int enrolleeId;
                        if (Convert.ToBoolean(rdr["IsPrimary"]))
                            enrolleeId = Convert.ToInt32(rdr["PrimaryId"]);
                        else
                            enrolleeId = Convert.ToInt32(rdr["DependentId"]);
                        string enrolleeEmail = Convert.ToString(rdr["EnrolleeEmail"]);
                        double totalBill = Convert.ToDouble(rdr["TotalBillAmount"]);
                        double enrolleeBill = Convert.ToDouble(rdr["EnrolleeBillAmount"]);
                       
                        bills.Add(new Bill(
                                                date,
                                                hsp.Id,
                                                service,
                                                enrolleeId,
                                                enrolleeEmail,
                                                totalBill,
                                                enrolleeBill 
                                               ));
                    }
                }
            }

            finally
            {
                this.Connection.Close();
            }


            return bills;





            //from Bill in BillSet
            //       where Bill.enrolleeId == id
            //       select Bill);

            // var bill = from Bill in BillSet where Bill.enrolleeId == id select Bill;

            //var plan = GetPlanByPrimary(id);
            //var enrollee = FindPrimaryById(id);
            //var bills = new Bill[BillSet.Count];
            //int billCount = 0;
            //var enumerator = BillSet.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    if (enumerator.Current.enrolleeId == id)
            //    {
            //        bills[billCount] = enumerator.Current;
            //        billCount++;
            //    }

            //    if (enrollee.IsPrimary)
            //    {
            //        for (int i = 0; i < plan.Dependents.Count; i++)
            //        {
            //            if (enumerator.Current.enrolleeId == plan.Dependents.ElementAt(i))
            //            {
            //                bills[billCount] = enumerator.Current;
            //                billCount++;
            //            }
            //        }
            //    }


            //}



            //var finalBills = new Bill[billCount];

            //for (int i = 0; i < finalBills.Length; i++)
            //{
            //    finalBills[i] = bills[i];
            //}

            //return finalBills;


        }


        /// <summary>
        /// Saves an entire employee object into the database. If the employee 
        /// was already inserted it throws a DataException
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int SaveEmployee(Employee employee)
        {
            int permissionId, resultId;

            var getPermissionId = @"SELECT Id FROM Permission 
                                    WHERE Permission.Name = @name";

            var saveEmployee = @"INSERT INTO Employee
                                 (UserName,
                                 Password,
                                 PermissionId)
                                 VALUES
                                 (@user,
                                  @pass,
                                  @PermissionId
                                 )";

            try
            {
                this.Connection.Open();

                using (var getPermissionIdCmd = new SqlCommand(getPermissionId, this.Connection))
                {
                    getPermissionIdCmd.Parameters.AddWithValue("@name", Enum.GetName(typeof(Permission), employee.Permission).ToString());
                    permissionId = (int)getPermissionIdCmd.ExecuteScalar();
                }

                using (var saveEmployeeCmd = new SqlCommand(saveEmployee, this.Connection))
                {
                    saveEmployeeCmd.Parameters.AddWithValue("@user", employee.UserName);
                    saveEmployeeCmd.Parameters.AddWithValue("@pass", employee.Password);
                    saveEmployeeCmd.Parameters.AddWithValue("@PermissionId", permissionId);

                    object lastId = saveEmployeeCmd.CommandWithId();
                    if (lastId == DBNull.Value)
                    {
                        throw new DataException("I tried to insert your enrollee, but nothing got inserted");
                    }
                    resultId = Convert.ToInt32(lastId);
                }
            }
            finally
            {
                this.Connection.Close();
            }

            // TODO: update this to work with new database
            if (!EmployeeSet.Add(employee))
            {
                throw new DataException($"{employee.UserName} was already in our system");
            }

            return resultId;
        }
        /// <summary>
        /// Basically SELECT * FROM Employee
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetAllEmployees()
        {



            List<Employee> employees = new List<Employee>();
            try
            {
                this.Connection.Open();
                var getEmployees = @"SELECT * FROM Employee";
                var getPermission = "SELECT Name FROM Permission WHERE Permission.Id = (SELECT PermissionId from Employee WHERE Employee.UserName = @name);";
                using (var getEmployeesCmd = new SqlCommand(getEmployees, this.Connection))
                {
                    var rdr = getEmployeesCmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var employee = new Employee
                        {
                            Id = Convert.ToInt32(rdr["Id"]),
                            UserName = Convert.ToString(rdr["UserName"]),
                            Password = Convert.ToString(rdr["Password"])
                        };


                        employees.Add(employee);
                    }
                    rdr.Close();
                }

                foreach (var employee in employees)
                {
                    using (var getPermissionCmd = new SqlCommand(getPermission, this.Connection))
                    {
                        getPermissionCmd.Parameters.AddWithValue("@name", employee.UserName);
                        var res = (string)getPermissionCmd.ExecuteScalar();

                        switch (res)
                        {
                            case "None":
                                employee.Permission = Permission.None;
                                break;
                            case "PlanAdmin":
                                employee.Permission = Permission.PlanAdmin;
                                break;
                            case "EnrolleeSupport":
                                employee.Permission = Permission.EnrolleeSupport;
                                break;
                            case "HSPSupport":
                                employee.Permission = Permission.HSPSupport;
                                break;
                            case "Accountant":
                                employee.Permission = Permission.Accountant;
                                break;
                            case "Manager":
                                employee.Permission = Permission.Manager;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            finally
            {
                this.Connection.Close();
            }
            return employees;
        }
        /// <summary>
        /// Update the employee that corresponds to the id of the employee 
        /// supplied to the method 
        /// </summary>
        /// <param name="emp">The new credentials of the employee </param>
        /// <returns></returns>
        public int UpdateEmployee(Employee emp)
        {

            int permissionId, returnId;

            var updateEmployee = @"UPDATE Employee SET UserName = @name, Password = @pass, 
                                   PermissionId = @permissionId OUTPUT INSERTED.Id WHERE Id = @id;";

            var getPermissionId = @"SELECT Id FROM Permission 
                                    WHERE Permission.Name = @name";


            try
            {
                this.Connection.Open();

                using (var getPermissionIdCmd = new SqlCommand(getPermissionId, this.Connection))
                {
                    getPermissionIdCmd.Parameters.AddWithValue("@name", Enum.GetName(typeof(Permission), emp.Permission).ToString());
                    permissionId = (int)getPermissionIdCmd.ExecuteScalar();
                }

                using (var updateEmployeeCmd = new SqlCommand(updateEmployee, this.Connection))
                {
                    if (emp.NewName != null)
                    {
                        updateEmployeeCmd.Parameters.AddWithValue("@name", emp.NewName);
                    }
                    else
                    {
                        updateEmployeeCmd.Parameters.AddWithValue("@name", emp.UserName);
                    }

                    updateEmployeeCmd.Parameters.AddWithValue("@pass", emp.Password);
                    updateEmployeeCmd.Parameters.AddWithValue("@permissionId", permissionId);
                    updateEmployeeCmd.Parameters.AddWithValue("@id", emp.Id);

                    //returnId = updateEmployeeCmd.CommandWithId();
                    returnId = Convert.ToInt32(updateEmployeeCmd.ExecuteScalar());
                }


            }
            finally
            {
                this.Connection.Close();
            }



            /*var toUpdate = (from employee in EmployeeSet
                            where employee.UserName == emp.UserName
                            select employee).FirstOrDefault();
            if (toUpdate == null)
            {
                throw new DataException("Employee doesn't exist in database");
            }

            if (emp.NewName != null)
            {
                emp.UserName = emp.NewName;
            }

            toUpdate.UserName = emp.UserName;
            toUpdate.Password = emp.Password;
            toUpdate.Permission = emp.Permission;*/


            return returnId;
        }

        /// <summary>
        /// Get an employee object corresponding to the provided username
        /// </summary>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public Employee GetEmployeeByName(string employeeName)
        {
            Employee employee = null;
            string permissionString;
            var getEmployee = @"SELECT * FROM Employee 
                              WHERE Employee.UserName = @name";

            var getPermission = @"SELECT Name FROM Permission 
                                WHERE Permission.Id = 
                                (SELECT PermissionId FROM Employee WHERE Employee.UserName = @name);";

            try
            {
                this.Connection.Open();
                using (var getEmployeeCmd = new SqlCommand(getEmployee, this.Connection))
                {
                    getEmployeeCmd.Parameters.AddWithValue("@name", employeeName);
                    var rdr = getEmployeeCmd.ExecuteReader();
                    employee = rdr.Single(e => new Employee
                    {
                        Id = Convert.ToInt32(e["id"]),
                        UserName = Convert.ToString(e["UserName"]),
                        Password = Convert.ToString(e["Password"])
                    });
                    rdr.Close();
                }

                using (var getPermissionCmd = new SqlCommand(getPermission, this.Connection))
                {
                    getPermissionCmd.Parameters.AddWithValue("@name", employeeName);
                    permissionString = (string)getPermissionCmd.ExecuteScalar();
                }

                switch (permissionString)
                {
                    case "None":
                        employee.Permission = Permission.None;
                        break;
                    case "PlanAdmin":
                        employee.Permission = Permission.PlanAdmin;
                        break;
                    case "EnrolleeSupport":
                        employee.Permission = Permission.EnrolleeSupport;
                        break;
                    case "HSPSupport":
                        employee.Permission = Permission.HSPSupport;
                        break;
                    case "Accountant":
                        employee.Permission = Permission.Accountant;
                        break;
                    case "Manager":
                        employee.Permission = Permission.Manager;
                        break;
                    default:
                        break;
                }

            }
            finally
            {
                this.Connection.Close();
            }

            return employee;

            //return (from employee in EmployeeSet
            //        where employee.UserName == employeeName
            //        select employee)?.FirstOrDefault();
        }

        public Employee GetEmployeeById(int id)
        {

            string permissionString;

            var getEmployee = @"SElECT * FROM Employee 
                              WHERE Employee.Id = @id";

            var getPermission = @"SELECT Name FROM Permission 
                                WHERE Permission.Id = 
                                (SELECT PermissionId FROM Employee WHERE Id = @id);";

            Employee employee = null;
            try
            {
                this.Connection.Open();
                using (var getEmployeeCmd = new SqlCommand(getEmployee, this.Connection))
                {
                    getEmployeeCmd.Parameters.AddWithValue("@id", id);
                    var rdr = getEmployeeCmd.ExecuteReader();
                    employee = rdr.Single(e => new Employee
                    {
                        Id = Convert.ToInt32(e["id"]),
                        UserName = Convert.ToString(e["UserName"])
                    });
                    rdr.Close();
                }


                using (var getPermissionCmd = new SqlCommand(getPermission, this.Connection))
                {
                    getPermissionCmd.Parameters.AddWithValue("@id", id);
                    permissionString = (string)getPermissionCmd.ExecuteScalar();
                }

                switch (permissionString)
                {
                    case "None":
                        employee.Permission = Permission.None;
                        break;
                    case "PlanAdmin":
                        employee.Permission = Permission.PlanAdmin;
                        break;
                    case "EnrolleeSupport":
                        employee.Permission = Permission.EnrolleeSupport;
                        break;
                    case "HSPSupport":
                        employee.Permission = Permission.HSPSupport;
                        break;
                    case "Accountant":
                        employee.Permission = Permission.Accountant;
                        break;
                    case "Manager":
                        employee.Permission = Permission.Manager;
                        break;
                    default:
                        break;
                }

            }
            finally
            {
                this.Connection.Close();
            }

            //var result = (from employee in EmployeeSet
            //             where employee.Id == id
            //            select employee)?.FirstOrDefault();

            return employee;
        }

        public void adminUpdateVerify(int passkey, string planType, String category,
            String name, Boolean percent, Boolean max, double val)
        {
            if (passkey == AdminPassKey)
            {
                AdminUpdatePlan(planType, category, name, percent, max, val);
            }
        }



        /// <summary>
        /// Takes an int, String, String, Bool, and int and updates the corresponding values of the insurance plan
        /// </summary>
        /// <param name="planType"></param>
        /// <param name="category"></param>
        /// <param name="name"></param>
        /// <param name="percent"></param>
        /// <param name="val"></param>

        public int? AdminUpdatePlan(String planType, String category, String name, Boolean percent, Boolean max, double val)
        {
            //TODO: Fix this method 

            //    APD = 250.0,
            //    PYMB = 250000.0,
            //    DependentFee = 20.0,
            //    PrimaryFee = 45.0,
            //    DependentChangeFee = 40.0,
            //    PrimaryChangeFee = 150.0,
            //    OPMFamily = 18000,
            //    OPMIndividual = 9500,
            int? updateId = null;

            // keeping the weird method prototype, so I apologize for shitty 
            // code
            if (category.Equals("Benefits"))
            {
                // strings for name are hard coded, and so should have a sql injection
                var updatePlan = "UPDATE InsurancePlan " +
                                $"SET { name } = {val}" +
                                @"OUTPUT INSERTED.Id WHERE Type = @type;";
                try
                {
                    this.Connection.Open();
                    using (var cmd = new SqlCommand(updatePlan, this.Connection))
                    {
                        cmd.Parameters.AddWithValue("@type", planType);
                        updateId = (int)cmd.ExecuteScalar();
                    }
                }
                finally
                {
                    this.Connection.Close();
                }
            }
            else
            {
                // find the service
                var findServices = @"SELECT Id FROM Service 
                                    WHERE Service.InsurancePlanId = 
                                        (SELECT Id FROM InsurancePlan 
                                         WHERE InsurancePlan.Type = @type);";
                List<int> serviceIds = null;
                string inService = null;
                try
                {
                    this.Connection.Open();
                    using (var serviceCmd = new SqlCommand(findServices, this.Connection))
                    {
                        serviceCmd.Parameters.AddWithValue("@type", planType);
                        var rdr = serviceCmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            object id = rdr["Id"];
                            if (id == DBNull.Value)
                            {
                                throw new DataException("Id is null");
                            }
                            serviceIds.Add(Convert.ToInt32(id));
                        }
                    }

                    if (serviceIds == null)
                    {
                        throw new DataException($"Service with plan: {planType} not found");
                    }
                    else
                    {
                        inService = string.Join(",", serviceIds.ToArray());
                    }
                    if (percent)
                    {
                        // update the percent coverage of the service
                        var updateService = "UPDATE Service " +
                                           $"SET PercentCoverage = {val} " +
                                           $"OUTPUT INSERTED.Id WHERE Id IN ({inService}) AND " +
                                           $"Name = @name;";
                        using (var cmd = new SqlCommand(updateService, this.Connection))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            updateId = (int)cmd.ExecuteScalar();
                        }
                    }
                    else if (max)
                    {
                        var updateService = "UPDATE Service " +
                                           $"SET InNetworkMax = {val} " +
                                           $"OUTPUT INSERTED.Id WHERE Id IN ({inService}) AND " +
                                           $"Name = @name;";
                        using (var cmd = new SqlCommand(updateService, this.Connection))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            updateId = (int)cmd.ExecuteScalar();
                        }
                    }
                    else
                    {
                        var updateService = "UPDATE Service " +
                                           $"SET RequiredCopayment = {val} " +
                                           $"OUTPUT INSERTED.Id WHERE Id IN ({inService}) AND " +
                                           $"Name = @name;";

                        using (var cmd = new SqlCommand(updateService, this.Connection))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            updateId = (int)cmd.ExecuteScalar();
                        }
                    } // else
                } // try
                finally
                {
                    this.Connection.Close();
                } // finally 

            } // else 

            return updateId;

            /* Da Faq dawg!!!  */
            //for (int i = 0; i < 2; i++)
            //{
            //    if (Plans[i].Id == planType)
            //    {
            //        if (category.Equals("Benefits"))
            //        {
            //            switch (name)
            //            {
            //                case "APD": Plans[i].APD = val;
            //                    break;
            //                case "PYMB": Plans[i].PYMB = val;
            //                    break;
            //                case "DependentFee": Plans[i].DependentFee = val;
            //                    break;
            //                case "PrimaryFee": Plans[i].PrimaryFee = val;
            //                    break;
            //                case "DependentChangeFee": Plans[i].DependentChangeFee = val;
            //                    break;
            //                case "PrimaryChangeFee": Plans[i].PrimaryChangeFee = val;
            //                    break;
            //                case "OPMFamily": Plans[i].OPMFamily = val;
            //                    break;
            //                case "OPMIndividual": Plans[i].OPMIndividual = val;
            //                    break;
            //                default:
            //                    break;
            //            }
            //        }
            //        else
            //        {
            //            for (int j = 0; j < Plans[i].ServiceCosts.Count(); j++)
            //            {
            //                Tuple<double, Service.MaxPayRate> temp = Plans[i].ServiceCosts[j].InNetMax;
            //                if (Plans[i].ServiceCosts[j].Name.Equals(name))
            //                {
            //                    if (percent == true)
            //                    {
            //                        Plans[i].ServiceCosts[j].PercentCoverage = val;
            //                    }
            //                    else if (max)
            //                    {
            //                        Plans[i].ServiceCosts[j].InNetMax = new Tuple<double, Service.MaxPayRate>(val, temp.Item2);
            //                    }
            //                    else
            //                    {
            //                        Plans[i].ServiceCosts[j].RequiredCopayment = val;
            //                    }
            //                }
            //            }
            //        }
            //    }

            //}


        }


        /// <summary>
        /// For now this is does nothing but it will eventually initialize the
        /// db. We use the singleton pattern for this 
        /// </summary>
        private DbMgr()
        {

            DependentEnrolleeSet = new HashSet<DependentEnrollee>();
            HspSet = new HashSet<HSP>();
            BillSet = new HashSet<Bill>();
            this.Connection = new SqlConnection();
            this.Connection.ConnectionString = @"Data Source =(localDB)\MSSQLLocalDB;
                                                 AttachDbFilename = |DataDirectory|\CougarHealth.mdf;
                                                 Integrated Security = True;
                                                 Connect Timeout = 30";
        }

        /// <summary>
        /// Method stub that will eventually save an enrollee from the database 
        /// if the enrollee already exists we throw a data exception
        /// </summary>
        /// <param name="enrollee"></param>
        public int? SaveEnrollee(Enrollee.Enrollee enrollee)
        {
            SqlCommand cmd = null;
            int? resultId = null;
            try
            {
                this.Connection.Open();
                string insertEnrollee;
                cmd = new SqlCommand();
                cmd.Connection = this.Connection;

                if (enrollee is PrimaryEnrollee)
                {
                    var toInsert = (PrimaryEnrollee)enrollee;
                    insertEnrollee = @"INSERT INTO dbo.PrimaryEnrollee
                                       (
                                           Email, 
                                           Pin, 
                                           SSN, 
                                           HomePhone, 
                                           MobilePhone, 
                                           FirstName,  
                                           LastName, 
                                           MailingAddr, 
                                           BillingAddr
                                       )
                                       VALUES 
                                       (
                                           @email, 
                                           @pin,
                                           @ssn, 
                                           @homephone,
                                           @mobilephone,
                                           @firstname,
                                           @lastname, 
                                           @mailingaddr,
                                           @billingaddr
                                       );
                                       SELECT CAST(scope_identity() AS int)";
                    cmd.CommandText = insertEnrollee;
                    // I parameterized all the attributes in the insert 
                    // statement to protect against SQL injection
                    cmd.Parameters.AddWithValue("@email", toInsert.Email);
                    cmd.Parameters.AddWithValue("@pin", toInsert.Pin);
                    cmd.Parameters.AddWithValue("@ssn", toInsert.SSN);
                    cmd.Parameters.AddWithValue("@homephone", toInsert.HomePhone);
                    cmd.Parameters.AddWithValue("@mobilephone", toInsert.MobilePhone);
                    cmd.Parameters.AddWithValue("@firstname", toInsert.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", toInsert.LastName);
                    cmd.Parameters.AddWithValue("@mailingaddr", toInsert.MailingAddr);
                    cmd.Parameters.AddWithValue("@billingaddr", toInsert.BillingAddr);
                    object lastId = cmd.ExecuteScalar();
                    if (lastId == DBNull.Value)
                    {
                        throw new DataException("I tried to insert your enrollee, but nothing got inserted");
                    }
                    resultId = Convert.ToInt32(lastId);
                }
                else
                {
                    // the enrollee is a dependent enrollee so we are saving it 
                    // into the dependent table 
                    var toInsert = (DependentEnrollee)enrollee;
                    insertEnrollee = @"INSERT INTO dbo.PrimaryEnrollee
                                       (
                                           Email, 
                                           Pin, 
                                           SSN, 
                                           RelationToPrimary,
                                           HomePhone, 
                                           MobilePhone, 
                                           FirstName,  
                                           LastName
                                       )
                                       VALUES 
                                       (
                                           @email, 
                                           @pin,
                                           @ssn, 
                                           @relation,
                                           @homephone,
                                           @mobilephone,
                                           @firstname,
                                           @lastname
                                       );
                                       SELECT CAST(scope_identity() AS int)";
                    cmd.Parameters.AddWithValue("@email", toInsert.Email);
                    cmd.Parameters.AddWithValue("@pin", toInsert.Pin);
                    cmd.Parameters.AddWithValue("@ssn", toInsert.SSN);
                    cmd.Parameters.AddWithValue("@relation", toInsert.Relationship);
                    cmd.Parameters.AddWithValue("@homephone", toInsert.HomePhone);
                    cmd.Parameters.AddWithValue("@mobilephone", toInsert.MobilePhone);
                    cmd.Parameters.AddWithValue("@firstname", toInsert.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", toInsert.LastName);
                    object lastId = cmd.ExecuteScalar();
                    if (lastId == DBNull.Value)
                    {
                        throw new DataException("I tried to insert your enrollee, but nothing got inserted");
                    }
                    resultId = Convert.ToInt32(lastId);
                }

            }
            finally
            {
                this.Connection.Close();
                cmd?.Dispose();
            }

            return resultId;
        }

        /// <summary>
        /// Save an enrollee plan into the database. If the EnrolleePlan is 
        /// already in the database we update it's entry 
        /// </summary>
        /// <param name="plan"></param>
        /// <returns>the PlanNum of the EnrolleePlan</returns>
        public int? SaveEnrolleePlan(EnrolleePlan plan)
        {
            int? planNum = null;
            try
            {
                // try to insert into database 
                this.Connection.Open();
                // first insert the EnrolleePlan
                var insertPlan = @"INSERT INTO EnrollePlan
                                   (
                                       APDRemainder, 
                                       OPMRemainder,
                                       PYMBRemainder, 
                                       TotalCost, 
                                       LastCharge, 
                                       InsurancePlanId
                                   )
                                   VALUES 
                                   (
                                       @apdRemainder, 
                                       @opmRemainder,
                                       @pymbRemainder,
                                       @totalCost, 
                                       @lastCharge,
                                       @insurancePlanId
                                   );";
                using (var planCmd = new SqlCommand(insertPlan, this.Connection))
                {
                    planCmd.Parameters.AddWithValue("@apdRemainder", plan.APDRemainder);
                    planCmd.Parameters.AddWithValue("@opmRemainder", plan.OPMFRemainder);
                    planCmd.Parameters.AddWithValue("@pymbRemainder", plan.PYMBRemainder);
                    planCmd.Parameters.AddWithValue("@totalCost", plan.TotalCost);
                    planCmd.Parameters.AddWithValue("@lastCharge", plan.LastChange);
                    planCmd.Parameters.AddWithValue("@insurancePlanId", plan.Plan.Id);
                    planNum = planCmd.CommandWithId();
                }

                // next create an PrimaryPlan entry 
                var insertPri = @"INSERT INTO PrimaryPlan 
                                 (
                                     PrimaryEnrolleeId, 
                                     EnrolleePlanId, 
                                     OPMIndividual
                                 )
                                 VALUES
                                 (
                                     @priId, 
                                     @planid,
                                     @opm
                                 );";
                using (var primaryCmd = new SqlCommand(insertPri, this.Connection))
                {
                    primaryCmd.Parameters.AddWithValue("@priId", plan.PrimaryEnrollee);
                    // retrieved from last insert 
                    primaryCmd.Parameters.AddWithValue("@planId", planNum);
                    primaryCmd.Parameters.AddWithValue("@opm", plan.OPMIRemainder);
                    primaryCmd.ExecuteNonQuery();
                }

                var insertDep = @"INSERT INTO DependentPlan 
                                  (
                                      DependentEnrolleeId, 
                                      EnrolleePlanId, 
                                      OPMIndividual
                                  ) 
                                  VALUES 
                                  (
                                      @enrolleeId, 
                                      @planId, 
                                      @opm
                                  );";
                using (var depCmd = new SqlCommand(insertDep))
                {
                    foreach (var dependent in plan.Dependents)
                    {
                        depCmd.Parameters.Clear();
                        depCmd.Parameters.AddWithValue("@enrolleeId", dependent);
                        depCmd.Parameters.AddWithValue("@planId", planNum);
                        depCmd.Parameters.AddWithValue("@opm", plan.OPMIRemainder);
                        depCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                var updateSql = @"UPDATE EnrolleePlan 
                                  SET  APDRemainder = @apd, 
                                       OPMRemainder = @opm,
                                       PYMBRemainder = @pymb, 
                                       TotalCost = @cost, 
                                       LastCharge = @charge, 
                                       InsurancePlanId = @plan
                                  WHERE PlanNum = @planNum
                                 ";

                using ( var cmd = new SqlCommand(updateSql, this.Connection) )
                {
                    cmd.Parameters.AddWithValue("@apd", plan.APDRemainder);
                    cmd.Parameters.AddWithValue("@opm", plan.OPMFRemainder);
                    cmd.Parameters.AddWithValue("@pymb", plan.PYMBRemainder);
                    cmd.Parameters.AddWithValue("@cost", plan.TotalCost);
                    cmd.Parameters.AddWithValue("@charge", plan.LastChange);
                    cmd.Parameters.AddWithValue("@plan", plan.Plan.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                this.Connection.Close();
            }

            return planNum;
        }

        /// <summary>
        /// Adds a new HSP object into the database if it doesn't already exist
        /// in the database. If the hsp object already exists in the database 
        /// then it'll throw a DataException
        /// </summary>
        /// <param name="hsp"></param>
        public void SaveHsp(HSP hsp)
        {
            //if (!HspSet.Add(hsp))
            //{
            //    throw new DataException("Hsp already exists in the database");
            //}

            var insertHsp = @"INSERT INTO HSP (
                                  RoutingNum, 
                                  AccountNum, 
                                  Pin,
                                  BankName,
                                  PersonelContact,
                                  Name,
                                  Address,
                                  IsInNetwork
                              ) 
                              VALUES (
                                  @RoutingNum,
                                  @AccountNum,
                                  @Pin,
                                  @BankName,
                                  @PersonelContact,
                                  @Name,
                                  @Address,
                                  @IsInNetwork
                              );";

            try
            {
                this.Connection.Open();
                int hspId = 0;
                // insert the hsp itself 
                using (var cmd = new SqlCommand(insertHsp, this.Connection))
                {
                    SqlTransaction transaction = this.Connection.BeginTransaction("test");
                    cmd.Parameters.AddWithValue("@Pin", hsp.Pin);
                    cmd.Transaction = transaction;
                    // add the optional columns 
                    if (hsp.BankName == null || hsp.RoutingNum == 0 || hsp.AccountNum == 0)
                    {
                        cmd.Parameters.AddWithValue("@BankName", DBNull.Value);
                        cmd.Parameters.AddWithValue("@RoutingNum", DBNull.Value);
                        cmd.Parameters.AddWithValue("@AccountNum", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@BankName", hsp.BankName);
                        cmd.Parameters.AddWithValue("@RoutingNum", hsp.RoutingNum);
                        cmd.Parameters.AddWithValue("@AccountNum", hsp.AccountNum);
                    }
                    cmd.Parameters.AddWithValue("@PersonelContact", hsp.Personnel);
                    cmd.Parameters.AddWithValue("@Name", hsp.Name);
                    cmd.Parameters.AddWithValue("@Address", hsp.Address);
                    cmd.Parameters.AddWithValue("@IsInNetwork", hsp.InNetwork);
                    hspId = cmd.CommandWithId();
                    hsp.Id = hspId;
                    transaction.Commit();
                }

                if (hspId != 0)
                {
                    var services = hsp.ServicesOffered.Select(s => "'" + s + "'");
                    var sqlServiceList = $"({string.Join(",", services.ToArray())})";
                    var selService = "SELECT Id FROM Service " +
                                    $"WHERE Name IN {sqlServiceList}";
                    var serviceIds = new List<int>();
                    using (var cmd = new SqlCommand(selService, this.Connection))
                    {
                        var rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            serviceIds.Add(Convert.ToInt32(rdr["Id"]));
                        }
                        rdr.Close();
                    }

                    var valuesList = serviceIds.Select(id =>
                    {
                        return "(" + id + ", " + hsp.Id + ")";
                    });
                    var attachService = "INSERT INTO ServiceHSP(ServiceId, HSPId) " +
                                       $"VALUES {string.Join(", ", valuesList.ToArray())}";
                    using (var cmd = new SqlCommand(attachService, this.Connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            finally
            {
                this.Connection.Close();
            }

        }

        /// <summary>
        /// grabs a hsp object by it's primary key 
        /// </summary>
        /// <param name="hspId"></param>
        /// <returns></returns>
        public HSP GrabHspById(int hspId)
        {
            HSP hsp = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                {
                    this.Connection.Open();
                }
                string pullHSP = @"SELECT * FROM HSP 
                                   WHERE Id = @id";
                using (var cmd = new SqlCommand(pullHSP, this.Connection))
                {
                    cmd.Parameters.AddWithValue("@id", hspId);
                    var rdr = cmd.ExecuteReader();
                    hsp = rdr.Single(h => new HSP(
                        id: Convert.ToInt32(h["Id"]),
                        routingNum: Convert.ToInt32(h["RoutingNum"]),
                        accountNum: Convert.ToInt32(h["AccountNum"]),
                        pin: Convert.ToString(h["Pin"]),
                        bankName: Convert.ToString(h["BankName"]),
                        personelContact: Convert.ToString(h["personelContact"]),
                        name: Convert.ToString(h["Name"]),
                        address: Convert.ToString(h["Address"]),
                        isInNetwork: Convert.ToBoolean(h["IsInNetwork"])
                    ));
                    rdr.Close();
                }

                if (hsp != null)
                {
                    this.AddHSPServices(hsp);
                }

            }
            finally
            {
                this.Connection.Close();
            }

            return hsp;
        }

        /// <summary>
        /// grabs a hsp object by it's uniquely identifiable name
        /// </summary>
        /// <param name="hspId"></param>
        /// <returns></returns>
        public HSP GrabHspByName(string hspName)
        {
            var selHsp = @"SELECT * FROM HSP WHERE Name = @name";
            HSP hsp = null;

            try
            {
                this.Connection.Open();

                using (var cmd = new SqlCommand(selHsp, this.Connection))
                {
                    cmd.Parameters.AddWithValue("@name", hspName);
                    var rdr = cmd.ExecuteReader();
                    hsp = rdr.Single(h => new HSP(
                        id: Convert.ToInt32(h["Id"]),
                        routingNum: Convert.ToInt32(h["RoutingNum"]),
                        accountNum: Convert.ToInt32(h["AccountNum"]),
                        pin: Convert.ToString(h["Pin"]),
                        bankName: Convert.ToString(h["BankName"]),
                        personelContact: Convert.ToString(h["PersonelContact"]),
                        name: Convert.ToString(h["Name"]),
                        address: Convert.ToString(h["Address"]),
                        isInNetwork: Convert.ToBoolean(h["IsInNetwork"])
                    ));

                    rdr.Close();
                }

                // time to grab the services 
                if (hsp != null)
                {
                    this.AddHSPServices(hsp);
                }
            }
            finally
            {
                this.Connection.Close();
            }

            return hsp;
            //return (from hsp in HspSet
            //        where hsp.Name == hspName
            //        select hsp).FirstOrDefault();
        }

        /// <summary>
        /// Attaches the list of services offered by the HSP 
        /// </summary>
        /// <param name="hsp"></param>
        private void AddHSPServices(HSP hsp)
        {
            if (this.Connection.State != ConnectionState.Open)
            {
                this.Connection.Open();
            }
            string pullServId = @"SELECT * 
                                  FROM ServiceHSP 
                                  WHERE HSPId = @hid";
            var sids = new List<int>();

            using (var cmd = new SqlCommand(pullServId, this.Connection))
            {
                cmd.Parameters.AddWithValue("@hid", hsp.Id);
                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    sids.Add(Convert.ToInt32(rdr["ServiceId"]));
                }

                rdr.Close();
            }

            string pullServices = @"SELECT Name FROM Service WHERE Id = @id";
            foreach (var sid in sids)
            {

                using (var cmd = new SqlCommand(pullServices, this.Connection))
                {
                    cmd.Parameters.AddWithValue("@id", sid);
                    var rdr = cmd.ExecuteReader();

                    // hsp could be null, so we want to make sure an 
                    //exception isn't thrown if that is the case.
                    hsp?.ServicesOffered.Add(rdr.Single(s => Convert.ToString(rdr["Name"])));
                    rdr.Close();
                }
            }
        }

        public Enrollee.InsurancePlan GetPlanByType(string type)
        {
            InsurancePlan plan = null;
            var services = new List<Service>();
            try
            {
                this.Connection.Open();
                var findPlan = @"SELECT TOP(1) * FROM InsurancePlan 
                                 WHERE Type = @type";
                using (var cmd = new SqlCommand(findPlan, this.Connection))
                {
                    cmd.Parameters.AddWithValue("@type", type);
                    var rdr = cmd.ExecuteReader();
                    plan = rdr.Single(p => new InsurancePlan()
                    {
                        Id = Convert.ToInt32(p["Id"]),
                        Type = Convert.ToString(p["Type"]),
                        Optional = Convert.ToBoolean(p["Optional"]),
                        PYMB = Convert.ToDouble(p["PYMB"]),
                        APD = Convert.ToDouble(p["APD"]),
                        OPMFamily = Convert.ToDouble(p["OPMFamily"]),
                        OPMIndividual = Convert.ToDouble(p["OPMIndividual"]),
                        PrimaryFee = Convert.ToDouble(p["PrimaryFee"]),
                        DependentFee = Convert.ToDouble(p["DependentFee"]),
                        PrimaryChangeFee = Convert.ToDouble(p["PrimaryChangeFee"]),
                        DependentChangeFee = Convert.ToDouble(p["DependentChangeFee"]),
                        ServiceCosts = new List<Service>()
                    });
                    rdr.Close();
                }
                if (plan != null)
                {
                    var pullServices = @"Select * FROM Service
                                        WHERE InsurancePlanId = @planId";
                    using (var cmd = new SqlCommand(pullServices, this.Connection))
                    {
                        cmd.Parameters.AddWithValue("@planId", plan.Id);
                        var rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            services.Add(new Service(
                                id: Convert.ToInt32(rdr["Id"]),
                                name: Convert.ToString(rdr["Name"]),
                                category: Convert.ToString(rdr["Category"]),
                                coverage: Convert.ToDouble(rdr["PercentCoverage"]),
                                maxPayRate: Convert.ToString(rdr["MaxPayRate"]),
                                inNetworkMax: Convert.ToDouble(rdr["InNetworkMax"]),
                                insurancePlan: Convert.ToInt32(rdr["InsurancePlanId"]),
                                reqCopay: Convert.ToDouble(rdr["RequiredCopayment"])
                                ));
                        }
                        rdr.Close();
                        plan.ServiceCosts = services;
                    }
                }
            }
            finally
            {
                this.Connection.Close();
            }
            return plan;
        }

        /// <summary>
        /// Output every plan in the Insurance Plan table into a list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InsurancePlan> GetPlans()
        {

            List<InsurancePlan> plans = new List<InsurancePlan>();
            try
            {
                this.Connection.Open();
                var findPlan = @"SELECT * FROM InsurancePlan";
                using (var cmd = new SqlCommand(findPlan, this.Connection))
                {
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var plan = new InsurancePlan
                        {
                            Id = Convert.ToInt32(rdr["Id"]),
                            Type = Convert.ToString(rdr["Type"]),
                            Optional = Convert.ToBoolean(rdr["Optional"]),
                            PYMB = Convert.ToDouble(rdr["PYMB"]),
                            APD = Convert.ToDouble(rdr["APD"]),
                            OPMFamily = Convert.ToDouble(rdr["OPMFamily"]),
                            OPMIndividual = Convert.ToDouble(rdr["OPMIndividual"]),
                            PrimaryFee = Convert.ToDouble(rdr["PrimaryFee"]),
                            DependentFee = Convert.ToDouble(rdr["DependentFee"]),
                            PrimaryChangeFee = Convert.ToDouble(rdr["PrimaryChangeFee"]),
                            DependentChangeFee = Convert.ToDouble(rdr["DependentChangeFee"])
                        };

                        plans.Add(plan);
                    }
                }
            }
            finally
            {
                this.Connection.Close();
            }
            return plans;
        }
        /// <summary>
        /// Find the enrollee with the matching email and password. If no 
        /// enrollee exists then the query will return 0 and in which case 
        /// we return null.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        public int? Login(string email, string pin)
        {
            int? returnId = null;
            try
            {
                this.Connection.Open();
                // select top to get the first enrollee with the email and pin combination
                string selEnrollee = @"SELECT TOP(1) * 
                                       FROM dbo.PrimaryEnrollee 
                                       WHERE Email = @email AND Pin = @pin;";
                using (var cmd = new SqlCommand(selEnrollee, this.Connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pin", pin);
                    var rdr = cmd.ExecuteReader();
                    // one result should come back, so no need for a while loop
                    if (rdr.Read())
                    {
                        returnId = Convert.ToInt32(rdr["Id"]);
                    }
                }
            }
            finally
            {
                this.Connection.Close();
            }
            return returnId;

        }


        /// <summary>
        /// get the primary enrollee object corresponding to the id provided
        /// </summary>
        /// <param name="primaryId"></param>
        /// <returns></returns>
        public PrimaryEnrollee FindPrimaryById(int primaryId)
        {
            string selEnrollee = "SELECT * " +
                                 "FROM dbo.PrimaryEnrollee " +
                                $"WHERE Id = { primaryId };";
            PrimaryEnrollee primary = null;

            try
            {
                this.Connection.Open();
                using (var cmd = new SqlCommand(selEnrollee, this.Connection))
                {
                    var rdr = cmd.ExecuteReader();
                    // I should only get one result back 
                    primary = rdr.Single(p => new PrimaryEnrollee(Convert.ToString(p["Pin"]))
                    {
                        Id = Convert.ToInt32(p["Id"]),
                        Email = Convert.ToString(p["Email"]),
                        SSN = Convert.ToString(p["SSN"]),
                        HomePhone = Convert.ToString(p["HomePhone"]),
                        MobilePhone = Convert.ToString(p["MobilePhone"]),
                        FirstName = Convert.ToString(p["FirstName"]),
                        LastName = Convert.ToString(p["LastName"]),
                        MailingAddr = Convert.ToString(p["MailingAddr"]),
                        BillingAddr = Convert.ToString(p["BillingAddr"])
                    });
                }
            }
            finally
            {
                // always close connection
                this.Connection.Close();
            }

            return primary;
        }

        /// <summary>
        /// Cache what is returned by a reader in the instantiation of the 
        /// EnrolleePlan so we can use the database method GetPlanById
        /// </summary>
        private struct CachedPlan
        {
            public object Plan;
            public int Pid;
            public object PlanNum;
            public object LastCharge;
            public object TotalCost;
            public object OpmRemainder;
            public object PymbRemainder;
            public object ApdRemainder;
        }

        /// <summary>
        /// Cache what is returned by a reader in the instantiation of the 
        /// Bill so we can use the database method GetServicesByPlan
        /// </summary>
        public struct CachedService
        {
            public object Id;
            public object Date;
            public object TotalBillAmount;
            public object EnrolleeBillAmount;
            public object ServiceId;
            public object PlanNum;
            public object HSPId;
            public object PrimaryId;
            public object DependentId;
            public object IsPrimary;
        }

        public DependentEnrollee FindDependentById(int primaryId)
        {
            return (from enrollee in DependentEnrolleeSet
                    where enrollee.Id == primaryId
                    select enrollee).FirstOrDefault();
        }

        /// <summary>
        /// Gets the EnrolleePlan objects for the primary enrollee corresponding
        /// to the given primary id 
        /// </summary>
        /// <param name="primaryId"></param>
        /// <returns></returns>
        public IEnumerable<EnrolleePlan> GetPlanByPrimary(int primaryId)
        {
            var plans = new List<EnrolleePlan>();
            try
            {
                this.Connection.Open();
                // select primary plan 
                var selPrimaryPlan = @"SELECT * 
                                       FROM PrimaryPlan AS pp
                                       WHERE pp.PrimaryEnrolleeId = @pid";
                List<int> epIds = new List<int>();
                using ( var cmd = new SqlCommand(selPrimaryPlan, this.Connection) )
                {
                    cmd.Parameters.AddWithValue("@pid", primaryId);
                    var rdr = cmd.ExecuteReader();
                    // there can be multiple plans per a primary 
                    while ( rdr.Read() )
                    {
                        epIds.Add(Convert.ToInt32(rdr["EnrolleePlanId"]));
                    }
                    rdr.Close();
                }
                // select the enrolleeplan
                var selEP = @"SELECT *  
                              FROM EnrolleePlan AS ep
                              WHERE ep.PlanNum = @epId";
                // zero is the default value for ints 
                if (epIds.Count() != 0)
                {
                    var cachedPlans = new List<CachedPlan>();
                    // Find the plan itself 
                    using (var cmd = new SqlCommand(selEP, this.Connection))
                    {
                        foreach ( int id in epIds )
                        {
                            cmd.Parameters.AddWithValue("@epId", id);
                            var rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                cachedPlans.Add(new CachedPlan
                                {
                                    Plan = rdr["InsurancePlanId"],
                                    Pid = primaryId,
                                    PlanNum = rdr["PlanNum"],
                                    LastCharge = rdr["LastCharge"],
                                    TotalCost = rdr["TotalCost"],
                                    OpmRemainder = rdr["OPMRemainder"],
                                    PymbRemainder = rdr["PYMBRemainder"],
                                    ApdRemainder = rdr["apdRemainder"],
                                });
                            } // while 
                            rdr.Close();
                        }
                    } // using 
                    foreach (var cachedPlan in cachedPlans)
                    {
                        InsurancePlan iplan = this.GetPLanById(Convert.ToInt32(cachedPlan.Plan));
                        plans.Add(new EnrolleePlan(
                                pid: cachedPlan.Pid,
                                plan: iplan,
                                planNum: Convert.ToInt32(cachedPlan.PlanNum),
                                lastCharge: Convert.ToDateTime(cachedPlan.LastCharge),
                                totalCost: Convert.ToDouble(cachedPlan.TotalCost),
                                opmRemainder: Convert.ToDouble(cachedPlan.OpmRemainder),
                                pymbRemainder: Convert.ToDouble(cachedPlan.PymbRemainder),
                                apdRemainder: Convert.ToDouble(cachedPlan.ApdRemainder)
                        )); // plans.Add 

                    }
                    if (this.Connection.State == ConnectionState.Closed)
                    {
                        // GetPlanById may clsoe the connection to the database 
                        this.Connection.Open();
                    }
                } // if 

                // get all dependents foreach plan 
                foreach (var plan in plans)
                {
                    this.AddPlanDependents(plan);
                } // foreach 

                // finally get all the bills 
                foreach (var plan in plans)
                {
                    this.AddPlanBills(plan);
                } // foreach  
            } // try
            finally
            {
                this.Connection.Close();
            } // finally 

            return plans;
            //return (from plan in PlanSet
            //        where plan.PrimaryEnrollee == primaryId
            //        select plan).FirstOrDefault();
        }

        /// <summary>
        /// Attach all the dependents of the plan (most likely retrieved from 
        /// the database) to EnrolleePlan object plan 
        /// </summary>
        /// <param name="plan"></param>
        private void AddPlanDependents(EnrolleePlan plan)
        {
            if (this.Connection.State != ConnectionState.Open)
            {
                this.Connection.Open();
            }
            var selDep = @"SELECT DependentEnrolleeId FROM DependentPlan
                           WHERE EnrolleePlanId = @pid";

            using (var cmd = new SqlCommand(selDep, this.Connection))
            {
                cmd.Parameters.AddWithValue("@pid", plan.PlanNum);
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    plan.Dependents.Add(Convert.ToInt32(rdr["DependentEnrolleeId"]));
                } // while 
                rdr.Close();
            } // using 
        } // attach dependents 

        /// <summary>
        /// Attach all the bills of the plan (most likely retrieved from 
        /// the database) to EnrolleePlan object plan 
        /// </summary>
        /// <param name="plan"></param>
        private void AddPlanBills(EnrolleePlan plan)
        {
            if (this.Connection.State != ConnectionState.Open)
            {
                this.Connection.Open();
            }
            var selBills = @"SELECT * FROM Bill WHERE PlanNum = @thisNum";
            var cachedServices = new List<CachedService>();

            using (var cmd = new SqlCommand(selBills, this.Connection))
            {
                cmd.Parameters.AddWithValue("@thisNum", plan.PlanNum);
                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cachedServices.Add(new CachedService
                    {
                        Id = rdr["Id"],
                        PrimaryId = rdr["PrimaryId"],
                        HSPId = rdr["HSPId"],
                        ServiceId = rdr["ServiceId"],
                        Date = rdr["Date"],
                        TotalBillAmount = rdr["TotalBillAmount"],
                        EnrolleeBillAmount = rdr["EnrolleeBillAmount"],
                        PlanNum = rdr["PlanNum"],
                        DependentId = rdr["DependentId"],
                        IsPrimary = rdr["IsPrimary"]
                    });
                } // while 
                rdr.Close();

            } // using 
            foreach (var serv in cachedServices)
            {

                HSP billingHSP = this.GrabHspById(Convert.ToInt32(serv.HSPId));
                IEnumerable<Service> services = this.GetServicesByPlan(plan.Type);
                Service billedService = services
                    .SingleOrDefault(s => s.Id == Convert.ToInt32(serv.ServiceId));

                int? enrollee = null;
                var isPrimary = Convert.ToBoolean(serv.IsPrimary);
                if (Convert.ToBoolean(serv.IsPrimary))
                {
                    enrollee = Convert.ToInt32(serv.PrimaryId);
                }
                else
                {
                    enrollee = Convert.ToInt32(serv.DependentId);
                }
                plan.Charges.Add(new Bill(
                    id: Convert.ToInt32(serv.Id),
                    date: Convert.ToDateTime(serv.Date),
                    hsp: billingHSP,
                    serviceId: billedService.Id,
                    enrolleeId: enrollee.Value,
                    isPrimary: isPrimary,
                    totalBillAmount: Convert.ToDouble(serv.TotalBillAmount),
                    enrolleeBillAmount: Convert.ToDouble(serv.EnrolleeBillAmount)

                )); // plan 
            } // using 
        } // bills 

        /// <summary>
        /// Gets the InsurancePlan object corresponding to this id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private InsurancePlan GetPLanById(int id)
        {
            var selPlan = "SELECT * FROM InsurancePlan WHERE Id = @id";
            InsurancePlan plan = null;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                {
                    this.Connection.Open();
                }

                using (var cmd = new SqlCommand(selPlan, this.Connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var rdr = cmd.ExecuteReader();
                    plan = rdr.Single(iplan => new InsurancePlan()
                    {
                        Id = Convert.ToInt32(iplan["id"]),
                        Type = Convert.ToString(iplan["Type"]),
                        Optional = Convert.ToBoolean(rdr["Optional"]),
                        PYMB = Convert.ToDouble(iplan["PYMB"]),
                        APD = Convert.ToDouble(iplan["APD"]),
                        OPMIndividual = Convert.ToDouble(iplan["OPMIndividual"]),
                        OPMFamily = Convert.ToDouble(iplan["OPMFamily"]),
                        PrimaryFee = Convert.ToDouble(iplan["PrimaryFee"]),
                        DependentFee = Convert.ToDouble(iplan["DependentFee"]),
                        PrimaryChangeFee = Convert.ToDouble(iplan["PrimaryChangeFee"]),
                        DependentChangeFee = Convert.ToDouble(iplan["DependentChangeFee"])
                    });
                }
            }
            finally
            {
                this.Connection.Close();
            }

            return plan;
        }

        //public void SaveEnrollee(Enrollee.Enrollee enrollee) { }

        /// <summary>
        /// Gets enrollee by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Enrollee.Enrollee GetEnrolleeByEmail(string email)
        {
            /*
             * look through both the primary enrollee table and the dependent 
             * enrollee table get back what are not duplicates. I added 0 as a 
             * constant "IsPrimary" column, so I can determine which results 
             * are primary or not 
             */
            string selEnrollee = @"SELECT Id, Email, Pin, SSN, HomePhone, MobilePhone, FirstName, LastName, 1 AS IsPrimary
                                   FROM PrimaryEnrollee 
                                   WHERE Email = @email
                                   UNION 
                                   SELECT Id, Email, Pin, SSN, HomePhone, MobilePhone, FirstName, LastName, 0 AS IsPrimary
                                   FROM DependentEnrollee
                                   WHERE Email = @email";
            Enrollee.Enrollee enrollee = null;

            try
            {
                this.Connection.Open();
                using (var cmd = new SqlCommand(selEnrollee, this.Connection))
                {
                    // command is parameterized to prevent SQL injection
                    cmd.Parameters.AddWithValue("@email", email);
                    var rdr = cmd.ExecuteReader();
                    // I should only get one result back 
                    if (rdr.Read())
                    {
                        if (Convert.ToBoolean(rdr["IsPrimary"]))
                        {
                            enrollee = new PrimaryEnrollee(Convert.ToString(rdr["Pin"]))
                            {
                                Id = Convert.ToInt32(rdr["Id"]),
                                Email = Convert.ToString(rdr["Email"]),
                                SSN = Convert.ToString(rdr["SSN"]),
                                HomePhone = Convert.ToString(rdr["HomePhone"]),
                                MobilePhone = Convert.ToString(rdr["MobilePhone"]),
                                FirstName = Convert.ToString(rdr["FirstName"]),
                                LastName = Convert.ToString(rdr["LastName"]),
                            }; // new 
                        } // if 
                        else
                        {

                            enrollee = new DependentEnrollee(Convert.ToString(rdr["Pin"]))
                            {
                                Id = Convert.ToInt32(rdr["Id"]),
                                Email = Convert.ToString(rdr["Email"]),
                                SSN = Convert.ToString(rdr["SSN"]),
                                HomePhone = Convert.ToString(rdr["HomePhone"]),
                                MobilePhone = Convert.ToString(rdr["MobilePhone"]),
                                FirstName = Convert.ToString(rdr["FirstName"]),
                                LastName = Convert.ToString(rdr["LastName"]),
                            }; // new 
                        } // else 
                    } // if 
                } // using 
            } // try 
            finally
            {
                // always close connection
                this.Connection.Close();
            }

            return enrollee;
        }

        /// <summary>
        /// Get an EnrolleePlan based on it's PlanNum
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public EnrolleePlan GetPolicyByID(int ID)
        {
            string selPlan = @"SELECT * FROM EnrolleePlan WHERE PlanNum = @id";
            EnrolleePlan plan = null;

            try
            {
                this.Connection.Open();
                CachedPlan cached;

                using (var cmd = new SqlCommand(selPlan, this.Connection))
                {
                    cmd.Parameters.AddWithValue("@id", ID);
                    var rdr = cmd.ExecuteReader();

                    // save response from database so that we can query for 
                    // insurance plan later in the method 
                    cached = rdr.Single(p => new CachedPlan()
                    {
                        // we don't actually have the primary yet so we set it 
                        // to an invalid Id
                        Pid = -1,
                        Plan = rdr["InsurancePlanID"],
                        PlanNum = rdr["PlanNum"],
                        LastCharge = rdr["LastCharge"],
                        TotalCost = rdr["TotalCost"],
                        OpmRemainder = rdr["OPMRemainder"],
                        PymbRemainder = rdr["PYMBRemainder"],
                        ApdRemainder = rdr["APDRemainder"]
                    });

                    rdr.Close();
                }

                // if we didn't get something back (the struct is zeroed out 
                // by default, so plan will be null in the default() case)
                if (cached.Plan == null)
                {
                    return null;
                }

                // get it's respective InsurancePlan
                InsurancePlan iplan = GetPLanById(Convert.ToInt32(cached.Plan));

                // reopen connection if iplan already closed it 
                if (this.Connection.State != ConnectionState.Open)
                {
                    this.Connection.Open();
                }

                var selPrimary = @"SELECT PrimaryEnrolleeId 
                                   FROM PrimaryPlan 
                                   WHERE EnrolleePlanId = @planNum";
                int pri = 0;

                using (var cmd = new SqlCommand(selPrimary, this.Connection))
                {
                    cmd.Parameters.AddWithValue("@planNum", ID);
                    var rdr = cmd.ExecuteReader();
                    pri = rdr.Single(p => Convert.ToInt32(p["PrimaryEnrolleeId"]));
                    rdr.Close();
                }

                // default value of pri is 0, so if we didn't get anything 
                // back then pri will be 0
                if (pri != 0)
                {
                    plan = new EnrolleePlan(
                        pid: pri,
                        plan: iplan,
                        lastCharge: Convert.ToDateTime(cached.LastCharge),
                        planNum: ID,
                        totalCost: Convert.ToDouble(cached.TotalCost),
                        opmRemainder: Convert.ToDouble(cached.OpmRemainder),
                        pymbRemainder: Convert.ToDouble(cached.PymbRemainder),
                        apdRemainder: Convert.ToDouble(cached.ApdRemainder)
                    );
                }

                // pull the user's dependents 
                this.AddPlanDependents(plan);
                this.AddPlanBills(plan);
            }
            finally
            {
                this.Connection.Close();
            }

            return plan;
        }

        /// <summary>
        /// Remove a plan from the InsurancePlan table, based on it's Type. 
        /// This method also removes all services in the Service Table, and all 
        /// enrolleplans that are based on this InsuracePlan 
        /// </summary>
        /// <param name="name"></param>
        public void RemovePlan(string name)
        {
            try
            {
                this.Connection.Open();
                var selId = "SELECT Id FROM InsurancePlan WHERE Type = @type";
                int? id = null;
                using (var selCmd = new SqlCommand(selId, this.Connection))
                {
                    selCmd.Parameters.AddWithValue("@type", name);
                    var rdr = selCmd.ExecuteReader();
                    id = rdr.Single(p => Convert.ToInt32(p["Id"]));
                    rdr.Close();
                }

                // services are foreign key dependents on InsurancePlan, so we 
                // must delete them before the Plan itself
                var deleteServices = $"DELETE FROM Service " +
                                     $"WHERE InsurancePlanId = {id.Value};";

                using (var servCmd = new SqlCommand(deleteServices, this.Connection))
                {
                    servCmd.ExecuteNonQuery();
                }

                // EnrolleePlan is another dependent on InsurancePlan so we 
                // need to delete it as well
                var deleteEPlan = "DELETE FROM EnrolleePlan " +
                                        $"WHERE InsurancePlanId = {id.Value};";
                using (var ePlanCmd = new SqlCommand(deleteEPlan, this.Connection))
                {
                    ePlanCmd.ExecuteNonQuery();
                }


                var deletePlan = "DELETE FROM InsurancePlan WHERE Type = @type";
                using (var planCmd = new SqlCommand(deletePlan, this.Connection))
                {
                    planCmd.Parameters.AddWithValue("@type", name);
                    planCmd.ExecuteNonQuery();
                }
            }
            finally
            {
                this.Connection.Close();
            }
        }
        /// <summary>
        /// Search for the user name and password of the employee 
        /// provided through the database
        /// </summary>
        /// <param name="checkEmployee">The employee encapsulating the info we are searching for</param>
        /// <returns>The employee match (could be null)</returns>
        public Employee EmployeeLogin(Employee checkEmployee)
        {
            // it is the job of the client of DbMgr to hash the password sent
            var employeeResult = (from employee in EmployeeSet
                                  where checkEmployee.UserName == employee.UserName &&
                                        checkEmployee.Password == employee.Password
                                  select employee)?.FirstOrDefault();
            return employeeResult;
        }



        public Service GetServiceById (int id)
        {
            var service = new Service();
            service = null;

            try
            {
                if (this.Connection.State == ConnectionState.Closed )
                {
                    this.Connection.Open();
                }
                var pullService = @"SELECT Id, PercentCoverage, Category, Name, MaxPayRate, InNetworkMax, InsurancePlanId, RequiredCopayment
                                    FROM Service 
                                    WHERE Id = @id";

                using (var cmd = new SqlCommand(pullService, this.Connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var rdr = cmd.ExecuteReader();

                    if ( rdr.Read() )
                    {
                        service = new Service(
                            id: Convert.ToInt32(rdr["Id"]),
                            name: Convert.ToString(rdr["Name"]),
                            category: Convert.ToString(rdr["Category"]),
                            coverage: Convert.ToDouble(rdr["PercentCoverage"]),
                            maxPayRate: Convert.ToString(rdr["MaxPayRate"]),
                            inNetworkMax: Convert.ToDouble(rdr["InNetworkMax"]),
                            insurancePlan: Convert.ToInt32(rdr["InsurancePlanId"]),
                            reqCopay: Convert.ToDouble(rdr["RequiredCopayment"])
                            );
                    }
                    rdr.Close();
                }
            }
            finally
            {
                this.Connection.Close();
            }
            return service;
        }




        /// <summary>
        /// Get all the services attached to the InsurancePlan table entry 
        /// corresponding to the given type 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<Service> GetServicesByPlan(string type)
        {
            var services = new List<Service>();
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                {
                    this.Connection.Open();
                }
                var pullService = @"SELECT s.* FROM Service AS s 
                                    INNER JOIN InsurancePlan AS i 
                                        ON i.Type = @type
                                    WHERE i.Id = s.InsurancePlanId";
                using (var cmd = new SqlCommand(pullService, this.Connection))
                {
                    cmd.Parameters.AddWithValue("@type", type);
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        services.Add(new Service(
                            id: Convert.ToInt32(rdr["Id"]),
                            name: Convert.ToString(rdr["Name"]),
                            category: Convert.ToString(rdr["Category"]),
                            coverage: Convert.ToDouble(rdr["PercentCoverage"]),
                            maxPayRate: Convert.ToString(rdr["MaxPayRate"]),
                            inNetworkMax: Convert.ToDouble(rdr["InNetworkMax"]),
                            insurancePlan: Convert.ToInt32(rdr["InsurancePlanId"]),
                            reqCopay: Convert.ToDouble(rdr["RequiredCopayment"])
                        ));
                    }
                    rdr.Close();
                }
            }
            finally
            {
                this.Connection.Close();
            }

            return services;
        } // get services 


        //This Method was developed By Phil Atkins
        //It's purpose is to return a list of all HSPs that match 
        //The given service. It returns null for anything that isn't 
        //A valid service
        public IEnumerable<HSP> GetProviders(Service service)
        {

            List<HSP> providers = null;

            if (service != null)
            {
                try
                {
                    if (this.Connection.State == ConnectionState.Closed)
                    {
                        this.Connection.Open();
                    }
                    var pullHSP = @"Select * FROM HSP AS HSP
                                INNER JOIN ServiceHSP AS SHSP
                                    ON SHSP.ServiceID = @serviceID
                                WHERE SHSP.HSPId = HSP.Id";
                    using (var cmd = new SqlCommand(pullHSP, this.Connection))
                    {
                        cmd.Parameters.AddWithValue("@serviceID", service.Id);
                        var rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            providers = new List<HSP>();

                            providers.Add(new HSP(
                                id: Convert.ToInt32(rdr["Id"]),
                                routingNum: Convert.ToInt32(rdr["RoutingNum"]),
                                accountNum: Convert.ToInt32(rdr["AccountNum"]),
                                pin: Convert.ToString(rdr["Pin"]),
                                bankName: Convert.ToString(rdr["BankName"]),
                                personelContact: Convert.ToString(rdr["PersonelContact"]),
                                name: Convert.ToString(rdr["Name"]),
                                address: Convert.ToString(rdr["Address"]),
                                isInNetwork: Convert.ToBoolean(rdr["IsInNetwork"])
                                ));
                        }
                    }
                }
                finally
                {
                    this.Connection.Close();
                }
                return providers;
            }
            return providers;
        }
        public void AddPlan(InsurancePlan plan)
        {
            int result;
            try
            {
                this.Connection.Open();

                var addPlan = @"INSERT INTO InsurancePlan (Type, Optional, PYMB, APD, OPMIndividual, OPMFamily, PrimaryFee, DependentFee, PrimaryChangeFee, DependentChangeFee)
                                                   VALUES (@type, @optional, @PYMB, @APD, @OPMI, @OPMF, @PrimaryFee, @DependentFee, @PrimaryChangeFee, @DependentChangeFee);";
                var addService = @"INSERT INTO Service (PercentCoverage, Category, Name, MaxPayRate, InNetworkMax, InsurancePlanId, RequiredCopayment)
                                                VALUES (@percent, @category, @name, @maxRate, @inNet, @planId, @copay);";

                using (var addPlanCmd = new SqlCommand(addPlan, this.Connection))
                {
                    addPlanCmd.Parameters.AddWithValue("@type", plan.Type);
                    addPlanCmd.Parameters.AddWithValue("@optional", plan.Optional);
                    addPlanCmd.Parameters.AddWithValue("@PYMB", plan.PYMB);
                    addPlanCmd.Parameters.AddWithValue("@APD", plan.APD);
                    addPlanCmd.Parameters.AddWithValue("@OPMI", plan.OPMIndividual);
                    addPlanCmd.Parameters.AddWithValue("@OPMF", plan.OPMFamily);
                    addPlanCmd.Parameters.AddWithValue("@PrimaryFee", plan.PrimaryFee);
                    addPlanCmd.Parameters.AddWithValue("@DependentFee", plan.DependentFee);
                    addPlanCmd.Parameters.AddWithValue("@PrimaryChangeFee", plan.PrimaryChangeFee);
                    addPlanCmd.Parameters.AddWithValue("@DependentChangeFee", plan.DependentChangeFee);

                    result = addPlanCmd.CommandWithId();

                    
                }
                int serviceVal;
                foreach(var service in plan.ServiceCosts)
                {
                    using (var addServiceCmd = new SqlCommand(addService, this.Connection))
                    {
                        addServiceCmd.Parameters.AddWithValue("@percent", service.PercentCoverage);
                        addServiceCmd.Parameters.AddWithValue("@category", service.Category);
                        addServiceCmd.Parameters.AddWithValue("@name", service.Name);
                        addServiceCmd.Parameters.AddWithValue("@maxRate", Enum.GetName(typeof(Service.MaxPayRate), service.InNetMax.Item2).ToString());
                        addServiceCmd.Parameters.AddWithValue("@inNet", service.InNetMax.Item1);
                        addServiceCmd.Parameters.AddWithValue("@planId", result);
                        addServiceCmd.Parameters.AddWithValue("@copay", service.RequiredCopayment);

                        serviceVal = addServiceCmd.CommandWithId();
                    }
                }
            }
            finally
            {
                this.Connection.Close();
            }
        }

        public void AddService(Service service)
        {
            var addService = @"INSERT INTO Service (PercentCoverage, Category, Name, MaxPayRate, InNetworkMax, InsurancePlanId, RequiredCopayment)
                                                VALUES (@percent, @category, @name, @maxRate, @inNet, @planId, @copay);";

            try
            {
                this.Connection.Open();

                int serviceVal;
                using (var addServiceCmd = new SqlCommand(addService, this.Connection))
                {
                    addServiceCmd.Parameters.AddWithValue("@percent", service.PercentCoverage);
                    addServiceCmd.Parameters.AddWithValue("@category", service.Category);
                    addServiceCmd.Parameters.AddWithValue("@name", service.Name);
                    addServiceCmd.Parameters.AddWithValue("@maxRate", Enum.GetName(typeof(Service.MaxPayRate), service.InNetMax.Item2).ToString());
                    addServiceCmd.Parameters.AddWithValue("@inNet", service.InNetMax.Item1);
                    addServiceCmd.Parameters.AddWithValue("@planId", service.insurancePlanId);
                    addServiceCmd.Parameters.AddWithValue("@copay", service.RequiredCopayment);

                    serviceVal = addServiceCmd.CommandWithId();
                }


            }
            finally
            {
                this.Connection.Close();
            }
        }

        public void RemoveService(Service service)
        {
            try
            {
                this.Connection.Open();
                var deleteServices = $"DELETE FROM Service " +
                                     $"WHERE InsurancePlanId = {service.Id};";

                using (var servCmd = new SqlCommand(deleteServices, this.Connection))
                {
                    servCmd.ExecuteNonQuery();
                }
            }
            finally
            {
                this.Connection.Close();
            }
        }

    }
}
