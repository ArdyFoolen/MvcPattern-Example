using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MVCPattern.Model;
using MVCPattern.Control;
using System.Reflection;

namespace MVCPattern.Console
{
    public static class Console
    {
        public static void Main(string[] args)
        {
            StartKMteller();
            StartWinForm();
            Start();
        }

        public static void Start()
        {
            ConsoleThread consoleThread = new ConsoleThread();
            Thread oThread = new Thread(new ThreadStart(consoleThread.ReadLine));
            oThread.Start();
            oThread.Join();
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
