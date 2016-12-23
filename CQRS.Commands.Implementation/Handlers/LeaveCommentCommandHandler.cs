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
    public class LeaveCommentCommandHandler : CommandHandlerBase<LeaveCommentOnTaskCM>
    {
        public LeaveCommentCommandHandler(ICoreRepository repository) : base(repository)
        {
        }

        public override CommandValidationResult Validate(LeaveCommentOnTaskCM command)
        {
            var taskExists = this.repository.IsTaskExists(command.TaskUuid);


            return null;
        }

        public override void Execute(LeaveCommentOnTaskCM command)
        {
            this.repository.AddComment(command.TaskUuid, command.Message);            
        }

    }
}
