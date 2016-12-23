using DL.Interfaces;
using DL.Models;
using Enums;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly string databaseName;
        private readonly string collectionName;

        private DocumentClient client;

        public MessageRepository(string endpointUri, string primaryKey, string databaseName, string collectionName)
        {
            this.client = new DocumentClient(new Uri(endpointUri), primaryKey);
            this.databaseName = databaseName;
            this.collectionName = collectionName;
        }

        public async Task AddMessage(Message message)
        {
            await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), message);
        }

        public IList<UserRecentActivity> GetUserMessges(string email)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            return this.client.CreateDocumentQuery<Message>(
               UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), queryOptions)
               .Where(f => f.Sender == email)
               .Select(x => new UserRecentActivity()
               {
                   Id = x.Id,
                   DateTime = x.DateTime,
                   Type = x.Type,
                   Text = x.Text

               }).ToList();
        }

        public IList<UserRecentActivity> GetUserMessgesSinceLastLogout(string email)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            var lastLogoutEvent = this.client.CreateDocumentQuery<Message>(
               UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), queryOptions)
               .Where(f => f.Sender == email && f.Type == CommandType.UserLogOut.ToString())
               .OrderByDescending(x => x.DateTime).ToList().FirstOrDefault();


            if (lastLogoutEvent == null)
            {
                return new List<UserRecentActivity>();
            }

            return this.client.CreateDocumentQuery<Message>(
               UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), queryOptions)
               .Where(f => f.Recipient == email && f.DateTime > lastLogoutEvent.DateTime)
               .Select(x => new UserRecentActivity()
               {
                   Id = x.Id,
                   DateTime = x.DateTime,
                   Type = x.Type,
                   Text = x.Text
               }).ToList();
        }
    }
}
