namespace MVCPattern.WinForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnDecelerate = new System.Windows.Forms.Button();
            this.btnAccelerate = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuildTruck = new System.Windows.Forms.Button();
            this.btnBuildSportscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtMaxSpeed = new System.Windows.Forms.TextBox();
            this.txtMaxReverseSpeed = new System.Windows.Forms.TextBox();
            this.txtMaxTurnSpeed = new System.Windows.Forms.TextBox();
            this.chkSlowPoke = new System.Windows.Forms.CheckBox();
            this.btnDefaultTruck = new System.Windows.Forms.Button();
            this.btnDefaultSportsCar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(12, 12);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(260, 23);
            this.pBar.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // btnDecelerate
            // 
            this.btnDecelerate.Location = new System.Drawing.Point(46, 42);
            this.btnDecelerate.Name = "btnDecelerate";
            this.btnDecelerate.Size = new System.Drawing.Size(45, 23);
            this.btnDecelerate.TabIndex = 1;
            this.btnDecelerate.Text = "<<";
            this.btnDecelerate.UseVisualStyleBackColor = true;
            this.btnDecelerate.Click += new System.EventHandler(this.btnDecelerate_Click);
            // 
            // btnAccelerate
            // 
            this.btnAccelerate.Location = new System.Drawing.Point(203, 42);
            this.btnAccelerate.Name = "btnAccelerate";
            this.btnAccelerate.Size = new System.Drawing.Size(45, 23);
            this.btnAccelerate.TabIndex = 2;
            this.btnAccelerate.Text = ">>";
            this.btnAccelerate.UseVisualStyleBackColor = true;
            this.btnAccelerate.Click += new System.EventHandler(this.btnAccelerate_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(97, 41);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 3;
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(46, 71);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 4;
            this.btnLeft.Text = "Turn Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(173, 71);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 5;
            this.btnRight.Text = "Turn Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // btnBuildTruck
            // 
            this.btnBuildTruck.Location = new System.Drawing.Point(140, 225);
            this.btnBuildTruck.Name = "btnBuildTruck";
            this.btnBuildTruck.Size = new System.Drawing.Size(108, 23);
            this.btnBuildTruck.TabIndex = 7;
            this.btnBuildTruck.Text = "Build Truck";
            this.btnBuildTruck.UseVisualStyleBackColor = true;
            this.btnBuildTruck.Click += new System.EventHandler(this.btnBuildTruck_Click);
            // 
            // btnBuildSportscar
            // 
            this.btnBuildSportscar.Location = new System.Drawing.Point(142, 254);
            this.btnBuildSportscar.Name = "btnBuildSportscar";
            this.btnBuildSportscar.Size = new System.Drawing.Size(106, 23);
            this.btnBuildSportscar.TabIndex = 8;
            this.btnBuildSportscar.Text = "Build Sportscar";
            this.btnBuildSportscar.UseVisualStyleBackColor = true;
            this.btnBuildSportscar.Click += new System.EventHandler(this.btnBuildSportscar_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(15, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 2);
            this.label2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Max Speed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Max Reverse Speed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Max Turn Speed";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(148, 119);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 14;
            // 
            // txtMaxSpeed
            // 
            this.txtMaxSpeed.Location = new System.Drawing.Point(148, 145);
            this.txtMaxSpeed.Name = "txtMaxSpeed";
            this.txtMaxSpeed.Size = new System.Drawing.Size(100, 20);
            this.txtMaxSpeed.TabIndex = 15;
            // 
            // txtMaxReverseSpeed
            // 
            this.txtMaxReverseSpeed.Location = new System.Drawing.Point(148, 172);
            this.txtMaxReverseSpeed.Name = "txtMaxReverseSpeed";
            this.txtMaxReverseSpeed.Size = new System.Drawing.Size(100, 20);
            this.txtMaxReverseSpeed.TabIndex = 16;
            // 
            // txtMaxTurnSpeed
            // 
            this.txtMaxTurnSpeed.Location = new System.Drawing.Point(148, 199);
            this.txtMaxTurnSpeed.Name = "txtMaxTurnSpeed";
            this.txtMaxTurnSpeed.Size = new System.Drawing.Size(100, 20);
            this.txtMaxTurnSpeed.TabIndex = 17;
            // 
            // chkSlowPoke
            // 
            this.chkSlowPoke.AutoSize = true;
            this.chkSlowPoke.Location = new System.Drawing.Point(15, 230);
            this.chkSlowPoke.Name = "chkSlowPoke";
            this.chkSlowPoke.Size = new System.Drawing.Size(77, 17);
            this.chkSlowPoke.TabIndex = 18;
            this.chkSlowPoke.Text = "Slow Poke";
            this.chkSlowPoke.UseVisualStyleBackColor = true;
            // 
            // btnDefaultTruck
            // 
            this.btnDefaultTruck.Location = new System.Drawing.Point(12, 284);
            this.btnDefaultTruck.Name = "btnDefaultTruck";
            this.btnDefaultTruck.Size = new System.Drawing.Size(106, 23);
            this.btnDefaultTruck.TabIndex = 19;
            this.btnDefaultTruck.Text = "Default Truck";
            this.btnDefaultTruck.UseVisualStyleBackColor = true;
            this.btnDefaultTruck.Click += new System.EventHandler(this.btnDefaultTruck_Click);
            // 
            // btnDefaultSportsCar
            // 
            this.btnDefaultSportsCar.Location = new System.Drawing.Point(142, 284);
            this.btnDefaultSportsCar.Name = "btnDefaultSportsCar";
            this.btnDefaultSportsCar.Size = new System.Drawing.Size(106, 23);
            this.btnDefaultSportsCar.TabIndex = 20;
            this.btnDefaultSportsCar.Text = "Default Sportscar";
            this.btnDefaultSportsCar.UseVisualStyleBackColor = true;
            this.btnDefaultSportsCar.Click += new System.EventHandler(this.btnDefaultSportsCar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 329);
            this.Controls.Add(this.btnDefaultSportsCar);
            this.Controls.Add(this.btnDefaultTruck);
            this.Controls.Add(this.chkSlowPoke);
            this.Controls.Add(this.txtMaxTurnSpeed);
            this.Controls.Add(this.txtMaxReverseSpeed);
            this.Controls.Add(this.txtMaxSpeed);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuildSportscar);
            this.Controls.Add(this.btnBuildTruck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnAccelerate);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnDecelerate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pBar);
            this.Name = "Form1";
            this.Text = "MVC Pattern";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnDecelerate;
        private System.Windows.Forms.Button btnAccelerate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuildTruck;
        private System.Windows.Forms.Button btnBuildSportscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtMaxSpeed;
        private System.Windows.Forms.TextBox txtMaxReverseSpeed;
        private System.Windows.Forms.TextBox txtMaxTurnSpeed;
        private System.Windows.Forms.CheckBox chkSlowPoke;
        private System.Windows.Forms.Button btnDefaultTruck;
        private System.Windows.Forms.Button btnDefaultSportsCar;
    }
}

