﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>C:\Users\michael\Documents\Engineering\CS325_CP\CoreProject\CoreProject\Program.cs
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CougarHealth());
        }
    }
}
