using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPattern.Interfaces
{
    public interface IApplicationThread
    {
        string ApplicationId { get; }
        void CloseApplication();
    }
}
