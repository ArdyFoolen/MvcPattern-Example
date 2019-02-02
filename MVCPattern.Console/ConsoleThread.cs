using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using MVCPattern.Control;
using MVCPattern.Model;
using MVCPattern.Interfaces;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MVCPattern.Console
{
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        internal static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        internal static extern Boolean FreeConsole();
    }

    public class ConsoleThread : IVehicleView
    {
        public ConsoleThread()
        {
            this.Result = string.Empty;
            this.CanAccelerate = true;
            this.CanDecelerate = true;
            this.CanTurn = false;

            ControlFactory factory = ControlFactory.GetSingleton();
            if (!factory.HasVehicleControl)
            {
                factory.CreateVehicleControl(typeof(VehicleControl), new SportsCar("Sporty"));
            }
            factory.VehicleControl.AddObserver(this);
        }

        public string Result { get; set; }
        
        public void ReadLine()
        {
            NativeMethods.AllocConsole();

            System.Console.WriteLine("Enter (Q) : Quit\n(<0) : Decelerate  (>0) : Accelerate\n(L) : Turn Left  (R) : Turn Right\n" +
                                     "Build (DT) : Default Truck  (DS) : Default Sportscar\n" +
                                     "      (BT,Name, Max Speed, Max Reverse Speed, Max Turn Speed, SlowPoke(T,F)) : Truck\n" +
                                     "      (BS,Name, Max Speed, Max Reverse Speed, Max Turn Speed, SlowPoke(T,F)) : Sportscar");

            while (Result.ToLower() != "q")
            {
                Result = System.Console.ReadLine();

                int amount;
                if (int.TryParse(Result, out amount))
                {
                    if (amount >= 0)
                    {
                        if (this.CanAccelerate)
                        {
                            ControlFactory.GetSingleton().VehicleControl.RequestAccelerate(amount);
                        }
                    }
                    else
                    {
                        if (this.CanDecelerate)
                        {
                            ControlFactory.GetSingleton().VehicleControl.RequestDecelerate(Math.Abs(amount));
                        }
                    }
                }
                else
                {
                    if (Result.ToLower() == "l")
                    {
                        if (this.CanTurn)
                        {
                            ControlFactory.GetSingleton().VehicleControl.RequestTurn(RelativeDirection.Left);
                        }
                    }
                    if (Result.ToLower() == "r")
                    {
                        if (this.CanTurn)
                        {
                            ControlFactory.GetSingleton().VehicleControl.RequestTurn(RelativeDirection.Right);
                        }
                    }

                    if (Result.ToLower() == "dt")
                    {
                        ControlFactory dtFactory = ControlFactory.GetSingleton();
                        dtFactory.CreateVehicleControl(typeof(SlowPokeControl), new Truck("Trucky"));
                        dtFactory.VehicleControl.AddObserver(this);
                        dtFactory.VehicleControl.InitializeObservers();
                        dtFactory.VehicleControl.RequestAccelerate(0);
                    }
                    if (Result.ToLower() == "ds")
                    {
                        ControlFactory dsFactory = ControlFactory.GetSingleton();
                        dsFactory.CreateVehicleControl(typeof(VehicleControl), new SportsCar("Sporty"));
                        dsFactory.VehicleControl.AddObserver(this);
                        dsFactory.VehicleControl.InitializeObservers();
                        dsFactory.VehicleControl.RequestAccelerate(0);
                    }

                    string[] sList = Result.Split(new char[] { ',' });
                    if (sList.Count() == 6)
                    {
                        int maxSpeed;
                        int maxReverseSpeed;
                        int maxTurnSpeed;
                        int.TryParse(sList[2], out maxSpeed);
                        int.TryParse(sList[3], out maxReverseSpeed);
                        int.TryParse(sList[4], out maxTurnSpeed);
                        if (sList[0].ToLower() == "bt")
                        {
                            ControlFactory btFactory = ControlFactory.GetSingleton();
                            if (sList[5].ToLower() == "t")
                            {
                                btFactory.CreateVehicleControl(typeof(SlowPokeControl), new Truck(maxSpeed, maxTurnSpeed, Math.Abs(maxReverseSpeed) * -1, sList[1]));
                            }
                            else
                            {
                                btFactory.CreateVehicleControl(typeof(VehicleControl), new Truck(maxSpeed, maxTurnSpeed, Math.Abs(maxReverseSpeed) * -1, sList[1]));
                            }
                            btFactory.VehicleControl.AddObserver(this);
                            btFactory.VehicleControl.InitializeObservers();
                            btFactory.VehicleControl.RequestAccelerate(0);
                        }
                        if (sList[0].ToLower() == "bs")
                        {
                            ControlFactory bsFactory = ControlFactory.GetSingleton();
                            if (sList[5].ToLower() == "t")
                            {
                                bsFactory.CreateVehicleControl(typeof(SlowPokeControl), new SportsCar(maxSpeed, maxTurnSpeed, Math.Abs(maxReverseSpeed) * -1, sList[1]));
                            }
                            else
                            {
                                bsFactory.CreateVehicleControl(typeof(VehicleControl), new SportsCar(maxSpeed, maxTurnSpeed, Math.Abs(maxReverseSpeed) * -1, sList[1]));
                            }
                            bsFactory.VehicleControl.AddObserver(this);
                            bsFactory.VehicleControl.InitializeObservers();
                            bsFactory.VehicleControl.RequestAccelerate(0);
                        }
                    }
                }

            }

            ControlFactory factory = ControlFactory.GetSingleton();
            factory.VehicleControl.RemoveObserver(this);

            NativeMethods.FreeConsole();
        }

        public void Initialize()
        {
            this.Result = string.Empty;
            this.CanAccelerate = true;
            this.CanDecelerate = true;
            this.CanTurn = false;

            System.Console.Clear();
            System.Console.WriteLine("Enter (Q) : Quit\n(<0) : Decelerate  (>0) : Accelerate\n(L) : Turn Left  (R) : Turn Right\n" +
                                     "Build (DT) : Default Truck  (DS) : Default Sportscar\n" +
                                     "      (BT,Name, Max Speed, Max Reverse Speed, Max Turn Speed, SlowPoke(T,F)) : Truck\n" +
                                     "      (BS,Name, Max Speed, Max Reverse Speed, Max Turn Speed, SlowPoke(T,F)) : Sportscar");
        }

        private bool CanAccelerate { get; set; }
        public void DisableAcceleration()
        {
            if (this.CanAccelerate)
            {
                this.CanAccelerate = false;
                System.Console.WriteLine("Accelerating turned off");
            }
        }

        public void EnableAcceleration()
        {
            if (!this.CanAccelerate)
            {
                this.CanAccelerate = true;
                System.Console.WriteLine("Accelerating turned on");
            }
        }

        private bool CanDecelerate { get; set; }
        public void DisableDeceleration()
        {
            if (this.CanDecelerate)
            {
                this.CanDecelerate = false;
                System.Console.WriteLine("Decelerating turned off");
            }
        }

        public void EnableDeceleration()
        {
            if (!this.CanDecelerate)
            {
                this.CanDecelerate = true;
                System.Console.WriteLine("Decelerating turned on");
            }
        }

        private bool CanTurn { get; set; }
        public void DisableTurning()
        {
            if (this.CanTurn)
            {
                this.CanTurn = false;
                System.Console.WriteLine("Turning turned off");
            }
        }

        public void EnableTurning()
        {
            if (!this.CanTurn)
            {
                this.CanTurn = true;
                System.Console.WriteLine("Turning turned on");
            }
        }

        public void Update(IVehicleControl paramControl)
        {
            AbsoluteDirection direction = paramControl.GetDirection();
            if (paramControl.GetSpeed() < 0)
            {
                direction = (AbsoluteDirection)(((int)direction + 2) % 4);
            }

            string move = string.Empty;
            if (paramControl.GetSpeed() != 0)
            {
                move = paramControl.GetName() + " heading " + direction.ToString() + " at speed: " + paramControl.GetSpeed().ToString();
            }
            else
            {
                move = paramControl.GetName() + " is parked facing " + direction.ToString();
            }

            System.Console.WriteLine(move);
        }
    }
}
