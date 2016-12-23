using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Queries.Models
{
    public class QueryResultBase<T>
    {
        public T Content { get; set; }
    }
}
