using CQRS.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Interfaces
{
    public interface IAzureCommandQueue
    {
        string EnqueueCommand(CommandBase command);
    }
}
