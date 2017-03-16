using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreProject.Controller.HSPControllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Controller.HSPControllers.Tests
{
    [TestClass()]
    public class CreateHSPControllerTests
    {
        private CreateHSPController _ctrl = new CreateHSPController();
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateHSPBadArgumentTest()
        {

            _ctrl.CreateHSP(
                name: "Dude",
                services: new List<string>()
                {
                    "dude",
                    "mcguy"
                },
                address: "805 N Ealy",
                phone: "342124",
                pin: "1023",
                netowrkStatus: true,
                info: null
            );
        }

        [TestMethod()]
        [ExpectedException(typeof(DataException))]
        public void CreateHSPDuplicateTest()
        {
            _ctrl.CreateHSP(
                name: "Dude",
                services: new List<string>
                {
                    "dude",
                    "mcguy"
                },
                address: "805 N Ealy",
                phone: "(217) 821-4819",
                pin: "1023",
                netowrkStatus: true,
                info: null
            );

            _ctrl.CreateHSP(
                name: "Dude",
                services: new List<string>
                {
                    "dude",
                    "mcguy"
                },
                address: "805 N Ealy",
                phone: "(217) 821-4819",
                pin: "1023",
                netowrkStatus: true,
                info: null
            );
        }
    }
}