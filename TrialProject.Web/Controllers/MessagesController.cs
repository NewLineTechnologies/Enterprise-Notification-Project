using CQRS.Commands.Implementation.Exceptions;
using CQRS.Commands.Interfaces;
using CQRS.Commands.Models;
using CQRS.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrialProject.ViewModels;

namespace TrialProject.Web.Controllers
{
    public class MessagesController : ControllerBase
    {
        public MessagesController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher) : base(queryDispatcher, commandDispatcher)
        {
        }

        [HttpPost]
        public HttpResponseMessage SendMessage([FromBody]MessageUserVM message)
        {
            try
            {                
                return Request.CreateResponse(HttpStatusCode.OK, this.commandDispatcher.Execute(new MessageUserCM(message.Sender, message.Recipient, message.MessageText)));
            }
            catch (CommandDispatchException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.ValidationResult);
            }
        }
    }
}