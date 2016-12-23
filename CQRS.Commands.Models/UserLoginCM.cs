using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace CQRS.Commands.Models
{
    [Serializable]
    public class UserLoginCM : CommandBase
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

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
                return $"User {this.Email} was logged in";
            }
        }

        public UserLoginCM(string email, string password)
        {
            this.Sender = this.Email = email;
            this.Password = password;
        }
    }
}
