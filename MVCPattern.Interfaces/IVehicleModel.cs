using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPattern.Interfaces
{
    public interface IVehicleModel
    {
        string Name { get; set; }
        int Speed { get; }
        int MaxSpeed { get; }
        int MaxTurnSpeed { get; }
        int MaxReverseSpeed { get; }
        AbsoluteDirection Direction { get; }
        void Turn(RelativeDirection paramDirection);
        void Accelerate(int paramAmount);
        void Decelerate(int paramAmount);
    }
}
