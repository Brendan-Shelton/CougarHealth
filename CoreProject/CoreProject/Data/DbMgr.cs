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
                throw new DataException("I tried to insert your enrollee, but nothing got inserted");
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

        public HashSet<DependentEnrollee> DependentEnrolleSet { get; set; }

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
            BillSet.Add(bill);

        }
        public Bill[] getBillsById(int id)
        {
            //from Bill in BillSet
            //       where Bill.enrolleeId == id
            //       select Bill);

            // var bill = from Bill in BillSet where Bill.enrolleeId == id select Bill;
            var bills = new Bill[BillSet.Count];
            int billCount = 0;
            var enumerator = BillSet.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.enrolleeId == id)
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
        /// Saves an entire employee object into the database. If the employee 
        /// was already inserted it throws a DataException
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int SaveEmployee(Employee employee)
        {

            if (!EmployeeSet.Add(employee))
            {
                throw new DataException($"{employee.UserName} was already in our system");
            }

            return employee.Id;
        }
        /// <summary>
        /// Basically SELECT * FROM Employee
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetAllEmployees()
        {
            return EmployeeSet;
        }
        /// <summary>
        /// Update the employee that corresponds to the id of the employee 
        /// supplied to the method 
        /// </summary>
        /// <param name="emp">The new credentials of the employee </param>
        /// <returns></returns>
        public int UpdateEmployee(Employee emp)
        {
            var toUpdate = (from employee in EmployeeSet
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
            toUpdate.Permission = emp.Permission;
            return toUpdate.Id;
        }

        /// <summary>
        /// Get an employee object corresponding to the provided username
        /// </summary>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public Employee GetEmployeeByName(string employeeName)
        {
            return (from employee in EmployeeSet
                    where employee.UserName == employeeName
                    select employee)?.FirstOrDefault();
        }

        public Employee GetEmployeeById(int id)
        {
            var result = (from employee in EmployeeSet
                          where employee.Id == id
                          select employee)?.FirstOrDefault();

            return result;
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
                                @"WHERE Type = @type";
                try
                {
                    this.Connection.Open();
                    using (var cmd = new SqlCommand(updatePlan, this.Connection))
                    {
                        cmd.Parameters.AddWithValue("@type", planType);
                        updateId = cmd.CommandWithId();
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
                                           $"WHERE Id IN ({inService}) AND " +
                                           $"Name = @name;";
                        using (var cmd = new SqlCommand(updateService, this.Connection))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            updateId = cmd.CommandWithId();
                        }
                    }
                    else if (max)
                    {
                        var updateService = "UPDATE Service " +
                                           $"SET InNetworkMax = {val} " +
                                           $"WHERE Id IN ({inService}) AND " +
                                           $"Name = @name;";
                        using (var cmd = new SqlCommand(updateService, this.Connection))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            updateId = cmd.CommandWithId();
                        }
                    }
                    else
                    {
                        var updateService = "UPDATE Service " +
                                           $"SET RequiredCopayment = {val} " +
                                           $"WHERE Id IN ({inService}) AND " +
                                           $"Name = @name;";

                        using (var cmd = new SqlCommand(updateService, this.Connection))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            updateId = cmd.CommandWithId();
                        }
                    } // else
                } // try
                finally
                {
                    this.Connection.Close();
                } // finally 

            } // else 

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

            return updateId;
        }


        /// <summary>
        /// For now this is does nothing but it will eventually initialize the
        /// db. We use the singleton pattern for this 
        /// </summary>
        private DbMgr()
        {

            DependentEnrolleSet = new HashSet<DependentEnrollee>();
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
                // I need to update the enrollee Plan 

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
            if (!HspSet.Add(hsp))
            {
                throw new DataException("Hsp already exists in the database");
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
                if ( this.Connection.State != ConnectionState.Open )
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

                string pullServId = @"SELECT * 
                                      FROM ServiceHSP 
                                      WHERE HSPId = @hid";
                var sids = new List<int>();

                using ( var cmd = new SqlCommand(pullServId, this.Connection) )
                {
                    cmd.Parameters.AddWithValue("@hid", hspId);
                    var rdr = cmd.ExecuteReader();
                    
                    while (rdr.Read())
                    {
                        sids.Add(Convert.ToInt32(rdr["ServiceId"]));
                    }

                    rdr.Close();
                }

                string pullServices = @"SELECT Name FROM Service WHERE Id = @id";
                foreach( var sid in sids )
                {

                    using ( var cmd = new SqlCommand(pullServices, this.Connection) )
                    {
                        cmd.Parameters.AddWithValue("@id", sid);
                        var rdr = cmd.ExecuteReader();

                        // hsp could be null, so we want to make sure an 
                        //exception isn't thrown if that is the case.
                        hsp?.ServicesOffered.Add(rdr.Single(s => Convert.ToString(rdr["Name"])));
                    }
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
            return (from hsp in HspSet
                    where hsp.Name == hspName
                    select hsp).FirstOrDefault();
        }

        public Enrollee.InsurancePlan GetPlanByType(string type)
        {
            InsurancePlan plan = null;
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
                        PYMB = Convert.ToDouble(p["PYMB"]),
                        APD = Convert.ToDouble(p["APD"]),
                        OPMFamily = Convert.ToDouble(p["OPMFamily"]),
                        OPMIndividual = Convert.ToDouble(p["OPMIndividual"]),
                        PrimaryFee = Convert.ToDouble(p["PrimaryFee"]),
                        DependentFee = Convert.ToDouble(p["DependentFee"]),
                        PrimaryChangeFee = Convert.ToDouble(p["PrimaryChangeFee"]),
                        DependentChangeFee = Convert.ToDouble(p["DependentChangeFee"])
                    });
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
            public object plan;
            public int pid;
            public object planNum;
            public object lastCharge;
            public object totalCost;
            public object opmRemainder;
            public object pymbRemainder;
            public object apdRemainder;

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
                int? epId = null;
                using ( var cmd = new SqlCommand(selPrimaryPlan, this.Connection) )
                {
                    cmd.Parameters.AddWithValue("@pid", primaryId);
                    var rdr = cmd.ExecuteReader();
                    epId = rdr.Single(ep => Convert.ToInt32(ep["EnrolleePlanId"]));
                    rdr.Close();
                }
                // select the enrolleeplan
                var selEP = @"SELECT *  
                              FROM EnrolleePlan AS ep
                              WHERE ep.PlanNum = @epId";
                // zero is the default value for ints 
                if (epId != 0)
                {
                    var cachedPlans = new List<CachedPlan>();
                    // Find the plan itself 
                    using (var cmd = new SqlCommand(selEP, this.Connection))
                    {
                        cmd.Parameters.AddWithValue("@epId", epId);
                        var rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            cachedPlans.Add(new CachedPlan
                            {
                                plan = rdr["InsurancePlanId"],
                                pid = primaryId,
                                planNum = rdr["PlanNum"],
                                lastCharge = rdr["LastCharge"],
                                totalCost = rdr["TotalCost"],
                                opmRemainder = rdr["OPMRemainder"],
                                pymbRemainder = rdr["PYMBRemainder"],
                                apdRemainder = rdr["apdRemainder"],
                            });
                        } // while 
                        rdr.Close();
                    } // using 
                    foreach (var cachedPlan in cachedPlans)
                    {
                        InsurancePlan iplan = this.GetPLanById(Convert.ToInt32(cachedPlan.plan));
                        plans.Add(new EnrolleePlan(
                                pid: cachedPlan.pid,
                                plan: iplan,
                                planNum: Convert.ToInt32(cachedPlan.planNum),
                                lastCharge: Convert.ToDateTime(cachedPlan.lastCharge),
                                totalCost: Convert.ToDouble(cachedPlan.totalCost),
                                opmRemainder: Convert.ToDouble(cachedPlan.opmRemainder),
                                pymbRemainder: Convert.ToDouble(cachedPlan.pymbRemainder),
                                apdRemainder: Convert.ToDouble(cachedPlan.apdRemainder)
                        )); // plans.Add 

                    }
                    if ( this.Connection.State == ConnectionState.Closed )
                    {
                        // GetPlanById may clsoe the connection to the database 
                        this.Connection.Open();
                    }
                } // if 

                // get all dependents foreach plan 
                foreach ( var plan in plans )
                {
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
                } // foreach 

                // finally get all the bills 
                foreach ( var plan in plans )
                {
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
                    foreach ( var serv in cachedServices )
                    {

                        HSP billingHSP = this.GrabHspById(Convert.ToInt32(serv.HSPId));
                        IEnumerable<Service> services = this.GetServicesByPlan(plan.Type);
                        Service billedService = services.Where(s => 
                        {
                            return s.Id == Convert.ToInt32(serv.ServiceId);
                        }).SingleOrDefault();

                        int? enrollee = null;
                        var isPrimary = Convert.ToBoolean(serv.IsPrimary);
                        if ( Convert.ToBoolean(serv.IsPrimary) )
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
                            service: billedService,
                            enrolleeId: enrollee.Value,
                            isPrimary: isPrimary,
                            totalBillAmount: Convert.ToDouble(serv.TotalBillAmount),
                            enrolleeBillAmount: Convert.ToDouble(serv.EnrolleeBillAmount)

                        )); // plan 
                        }
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
                if ( this.Connection.State == ConnectionState.Closed)
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
            // look through both the primary enrollee table and the dependent 
            // enrollee table get back what are not duplicates 
            string selEnrollee = @"SELECT Id, Email, Pin, SSN, HomePhone, MobilePhone, FirstName, LastName
                                   FROM PrimaryEnrollee 
                                   WHERE Email = @email
                                   UNION 
                                   SELECT Id, Email, Pin, SSN, HomePhone, MobilePhone, FirstName, LastName 
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
                    enrollee = rdr.Single(p => new Enrollee.Enrollee(Convert.ToString(p["Pin"]))
                    {
                        Id = Convert.ToInt32(p["Id"]),
                        Email = Convert.ToString(p["Email"]),
                        SSN = Convert.ToString(p["SSN"]),
                        HomePhone = Convert.ToString(p["HomePhone"]),
                        MobilePhone = Convert.ToString(p["MobilePhone"]),
                        FirstName = Convert.ToString(p["FirstName"]),
                        LastName = Convert.ToString(p["LastName"]),
                    });
                }
            }
            finally
            {
                // always close connection
                this.Connection.Close();
            }

            return enrollee;
        }

        public Enrollee.EnrolleePlan GetPolicyByID(int ID)
        {
            throw new NotImplementedException();
            //return (from plan in PlanSet
            //var r = (from plan in PlanSet
            //         where plan.PlanNum == ID
            //         select plan).FirstOrDefault();
            //return r;
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


        public IEnumerable<Service> GetServicesByPlan ( string type )
        {
            var services = new List<Service>();
            try
            {
                if ( this.Connection.State == ConnectionState.Closed )
                {
                    this.Connection.Open();
                }
                var pullService = @"SELECT s.* FROM Service AS s 
                                    INNER JOIN InsurancePlan AS i 
                                        ON i.Type = @type
                                    WHERE i.Id = s.InsurancePlanId";
                using ( var cmd = new SqlCommand(pullService, this.Connection) )
                {
                    cmd.Parameters.AddWithValue("@type", type);
                    var rdr = cmd.ExecuteReader();

                    while ( rdr.Read() )
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
                }
            }
            finally
            {
                this.Connection.Close();
            }

            return services;
        }

    }
}
