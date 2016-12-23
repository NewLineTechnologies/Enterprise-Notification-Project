using DL.Interfaces;
using DL.Repositories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Infrastructure.Configurations
{
    public class SimpleInjectorConfiguration
    {
        private const string connectionStringKey = "serviceBus:connectionString";
        private const string topicNameKey = "serviceBus:topicName";

        private const string dbdEndpointUri = "documentDB:endpointUri";
        private const string dbdPrimaryKey = "documentDB:primaryKey";
        private const string dbdDatabaseName = "documentDB:databaseName";
        private const string dbdCollectionName = "documentDB:collectionName";


        public static void Bind(Container container)
        {
            //Share fake data storage between all users
            container.Register<ICoreRepository, Repository>(Lifestyle.Singleton);

            var endpointUri = ConfigurationManager.AppSettings[dbdEndpointUri];
            var primaryKey = ConfigurationManager.AppSettings[dbdPrimaryKey];
            var databaseName = ConfigurationManager.AppSettings[dbdDatabaseName];
            var collectionName = ConfigurationManager.AppSettings[dbdCollectionName];

            container.Register<IMessageRepository>(() => new MessageRepository(endpointUri, primaryKey,
                databaseName, collectionName));

        }
    }
}
