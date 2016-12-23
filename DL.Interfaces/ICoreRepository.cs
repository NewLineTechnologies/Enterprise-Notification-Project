using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Interfaces
{
    public interface ICoreRepository
    {
        UserEntity GetUserByEmail(string email);

        void AddComment(string taskId, string text);

        bool IsTaskExists(string taskId);

        IList<CommentEntity> GetTaskComments(string taskId);
    }
}
