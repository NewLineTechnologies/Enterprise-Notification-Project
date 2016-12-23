using CQRS.Queries.Interfaces;
using CQRS.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Queries.Implementation.Queries
{
    public class UserRecentActivityQuery : IQuery<UserRecentActivityQueryResult>
    {
        public string UserName { get; private set; }       

        public UserRecentActivityQuery(string userName)
        {
            this.UserName = userName;            
        }
    }
}
