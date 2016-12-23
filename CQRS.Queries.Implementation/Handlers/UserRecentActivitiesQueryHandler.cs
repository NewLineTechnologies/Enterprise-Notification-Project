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
    public class UserRecentActivitiesQueryHandler : IQueryHandler<UserRecentActivityQuery, 
        UserRecentActivityQueryResult>
    {
        private readonly IMessageRepository messageRepository;

        public UserRecentActivitiesQueryHandler(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public UserRecentActivityQueryResult Execute(UserRecentActivityQuery query)
        {
            return new UserRecentActivityQueryResult()
            {
                Content = this.messageRepository.GetUserMessges(query.UserName)
            };
        
        }
    }
}
