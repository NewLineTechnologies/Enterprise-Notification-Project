using CQRS.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Implementation.Exceptions
{
    public class CommandDispatchException : Exception
    {
        public CommandValidationResult ValidationResult { get; private set; }

        public CommandDispatchException(CommandValidationResult validationResult)
        {
            this.ValidationResult = validationResult;
        }
    }
}
