using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPattern.Interfaces
{
    public interface IVehicleControl
    {
        // Behavorial methods
        void RequestAccelerate(int paramAmount);
        void RequestDecelerate(int paramAmount);
        void RequestTurn(RelativeDirection paramDirection);

        // State methods (Can be properties), accesses properties on model
        string GetName();
        AbsoluteDirection GetDirection();
        int GetSpeed();
        int GetMaxSpeed();
        int GetMaxReverseSpeed();
        int GetDisplayInterval();

        // View changes state, e.g. Accelerator Button is clicked
        // View sends message to control, e.g. control.RequestAccelerate(txtAmount.Text)
        //   Control performs logic, e.g. SlowPokeControl, if (amount > 5)  amount = 5;
        //   Control updates model, e.g. model.Accelerate(amount)
        //     Model preforms logic, e.g. if (this.mintSpeed >= this.mintMaxSpeed) this.mintSpeed = this.mintMaxSpeed;
        //   Control notifies observers
        //     For each view
        //       Set view, e.g. view.DisableAcceleration();
        //       Update view, e.g. view.Update(this);
        //         Update view, e.g. this.label1.Text = control.GetName()
        //           Control gets state from model, e.g. model.Name
        void SetModel(IVehicleModel paramModel);
        List<IVehicleView> GetObservers();
        void AddObserver(IVehicleView paramView);
        void RemoveObserver(IVehicleView paramView);
        void NotifyObservers();
        void InitializeObservers();
    }
}
