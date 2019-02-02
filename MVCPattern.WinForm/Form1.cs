using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MVCPattern.Control;
using MVCPattern.Interfaces;
using MVCPattern.Model;
using System.Reflection;

namespace MVCPattern.WinForm
{
    public partial class Form1 : Form, IVehicleView, IApplicationThread
    {
        public Form1()
        {
            InitializeComponent();

            this.btnRight.Enabled = false;
            this.btnLeft.Enabled = false;
            this.label2.Height = 2;
            this.label2.Width = this.Width - 50;

            ControlFactory factory = ControlFactory.GetSingleton();
            if (!factory.HasVehicleControl)
            {
                factory.CreateVehicleControl(typeof(VehicleControl), new SportsCar("Sporty"));
            }
            factory.VehicleControl.AddObserver(this);
        }

        private delegate void SetControlPropertyThreadSafeDelegate(System.Windows.Forms.Control control, string propertyName, object propertyValue);
        public static void SetControlPropertyThreadSafe(System.Windows.Forms.Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }

        private void btnAccelerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtAmount.Text))
            {
                this.txtAmount.Text = "0";
            }
            ControlFactory.GetSingleton().VehicleControl.RequestAccelerate(int.Parse(this.txtAmount.Text));
        }

        private void btnDecelerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtAmount.Text))
            {
                this.txtAmount.Text = "0";
            }
            ControlFactory.GetSingleton().VehicleControl.RequestDecelerate(int.Parse(this.txtAmount.Text));
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            ControlFactory.GetSingleton().VehicleControl.RequestTurn(RelativeDirection.Left);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            ControlFactory.GetSingleton().VehicleControl.RequestTurn(RelativeDirection.Right);
        }

        public void DisableAcceleration()
        {
            SetControlPropertyThreadSafe(this.btnAccelerate, "Enabled", false);
        }

        public void EnableAcceleration()
        {
            SetControlPropertyThreadSafe(this.btnAccelerate, "Enabled", true);
        }

        public void DisableDeceleration()
        {
            SetControlPropertyThreadSafe(this.btnDecelerate, "Enabled", false);
        }

        public void EnableDeceleration()
        {
            SetControlPropertyThreadSafe(this.btnDecelerate, "Enabled", true);
        }

        public void DisableTurning()
        {
            SetControlPropertyThreadSafe(this.btnRight, "Enabled", false);
            SetControlPropertyThreadSafe(this.btnLeft, "Enabled", false);
        }

        public void EnableTurning()
        {
            SetControlPropertyThreadSafe(this.btnRight, "Enabled", true);
            SetControlPropertyThreadSafe(this.btnLeft, "Enabled", true);
        }

        public void Update(IVehicleControl paramControl)
        {
            IVehicleControl control = ControlFactory.GetSingleton().VehicleControl;

            AbsoluteDirection direction = control.GetDirection();
            if (control.GetSpeed() < 0)
            {
                direction = (AbsoluteDirection)(((int)direction + 2) % 4);
            }

            string move = string.Empty;
            if (control.GetSpeed() != 0)
            {
                move = control.GetName() + " heading " + direction.ToString() + " at speed: " + control.GetSpeed().ToString();
            }
            else
            {
                move = control.GetName() + " is parked facing " + direction.ToString();
            }

            SetControlPropertyThreadSafe(this.label1, "Text", move);

            int maxSpeed = (control.GetSpeed() > 0) ? control.GetMaxSpeed() : control.GetMaxReverseSpeed();
            SetControlPropertyThreadSafe(this.pBar, "Value", (maxSpeed == 0) ? 0 : control.GetSpeed() * 100 / maxSpeed);
        }

        public void Initialize()
        {
            SetControlPropertyThreadSafe(this.btnLeft, "Enabled", false);
            SetControlPropertyThreadSafe(this.btnRight, "Enabled", false);
            SetControlPropertyThreadSafe(this.btnAccelerate, "Enabled", true);
            SetControlPropertyThreadSafe(this.btnDecelerate, "Enabled", true);

            SetControlPropertyThreadSafe(this.pBar, "Value", 0);
            SetControlPropertyThreadSafe(this.label1, "Text", string.Empty);
        }

        private void btnBuildTruck_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaxSpeed.Text) || string.IsNullOrEmpty(txtMaxTurnSpeed.Text) || string.IsNullOrEmpty(txtMaxReverseSpeed.Text))
            {
                MessageBox.Show("Enter numeric values for the speed textboxes!", "WinForm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ControlFactory factory = ControlFactory.GetSingleton();

            if (chkSlowPoke.Checked)
            {
                factory.CreateVehicleControl(typeof(SlowPokeControl), new Truck(int.Parse(txtMaxSpeed.Text), int.Parse(txtMaxTurnSpeed.Text), Math.Abs(int.Parse(txtMaxReverseSpeed.Text)) * -1, txtName.Text));
            }
            else
            {
                factory.CreateVehicleControl(typeof(VehicleControl), new Truck(int.Parse(txtMaxSpeed.Text), int.Parse(txtMaxTurnSpeed.Text), Math.Abs(int.Parse(txtMaxReverseSpeed.Text)) * -1, txtName.Text));
            }
            factory.VehicleControl.AddObserver(this);
            factory.VehicleControl.InitializeObservers();
            factory.VehicleControl.RequestAccelerate(0); // To display that car is parked
        }

        private void btnBuildSportscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaxSpeed.Text) || string.IsNullOrEmpty(txtMaxTurnSpeed.Text) || string.IsNullOrEmpty(txtMaxReverseSpeed.Text))
            {
                MessageBox.Show("Enter numeric values for the speed textboxes!", "WinForm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ControlFactory factory = ControlFactory.GetSingleton();

            if (chkSlowPoke.Checked)
            {
                factory.CreateVehicleControl(typeof(SlowPokeControl), new SportsCar(int.Parse(txtMaxSpeed.Text), int.Parse(txtMaxTurnSpeed.Text), Math.Abs(int.Parse(txtMaxReverseSpeed.Text)) * -1, txtName.Text));
            }
            else
            {
                factory.CreateVehicleControl(typeof(VehicleControl), new SportsCar(int.Parse(txtMaxSpeed.Text), int.Parse(txtMaxTurnSpeed.Text), Math.Abs(int.Parse(txtMaxReverseSpeed.Text)) * -1, txtName.Text));
            }
            factory.VehicleControl.AddObserver(this);
            factory.VehicleControl.InitializeObservers();
            factory.VehicleControl.RequestAccelerate(0); // To display that car is parked
        }

        private void btnDefaultTruck_Click(object sender, EventArgs e)
        {
            ControlFactory factory = ControlFactory.GetSingleton();
            factory.CreateVehicleControl(typeof(SlowPokeControl), new Truck("Trucky"));
            factory.VehicleControl.AddObserver(this);
            factory.VehicleControl.InitializeObservers();
            factory.VehicleControl.RequestAccelerate(0); // To display that car is parked
        }

        private void btnDefaultSportsCar_Click(object sender, EventArgs e)
        {
            ControlFactory factory = ControlFactory.GetSingleton();
            factory.CreateVehicleControl(typeof(VehicleControl), new SportsCar("Sporty"));
            factory.VehicleControl.AddObserver(this);
            factory.VehicleControl.InitializeObservers();
            factory.VehicleControl.RequestAccelerate(0); // To display that car is parked
        }

        private bool closeThread = false;
        delegate void CloseDelegate();
        public void CloseApplication()
        {
            this.closeThread = true;
            if (this.InvokeRequired)
            {
                CloseDelegate close = new CloseDelegate(CloseApplication);
                this.Invoke(close, null);
            }
            else
                this.Close();
        }

        public string ApplicationId { get { return "WinFormApplication"; } }

        private ApplicationThread applicationThread;
        public ApplicationThread ApplicationThread { get { return this.applicationThread; } set { this.applicationThread = value; this.applicationThread.Register(this); } }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closeThread && this.ApplicationThread != null)
            {
                this.ApplicationThread.CloseAllThreads(this.ApplicationId);
            }
        }
    }
}
