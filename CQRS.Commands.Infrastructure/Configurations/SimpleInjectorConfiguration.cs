using CQRS.Commands.Implementation;
using CQRS.Commands.Implementation.Handlers;
using CQRS.Commands.Interfaces;
using CQRS.Commands.Models;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Infrastructure.Configurations
{
    public class SimpleInjectorConfiguration
    {
        private const string connectionStringKey = "serviceBus:connectionString";
        private const string topicNameKey = "serviceBus:topicName";

        public static void Bind(Container container)
        {
            var connectionString = ConfigurationManager.AppSettings[connectionStringKey];
            var topicName = ConfigurationManager.AppSettings[topicNameKey];

            container.Register<IAzureCommandQueue>(() => new  AzureCommandQueue(connectionString, topicName));
            
            container.Register<ICommandDispatcher>(() => new CommandDispatcher(container, container.GetInstance<IAzureCommandQueue>()));

            container.Register<ICommandHandler<UserLoginCM>, UserLoginCommandHandler>();
            container.Register<ICommandHandler<UserLogoutCM>, UserLogoutCommandHandler>();
            container.Register<ICommandHandler<TakeTaskCM>, TakeTaskCommandHandler>();
            container.Register<ICommandHandler<MessageUserCM>, MessageUserCommandHandler>();
            container.Register<ICommandHandler<LeaveCommentOnTaskCM>, LeaveCommentCommandHandler>();
            container.Register<ICommandHandler<FinishTaskCM>, FinishTaskCommandHandler>();
        }
    }
}
