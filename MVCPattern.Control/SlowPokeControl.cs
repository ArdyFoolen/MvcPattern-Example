using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCPattern.Interfaces;

namespace MVCPattern.Control
{
    public class SlowPokeControl : VehicleControl
    {
        public SlowPokeControl(IVehicleModel paramModel) : base(paramModel)
        { }

        public override void RequestAccelerate(int paramAmount)
        {
            if (paramAmount > 5)
            {
                paramAmount = 5;
            }
            base.RequestAccelerate(paramAmount);
        }

        public override void RequestDecelerate(int paramAmount)
        {
            if (paramAmount > 5)
            {
                paramAmount = 5;
            }
            base.RequestDecelerate(paramAmount);
        }

        public override void RequestTurn(RelativeDirection paramDirection)
        {
            base.RequestTurn(paramDirection);
        }

        public override int GetDisplayInterval()
        {
            return 10;
        }
    }
}
