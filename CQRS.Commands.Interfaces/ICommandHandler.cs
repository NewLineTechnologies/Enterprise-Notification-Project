using CQRS.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Interfaces
{
    public interface ICommandHandler<in TCommand>
     where TCommand : CommandBase
    {
        CommandValidationResult Validate(TCommand command);

        void Execute(TCommand command);        
    }
}
