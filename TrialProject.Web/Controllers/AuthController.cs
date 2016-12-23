using CQRS.Commands.Implementation.Exceptions;
using CQRS.Commands.Interfaces;
using CQRS.Commands.Models;
using CQRS.Queries.Implementation.Queries;
using CQRS.Queries.Interfaces;
using CQRS.Queries.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrialProject.ViewModels;
using TrialProject.Web.Hubs;

namespace TrialProject.Web.Controllers
{

    public class AuthController : ControllerBase
    {
        public AuthController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher) : base(queryDispatcher, commandDispatcher)
        {
        }

        [HttpPost]
        public HttpResponseMessage Login([FromBody]LoginVM vm)
        {           
            try
            {                
                return Request.CreateResponse(HttpStatusCode.OK, this.commandDispatcher.Execute(new UserLoginCM(vm.Email, vm.Password)));
            }
            catch (CommandDispatchException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.ValidationResult);
            }

        }

        [HttpPost]
        public HttpResponseMessage Logout([FromBody]LoginVM vm)
        {
            try
            {                
                return Request.CreateResponse(HttpStatusCode.OK, this.commandDispatcher.Execute(new UserLogoutCM(vm.Email)));
            }
            catch (CommandDispatchException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.ValidationResult);
            }

        }

    }
}