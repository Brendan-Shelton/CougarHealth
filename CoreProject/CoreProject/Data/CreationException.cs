using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.Employees
{
    /// <summary>
    /// Exception explaining what went wrong in the creation of the 
    /// employee. This is to decouple the view from the controller. This 
    /// acts as a container for all the info that would be present in a 
    /// infobox
    /// </summary>
    public class CreationException : Exception
    {
        /// <summary>
        /// How to solve the exception
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// What was the cause of the exception
        /// </summary>
        public List<string> Reasons { get; set; }
        public bool IsProblem { get; private set; }

        public CreationException()
            : base()
        {
            this.Reasons = new List<string>();
        }

        /// <summary>
        /// There was a problem in the creation of the employee... This 
        /// defines a message - which will be the header of the messagebox
        /// in the view - and a description - which will be the caption of 
        /// the messagebox 
        /// </summary>
        /// <param name="reason">Message box header</param>
        /// <param name="description">Message box caption</param>
        public CreationException(string reason, string description)
            : base("Cannot create account.")
        {
            this.Description = description;
            this.Reasons = new List<string> { reason };
        }

        public void AddError(string reason, string description)
        {
            IsProblem = true;
            this.Description += " " + description;
            this.Reasons.Add(reason);
        }
    }
}
