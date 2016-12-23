using CQRS.Commands.Interfaces;
using CQRS.Commands.Models;
using DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Implementation.Handlers
{
    public class TakeTaskCommandHandler : CommandHandlerBase<TakeTaskCM>
    {
        public TakeTaskCommandHandler(ICoreRepository repository) : base(repository)
        {
        }

        public override void Execute(TakeTaskCM command)
        {
            base.Execute(command);
        }

    }
}
