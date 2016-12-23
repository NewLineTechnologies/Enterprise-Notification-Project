using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Models
{
    public class UserRecentActivity
    {
        public string Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }
    }
}
