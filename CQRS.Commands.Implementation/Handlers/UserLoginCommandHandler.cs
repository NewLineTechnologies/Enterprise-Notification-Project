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
    public class UserLoginCommandHandler : CommandHandlerBase<UserLoginCM>
    {
        public UserLoginCommandHandler(ICoreRepository repository) : base(repository)
        {
        }

        public CommandValidationResult Validate(UserLoginCM command)
        {
            var user = this.repository.GetUserByEmail(command.Email);
            
            if(user == null)
            {
                return new CommandValidationResult("User not found");
            }

            if(user.Password != command.Password)
            {
                return new CommandValidationResult("Invalid password");
            }

            return null;
        }       

    }
}
