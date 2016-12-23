using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using SimpleInjector;

namespace MessageHistoryWriter
{
    public class SIJobActivator : IJobActivator
    {
        private Container container;

        public SIJobActivator(Container container)
        {
            this.container = container;
        }

        public T CreateInstance<T>()
        {
            return (T)container.GetInstance(typeof(T));
        }
    }
}
