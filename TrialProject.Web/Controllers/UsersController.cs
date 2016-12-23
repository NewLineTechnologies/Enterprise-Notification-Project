using CQRS.Commands.Interfaces;
using CQRS.Queries.Implementation.Queries;
using CQRS.Queries.Interfaces;
using CQRS.Queries.Models;
using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrialProject.Web.Controllers
{
    public class UsersController : ControllerBase
    {
        public UsersController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher) : base(queryDispatcher, commandDispatcher)
        {
        }

        public IEnumerable<UserRecentActivity> GetRecentActivities(string userName)
        {
            var result = this.queryDispatcher.Execute<UserRecentActivityQuery,
                UserRecentActivityQueryResult>(new UserRecentActivityQuery(userName));

            return result.Content;
        }

        public IEnumerable<UserRecentActivity> GetUnreadMessages(string userName)
        {
            var result = this.queryDispatcher.Execute<UserUnreadMessagesQuery,
                UserUnreadMessageQueryResult>(new UserUnreadMessagesQuery(userName));

            return result.Content;
        }

    }
}