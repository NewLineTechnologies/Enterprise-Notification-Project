using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Models
{
    public class LeaveCommentOnTaskCM : CommandBase
    {
        public string TaskUuid { get; set; }

        public string CommentText { get; set; }

        public override CommandType CommandType
        {
            get
            {
                return CommandType.LeaveCommentOnTask;
            }
        }

        public override string Message
        {
            get
            {
                return $"User {this.Sender} leave comment on task {this.TaskUuid}";
            }
        }

        public LeaveCommentOnTaskCM(string sender, string commentText, string taskUuid)
        {
            this.Sender = sender;
            this.CommentText = commentText;
            this.TaskUuid = taskUuid;
        }
    }
}
