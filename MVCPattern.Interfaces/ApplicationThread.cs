using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPattern.Interfaces
{
    public class ApplicationThread
    {
        private List<IApplicationThread> threads = new List<IApplicationThread>();

        public void Register(IApplicationThread applicationThread)
        {
            this.threads.Remove(applicationThread);
            this.threads.Add(applicationThread);
        }

        public void Unregister(IApplicationThread applicationThread)
        {
            this.threads.Remove(applicationThread);
        }

        public void CloseAllThreads(string id)
        {
            if (this.threads != null && this.threads.Count > 0)
            {
                foreach (IApplicationThread thread in this.threads)
                {
                    if (!id.Equals(thread.ApplicationId))
                        thread.CloseApplication();
                }
            }
        }

    }
}
