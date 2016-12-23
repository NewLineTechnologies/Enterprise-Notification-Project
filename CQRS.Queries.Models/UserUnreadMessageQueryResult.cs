using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Queries.Models
{
    public class UserUnreadMessageQueryResult : QueryListResultBase<UserRecentActivity>
    {
        public string Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }
    }
}
