using CQRS.Queries.Interfaces;
using System;
using System.Collections.Generic;

namespace CQRS.Queries.Implementation
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TResult Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            var handler = _serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResult>)) as
                IQueryHandler<TQuery, TResult>;

            if (handler == null)
            {
                throw new KeyNotFoundException(typeof(TQuery).ToString());
            }

            return handler.Execute(query);
        }
    }
}
