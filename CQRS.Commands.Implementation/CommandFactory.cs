using CQRS.Commands.Models;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Implementation
{
    public class CommandTypeResolver
    {
        public static Type GetCommandType(CommandType commandType)
        {
            switch (commandType)
            {
                case CommandType.UserLogin:
                    return typeof(UserLoginCM);
                case CommandType.UserLogOut:
                    return typeof(UserLogoutCM);
                case CommandType.TakeTask:
                    return typeof(TakeTaskCM);
                case CommandType.FinishTask:
                    return typeof(FinishTaskCM);
                case CommandType.LeaveCommentOnTask:
                    return typeof(LeaveCommentOnTaskCM);
                case CommandType.MessageUser:
                    return typeof(MessageUserCM);
                default:
                    throw new KeyNotFoundException();
            }
        }
    }
}
