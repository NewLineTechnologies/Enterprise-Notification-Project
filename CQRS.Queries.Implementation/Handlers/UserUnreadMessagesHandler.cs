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
    public class UserUnreadMessagesHandler : IQueryHandler<UserUnreadMessagesQuery, UserUnreadMessageQueryResult>
    {
        private readonly IMessageRepository messageRepository;

        public UserUnreadMessagesHandler(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public UserUnreadMessageQueryResult Execute(UserUnreadMessagesQuery query)
        {
            return new UserUnreadMessageQueryResult()
            {
                Content = this.messageRepository.GetUserMessgesSinceLastLogout(query.UserName)
            };
        
        }
    }
}
