using CQRS.Queries.Interfaces;
using CQRS.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Queries.Implementation.Queries
{
    public class UserUnreadMessagesQuery : IQuery<UserUnreadMessageQueryResult>
    {
        public string UserName { get; private set; }       

        public UserUnreadMessagesQuery(string userName)
        {
            this.UserName = userName;            
        }
    }
}
