using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Models
{
    public class FinishTaskCM : CommandBase
    {
        public string TaskUuid { get; set; }

        public override CommandType CommandType
        {
            get
            {
                return CommandType.FinishTask;
            }
        }

        public override string Message
        {
            get
            {
                return $"User {this.Sender} finished task {this.TaskUuid}";
            }
        }

        public FinishTaskCM(string sender, string taskUuid)
        {
            this.Sender = sender;
            this.TaskUuid = taskUuid;
        }       
    }
}
