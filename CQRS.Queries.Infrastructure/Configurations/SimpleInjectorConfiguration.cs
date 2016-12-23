using CQRS.Queries.Implementation;
using CQRS.Queries.Implementation.Handlers;
using CQRS.Queries.Implementation.Queries;
using CQRS.Queries.Interfaces;
using CQRS.Queries.Models;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Queries.Infrastructure.Configurations
{
    public class SimpleInjectorConfiguration
    {
        public static void Bind(Container container) {
            container.Register<IQueryDispatcher>(() => new  QueryDispatcher(container));
                        
            container.Register<IQueryHandler<UserRecentActivityQuery, UserRecentActivityQueryResult>, UserRecentActivitiesQueryHandler>();
            container.Register<IQueryHandler<UserUnreadMessagesQuery, UserUnreadMessageQueryResult>, UserUnreadMessagesHandler>();
        }
    }
}
