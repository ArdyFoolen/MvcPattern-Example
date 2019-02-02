using MVCPattern.Control;
using MVCPattern.Interfaces;
using MVCPattern.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVCPattern.KMTeller
{
    public partial class Form1 : Form, IVehicleView, IApplicationThread
    {
        private KMPointer kmPointer;
        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.BackColor = Color.Lime;
            this.TransparencyKey = Color.Lime;
            this.FormBorderStyle = FormBorderStyle.None;

            this.kmPointer = new KMPointer();
            this.kmPointer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kmPointer_MouseDown);
            this.kmPointer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.kmPointer_MouseMove);

            this.Controls.Add(this.kmPointer);

            Rectangle client = this.ClientRectangle;
            int borderWidth = this.Width - client.Width;
            int borderHeight = this.Height - client.Height;
            this.Width = 320 + borderWidth;
            this.Height = 320 + borderHeight;

            ControlFactory factory = ControlFactory.GetSingleton();
            if (!factory.HasVehicleControl)
            {
                factory.CreateVehicleControl(typeof(VehicleControl), new SportsCar("Sporty"));
            }
            factory.VehicleControl.AddObserver(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rectangle = new Rectangle(10, 10, 300, 300);
            Brush brush = new SolidBrush(Color.Black);
            e.Graphics.FillEllipse(brush, rectangle);

            rectangle = new Rectangle(15, 15, 290, 290);
            Pen pen = new Pen(Color.Wheat, 5);
            Pen thinPen = new Pen(Color.Wheat, 2);
            e.Graphics.DrawArc(pen, rectangle, 0, 360);

            int cijfer = 0;
            string drawString = cijfer.ToString();
            Font drawFont = new System.Drawing.Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Wheat);

            IVehicleControl control = ControlFactory.GetSingleton().VehicleControl;
            int maxSpeed = control.GetMaxSpeed();
            int displayInterval = control.GetDisplayInterval();

            int nbr = maxSpeed / displayInterval + 1;
            float rotateN = 270f / nbr;
            float rotateF = rotateN / (displayInterval / 5);

            this.kmPointer.RotateRatioPerKm = rotateN / displayInterval;

            e.Graphics.TranslateTransform(160.0f, 160.0f);
            e.Graphics.RotateTransform(-135.0f);
            for (int i = 0; i <= nbr; i++)
            {
                SizeF size = e.Graphics.MeasureString(drawString, drawFont);
                float corrWidth = size.Width / 2;
                float corrHeight = size.Height / 2;

                e.Graphics.TranslateTransform(0.0f, -85.0f);
                e.Graphics.RotateTransform((-135.0f + i * rotateN) * -1.0f);
                e.Graphics.TranslateTransform(-corrWidth, -corrHeight);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, 0, 0);
                e.Graphics.TranslateTransform(corrWidth, corrHeight);
                e.Graphics.RotateTransform(-135.0f + i * rotateN);
                e.Graphics.TranslateTransform(0.0f, 85.0f);

                cijfer += displayInterval;
                drawString = cijfer.ToString();

                e.Graphics.DrawLine(pen, 0, -130, 0, -110);
                e.Graphics.RotateTransform(rotateF);

                if (i < nbr)
                    for (int x = 0; x < displayInterval / 5 - 1; x++)
                    {
                        if ((x % 2) == 0)
                            e.Graphics.DrawLine(thinPen, 0, -130, 0, -115);
                        else
                            e.Graphics.DrawLine(thinPen, 0, -130, 0, -110);
                        e.Graphics.RotateTransform(rotateF);
                    }
            }
            e.Graphics.ResetTransform();
        }

        private Point lastClick;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                lastClick = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }

        private void kmPointer_MouseDown(object sender, MouseEventArgs e)
        {
            Form1_MouseDown(sender, e);
        }

        private void kmPointer_MouseMove(object sender, MouseEventArgs e)
        {
            Form1_MouseMove(sender, e);
        }

        public void DisableAcceleration()
        {
        }

        public void EnableAcceleration()
        {
        }

        public void DisableDeceleration()
        {
        }

        public void EnableDeceleration()
        {
        }

        public void DisableTurning()
        {
        }

        public void EnableTurning()
        {
        }

        public void Initialize()
        {
            this.kmPointer.KM = 0;
        }

        public void Update(IVehicleControl paramControl)
        {
            IVehicleControl control = ControlFactory.GetSingleton().VehicleControl;
            this.kmPointer.KM = control.GetSpeed();
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

        public string ApplicationId { get { return "KMTellerApplication"; } }

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
