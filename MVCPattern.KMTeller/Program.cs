using MVCPattern.Interfaces;
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
            ApplicationThread applicationThread = new ApplicationThread();
            StartConsole(applicationThread);
            StartWinForm(applicationThread);
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

        private delegate void winFormStart(ApplicationThread applicationThread);
        static void StartWinForm(ApplicationThread applicationThread)
        {
            Assembly assembly = Assembly.LoadFrom("MVCPattern.WinForm.exe");
            Type type = assembly.GetType("MVCPattern.WinForm.WinForm");
            MethodInfo winFormMethod = type.GetMethod("Start");
            winFormStart winFormStart = (winFormStart)winFormMethod.CreateDelegate(typeof(winFormStart));
            Thread winThread = new Thread(() => winFormStart(applicationThread));
            winThread.Start();
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
    }
}
