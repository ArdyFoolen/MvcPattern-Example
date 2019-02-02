using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCPattern.Interfaces;

namespace MVCPattern.Model
{
    public abstract class Vehicle : IVehicleModel
    {
        private int mintSpeed = 0;
        private int mintMaxSpeed = 0;
        private int mintMaxTurnSpeed = 0;
        private int mintMaxReverseSpeed = 0;
        private AbsoluteDirection mDirection = AbsoluteDirection.North;
        private string mstrName = string.Empty;

        public Vehicle(int paramMaxSpeed, int paramMaxTurnSpeed, int paramMaxReverseSpeed, string paramName)
        {
            this.mintMaxSpeed = paramMaxSpeed;
            this.mintMaxTurnSpeed = paramMaxTurnSpeed;
            this.mintMaxReverseSpeed = paramMaxReverseSpeed;
            this.mstrName = paramName;
        }

        public string Name
        {
            get
            {
                return this.mstrName;
            }
            set
            {
                this.mstrName = value;
            }
        }

        public int Speed
        { 
            get
            {
                return this.mintSpeed;
            }
        }

        public int MaxSpeed
        { 
            get 
            { 
                return this.mintMaxSpeed;
            } 
        }

        public int MaxTurnSpeed
        { 
            get 
            { 
                return this.mintMaxTurnSpeed; 
            } 
        }

        public int MaxReverseSpeed
        {
            get
            {
                return mintMaxReverseSpeed;
            }
        }

        public AbsoluteDirection Direction
        {
            get 
            { 
                return this.mDirection;
            }
        }

        public void Turn(RelativeDirection paramDirection)
        {
            if (this.Speed != 0)
            {
                AbsoluteDirection newDirection;
                switch (paramDirection)
                {
                    case RelativeDirection.Right:
                        newDirection = (AbsoluteDirection)((int)(this.mDirection + 1) % 4);
                        break;
                    case RelativeDirection.Left:
                        newDirection = (AbsoluteDirection)((int)(this.mDirection + 3) % 4);
                        break;
                    case RelativeDirection.Back:
                        newDirection = (AbsoluteDirection)((int)(this.mDirection + 2) % 4);
                        break;
                    default:
                        newDirection = AbsoluteDirection.North;
                        break;
                }

                if (this.Speed < 0)
                {
                    newDirection = (AbsoluteDirection)(((int)newDirection + 2) % 4);
                }


                this.mDirection = newDirection;
            }
        }

        public void Accelerate(int paramAmount)
        {
            this.mintSpeed += paramAmount;
            if (this.mintSpeed >= this.mintMaxSpeed)
            {
                this.mintSpeed = this.mintMaxSpeed;
            }
        }

        public void Decelerate(int paramAmount)
        {
            this.mintSpeed -= paramAmount;
            if (this.mintSpeed <= this.mintMaxReverseSpeed)
            {
                this.mintSpeed = this.mintMaxReverseSpeed;
            }
        }
    }
}
