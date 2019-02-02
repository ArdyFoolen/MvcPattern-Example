using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MVCPattern.Model;
using MVCPattern.Control;
using System.Reflection;
using MVCPattern.Interfaces;

namespace MVCPattern.Console
{
    public static class Console
    {
        public static void Main(string[] args)
        {
            ApplicationThread applicationThread = new ApplicationThread();
            StartKMteller(applicationThread);
            StartWinForm(applicationThread);
            Start(applicationThread);
        }

        public static void Start(ApplicationThread applicationThread)
        {
            ConsoleThread consoleThread = new ConsoleThread();
            consoleThread.ApplicationThread = applicationThread;
            Thread oThread = new Thread(new ThreadStart(consoleThread.ReadLine));
            oThread.Start();
            oThread.Join();
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
