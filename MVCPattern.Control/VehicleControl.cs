using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCPattern.Interfaces;

namespace MVCPattern.Control
{
    public class VehicleControl : IVehicleControl
    {
        private List<IVehicleView> aList = new List<IVehicleView>();
        private IVehicleModel model;

        public VehicleControl(IVehicleModel paramModel)
        {
            this.model = paramModel;
        }

        public void SetModel(IVehicleModel paramModel)
        {
            this.model = paramModel;
        }

        public List<IVehicleView> GetObservers()
        {
            return this.aList;
        }

        public void AddObserver(IVehicleView paramView)
        {
            this.RemoveObserver(paramView);
            this.aList.Add(paramView);
        }

        public void RemoveObserver(IVehicleView paramView)
        {
            this.aList.Remove(paramView);
        }

        public void NotifyObservers()
        {
            foreach (IVehicleView view in this.aList)
            {
                this.setView(view);
                view.Update(this);
            }
        }

        public void InitializeObservers()
        {
            foreach (IVehicleView view in this.aList)
            {
                try
                {
                    view.Initialize();
                }
                catch (Exception) { }
            }
        }

        public virtual void RequestAccelerate(int paramAmount)
        {
            if (this.model != null)
            {
                model.Accelerate(paramAmount);
                this.NotifyObservers();
            }
        }

        public virtual void RequestDecelerate(int paramAmount)
        {
            if (this.model != null)
            {
                model.Decelerate(paramAmount);
                this.NotifyObservers();
            }
        }

        public virtual void RequestTurn(RelativeDirection paramDirection)
        {
            if (this.model != null)
            {
                model.Turn(paramDirection);
                this.NotifyObservers();
            }
        }

        public string GetName()
        {
            return this.model.Name;
        }

        public AbsoluteDirection GetDirection()
        {
            return this.model.Direction;
        }

        public int GetSpeed()
        {
            return this.model.Speed;
        }

        public int GetMaxSpeed()
        {
            return this.model.MaxSpeed;
        }

        public int GetMaxReverseSpeed()
        {
            return this.model.MaxReverseSpeed;
        }

        public virtual int GetDisplayInterval()
        {
            return 40;
        }

        private void setView(IVehicleView paramView)
        {
            if (this.model.Speed >= this.model.MaxSpeed)
                paramView.DisableAcceleration();
            else
                paramView.EnableAcceleration();

            if (this.model.Speed <= this.model.MaxReverseSpeed)
                paramView.DisableDeceleration();
            else
                paramView.EnableDeceleration();

            if (this.model.Speed == 0 || this.model.Speed >= this.model.MaxTurnSpeed)
            {
                paramView.DisableTurning();
            }
            else
            {
                paramView.EnableTurning();
            }
        }
    }
}
