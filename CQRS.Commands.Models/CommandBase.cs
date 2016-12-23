using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Models
{
    public class CommandBase
    {
        public virtual CommandType CommandType { get; }

        public string Sender { get; set; }

        public virtual string Message { get; }
    }
}
