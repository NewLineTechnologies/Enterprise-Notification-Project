using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialProject.Web.Hubs
{
    public interface INotificationClient
    {
        void Notify(string message);
    }
}
