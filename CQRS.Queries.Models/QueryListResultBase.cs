using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Queries.Models
{
    public class QueryListResultBase<T> : QueryResultBase<IList<T>>
    {        
    }
}
