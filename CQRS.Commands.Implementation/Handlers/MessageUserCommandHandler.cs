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
    public class MessageUserCommandHandler :  CommandHandlerBase<MessageUserCM>
    {
        public MessageUserCommandHandler(ICoreRepository repository) : base(repository)
        {
        }
     
    }
}
