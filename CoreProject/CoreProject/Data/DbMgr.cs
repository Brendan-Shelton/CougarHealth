using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data
{
    class DbMgr
    {
        private static DbMgr _instance;
        /// <summary>
        /// get the single instance of DbMgr allowed in the application
        /// 
        /// a bit about the C# magic: this is a static readonly property of 
        /// DbMgr class. The arrow is a lambda express (think of a one line 
        /// function) that returns the private _instance static field if it 
        /// is not null (that is what the '??' operator is for). If it is null
        /// it instantiates the _instance field and then returns it 
        /// </summary>
        public static DbMgr Instance => _instance ?? (_instance = new DbMgr());

        /// <summary>
        /// For now this is does nothing but it will eventually initialize the
        /// db. We use the singleton pattern for this 
        /// </summary>
        private DbMgr()
        {
            
        }

        /// <summary>
        /// Method stub that will eventually retrieve an enrollee from the database 
        /// </summary>
        /// <param name="enrollee"></param>
        public void SaveEnrollee(Enrollee.Enrollee enrollee) { }
    }
}
