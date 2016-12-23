using DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;

namespace DL.Repositories
{
    public class Repository : ICoreRepository
    {
        private IList<UserEntity> users;
        private IList<TaskEntity> tasks;

        public Repository()
        {
            this.users = new List<UserEntity>()
            {
                new UserEntity()
                {
                    Email = "testuser1@test.com",
                    Password = "123456789"
                },
                   new UserEntity()
                {
                    Email = "testuser2@test.com",
                    Password = "123456789"
                }
            };

            this.tasks = new List<TaskEntity>()
            {
                new TaskEntity()
                {
                   Id = "task1"
                },
                new TaskEntity()
                {
                   Id = "task2"
                }
            };
        }

        public UserEntity GetUserByEmail(string email)
        {
            return this.users.SingleOrDefault(x => x.Email == email);
        }

        public void AddComment(string taskId, string text)
        {
            var task = this.tasks.FirstOrDefault(x => x.Id == taskId);
            task.Comments.Add(new CommentEntity()
            {
                Text = text
            });            
        }

        public bool IsTaskExists(string taskId)
        {
            return this.tasks.Any(x => x.Id == taskId);
        }

        public IList<CommentEntity> GetTaskComments(string taskId)
        {
            return this.tasks.Single(x => x.Id == taskId).Comments;
        }
    }
}
