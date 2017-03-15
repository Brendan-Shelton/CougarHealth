using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.HealthcareServiceProvider
{
    public class HSP
    {
        //Todo: 

        /// <summary>
        /// Required fields
        /// </summary>
        public String Name { get; set; }
        public List<String> ServicesOffered { get; set; }
        public List<String> personnel { get; set; } 
        public String Address { get; set; }

        /// <summary>
        /// Optional fields
        /// </summary>
        public String BankName { get; set; }
        public int AccountNum { get; set; }
        public int RoutingNum { get; set; }

        /// <summary>
        /// Unique to each HSP/OHSP
        /// </summary>
        public int Id { get; }

    }
}
