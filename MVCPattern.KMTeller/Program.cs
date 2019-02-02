using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVCPattern.KMTeller
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StartConsole();
            StartWinForm();
            Start();
        }

        public static void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private delegate void winFormStart();
        static void StartWinForm()
        {
            Assembly assembly = Assembly.LoadFrom("MVCPattern.WinForm.exe");
            Type type = assembly.GetType("MVCPattern.WinForm.WinForm");
            MethodInfo winFormMethod = type.GetMethod("Start");
            winFormStart winFormStart = (winFormStart)winFormMethod.CreateDelegate(typeof(winFormStart));
            Thread winThread = new Thread(() => winFormStart());
            winThread.Start();
        }

        private delegate void consoleStart();
        static void StartConsole()
        {
            Assembly assembly = Assembly.LoadFrom("MVCPattern.Console.exe");
            Type type = assembly.GetType("MVCPattern.Console.Console");
            MethodInfo consoleMethod = type.GetMethod("Start");
            consoleStart consoleStart = (consoleStart)consoleMethod.CreateDelegate(typeof(consoleStart));
            Thread consoleThread = new Thread(() => consoleStart());
            consoleThread.Start();
        }
    }
}
