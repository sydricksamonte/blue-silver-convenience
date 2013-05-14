using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
namespace Payroll_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process Proc = System.Diagnostics.Process.GetCurrentProcess();
            Process[] AllProc = System.Diagnostics.Process.GetProcessesByName(Proc.ProcessName);

            if (AllProc.Length > 1)
            {
                MessageBox.Show("Program is already running!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                   // Application.Run(new Voids("a"));
            }
        }
    }
}