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
    public class UserLogoutCommandHandler : CommandHandlerBase<UserLogoutCM>
    {
        public UserLogoutCommandHandler(ICoreRepository repository) : base(repository)
        {
        }

        public override CommandValidationResult Validate(UserLogoutCM command)
        {
            var user = this.repository.GetUserByEmail(command.Email);

            if (user == null)
            {
                return new CommandValidationResult("User not found");
            }            

            return null;
        }

    }
}
