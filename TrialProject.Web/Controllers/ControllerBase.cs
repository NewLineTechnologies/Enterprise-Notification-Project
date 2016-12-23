using CQRS.Commands.Interfaces;
using CQRS.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace TrialProject.Web.Controllers
{
    public abstract class ControllerBase : ApiController
    {
        protected readonly IQueryDispatcher queryDispatcher;
        protected readonly ICommandDispatcher commandDispatcher;

        public ControllerBase(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
            this.commandDispatcher = commandDispatcher;
        }
    }
}