using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPattern.Model
{
    public class Truck : Vehicle
    {
        public Truck(string paramName) : base(80, 25, -12, paramName) { }
        public Truck(int paramMaxSpeed, int paramMaxTurnSpeed, int paramMaxReverseSpeed, string paramName) : base(paramMaxSpeed, paramMaxTurnSpeed, paramMaxReverseSpeed, paramName) { }
    }

}
