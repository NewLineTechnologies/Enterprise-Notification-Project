using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Models
{
    public class TakeTaskCM : CommandBase
    {
        public string TaskUuid { get; set; }

        public override CommandType CommandType
        {
            get
            {
                return CommandType.TakeTask;
            }
        }

        public override string Message
        {
            get
            {
                return $"User {this.Sender} took task {this.TaskUuid}";
            }
        }

        public TakeTaskCM(string sender, string taskUuid)
        {
            this.Sender = sender;
            this.TaskUuid = taskUuid;
        }
    }
}
