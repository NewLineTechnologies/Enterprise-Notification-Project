using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Interfaces
{
    public interface IMessageRepository
    {
        Task AddMessage(Message message);

        IList<UserRecentActivity> GetUserMessges(string email);

        IList<UserRecentActivity> GetUserMessgesSinceLastLogout(string email);
    }
}
