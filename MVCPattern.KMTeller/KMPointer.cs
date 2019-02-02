using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVCPattern.KMTeller
{
    public partial class KMPointer : UserControl
    {
        public KMPointer()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;

            Timer timer = new Timer();
            timer.Interval = (10); // 0.01 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private float offset = 0.0f;
        private int previous = 0;
        private int km;
        public int KM
        {
            get
            {
                return this.km;
            }
            set
            {
                //this.previous = this.km;
                this.km = Math.Abs(value);
                Invalidate();
            }
        }

        public float RotateRatioPerKm { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Pen pen = new Pen(Color.WhiteSmoke, 5);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;

            if (this.previous < this.km) this.previous += 1;
            if (this.previous > this.km) this.previous -= 1;

            if (this.km != 0)
                if (offset == 0.0f) offset = 0.5f; else offset = 0.0f;
            float rotateKm = -135.0f + this.previous * this.RotateRatioPerKm + offset; // vb 85 km / uur; 0 = -135.0f + afhankelijk ratio hoek (30.0f = 10km/u) en km

            e.Graphics.TranslateTransform(160.0f, 160.0f);
            e.Graphics.RotateTransform(rotateKm);
            e.Graphics.DrawLine(pen, 0, -130, 0, 0);
            e.Graphics.ResetTransform();
        }
    }
}
