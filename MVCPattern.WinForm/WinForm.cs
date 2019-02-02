using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MVCPattern.Model;
using System.Reflection;
using System.Threading;
using MVCPattern.Interfaces;

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
            ApplicationThread applicationThread = new ApplicationThread();
            StartKMteller(applicationThread);
            StartConsole(applicationThread);
            Start(applicationThread);
        }

        public static void Start(ApplicationThread applicationThread)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            form.ApplicationThread = applicationThread;
            Application.Run(form);
        }

        private delegate void consoleStart(ApplicationThread applicationThread);
        static void StartConsole(ApplicationThread applicationThread)
        {
            Assembly assembly = Assembly.LoadFrom("MVCPattern.Console.exe");
            Type type = assembly.GetType("MVCPattern.Console.Console");
            MethodInfo consoleMethod = type.GetMethod("Start");
            consoleStart consoleStart = (consoleStart)consoleMethod.CreateDelegate(typeof(consoleStart));
            Thread consoleThread = new Thread(() => consoleStart(applicationThread));
            consoleThread.Start();
        }

        private delegate void kmTellerStart(ApplicationThread applicationThread);
        static void StartKMteller(ApplicationThread applicationThread)
        {
            Assembly assembly = Assembly.LoadFrom("MVCPattern.KMTeller.exe");
            Type type = assembly.GetType("MVCPattern.KMTeller.Program");
            MethodInfo winFormMethod = type.GetMethod("Start");
            kmTellerStart kmTellerStart = (kmTellerStart)winFormMethod.CreateDelegate(typeof(kmTellerStart));
            Thread winThread = new Thread(() => kmTellerStart(applicationThread));
            winThread.Start();
        }
    }
}
