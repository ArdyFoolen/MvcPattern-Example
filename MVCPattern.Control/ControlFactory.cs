using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCPattern.Interfaces;

namespace MVCPattern.Control
{
    public class ControlFactory
    {
        private IVehicleControl control = null;
        private static ControlFactory instance = null;

        private ControlFactory() { }

        public static ControlFactory GetSingleton()
        {
            if (instance == null)
            {
                instance = new ControlFactory();
            }
            return instance;
        }

        public IVehicleControl CreateVehicleControl(Type type, IVehicleModel model)
        {
            List<IVehicleView> aList = null;
            if (control != null)
            {
                aList = control.GetObservers();
            }
            control = Activator.CreateInstance(type, model) as IVehicleControl;

            if (aList != null)
            {
                foreach (IVehicleView paramView in aList)
                {
                    control.AddObserver(paramView);
                }
            }

            return control;
        }

        public bool HasVehicleControl
        {
            get
            {
                return this.control != null;
            }
        }

        public IVehicleControl VehicleControl
        {
            get
            {
                return this.control;
            }
        }
    }
}
