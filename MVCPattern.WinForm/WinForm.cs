using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MVCPattern.Model;
using System.Reflection;
using System.Threading;

namespace MVCPattern.WinForm
{
    public static class WinForm
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            StartKMteller();
            StartConsole();
            Start();
        }

        public static void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
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

        private delegate void kmTellerStart();
        static void StartKMteller()
        {
            Assembly assembly = Assembly.LoadFrom("MVCPattern.KMTeller.exe");
            Type type = assembly.GetType("MVCPattern.KMTeller.Program");
            MethodInfo winFormMethod = type.GetMethod("Start");
            kmTellerStart kmTellerStart = (kmTellerStart)winFormMethod.CreateDelegate(typeof(kmTellerStart));
            Thread winThread = new Thread(() => kmTellerStart());
            winThread.Start();
        }
    }
}
