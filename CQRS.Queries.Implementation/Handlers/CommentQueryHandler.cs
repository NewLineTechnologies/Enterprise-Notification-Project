using CQRS.Queries.Implementation.Queries;
using CQRS.Queries.Interfaces;
using CQRS.Queries.Models;
using DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Queries.Implementation.Handlers
{
    public class CommentQueryHandler : IQueryHandler<CommentQuery, CommentsQueryResult>
    {
        private readonly ICoreRepository coreRepository;

        public CommentQueryHandler(ICoreRepository coreRepository)
        {
            this.coreRepository = coreRepository;
        }

        public CommentsQueryResult Execute(CommentQuery query)
        {
            return new CommentsQueryResult()
            {
                Content = this.coreRepository.GetTaskComments(query.TaskId)
            };

        }
    }
}
