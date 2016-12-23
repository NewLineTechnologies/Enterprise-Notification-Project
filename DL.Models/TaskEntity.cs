using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Models
{
    public class TaskEntity
    {
        public string Id { get; set; }

        public IList<CommentEntity> Comments { get; set;  }

        public TaskEntity()
        {
            this.Comments = new List<CommentEntity>();
        }
    }
}
