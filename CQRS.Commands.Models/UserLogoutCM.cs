using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace CQRS.Commands.Models
{
    [Serializable]
    public class UserLogoutCM : CommandBase
    {
        public string Email { get; private set; }      

        public override CommandType CommandType
        {
            get
            {
                return CommandType.UserLogin;
            }
        }

        public override string Message
        {
            get
            {
                return $"User {this.Email} was logged out";
            }
        }

        public UserLogoutCM(string email)
        {
            this.Sender = this.Email = email;           
        }
    }
}
