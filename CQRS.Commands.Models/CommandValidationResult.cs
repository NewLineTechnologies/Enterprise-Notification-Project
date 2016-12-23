using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Models
{
    public class CommandValidationResult
    {
        public string Error { get; set; }

        public CommandValidationResult()
        {

        }

        public CommandValidationResult(string error)
        {
            this.Error = error;
        }
    }
}
