using CQRS.Queries.Interfaces;
using CQRS.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Queries.Implementation.Queries
{
    public class CommentQuery : IQuery<CommentsQueryResult>
    {
        public string TaskId { get; private set; }       

        public CommentQuery(string taskId)
        {
            this.TaskId = taskId;            
        }
    }
}
