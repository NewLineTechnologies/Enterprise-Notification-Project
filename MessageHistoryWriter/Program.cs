using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using SimpleInjector;

namespace MessageHistoryWriter
{    
    class Program
    {        
        static void Main()
        {
            JobHostConfiguration config = GetConfiguration();
            config.UseServiceBus();
            JobHost host = new JobHost(config);
            host.RunAndBlock();
        }

        private static JobHostConfiguration GetConfiguration()
        {
            JobHostConfiguration config = new JobHostConfiguration();            
                        
            var container = new Container();
            
            config.JobActivator = new SIJobActivator(container);
            RegisterSimpleInjector(container);
            return config;
        }

        private static void RegisterSimpleInjector(Container container)
        {
            DL.Infrastructure.Configurations.SimpleInjectorConfiguration.Bind(container);
        }
    }
}
