using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Link : http://www.c-sharpcorner.com/UploadFile/rmcochran/MVC_intro12122005162329PM/MVC_intro.aspx

namespace MVCPattern.Model
{
    public class SportsCar : Vehicle
    {
        public SportsCar(string paramName) : base(250, 40, -20, paramName) { }
        public SportsCar(int paramMaxSpeed, int paramMaxTurnSpeed, int paramMaxReverseSpeed, string paramName) : base(paramMaxSpeed, paramMaxTurnSpeed, paramMaxReverseSpeed, paramName) { }
    }
}
