using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQRS.Commands.Interfaces;
using CQRS.Queries.Interfaces;
using TrialProject.ViewModels;
using CQRS.Commands.Implementation.Exceptions;
using CQRS.Commands.Models;
using CQRS.Queries.Implementation.Queries;
using CQRS.Queries.Models;
using DL.Models;

namespace TrialProject.Web.Controllers
{
    public class TasksController : ControllerBase
    {
        public TasksController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher) : base(queryDispatcher, commandDispatcher)
        {
        }


        [HttpPost]
        public HttpResponseMessage TakeTask([FromBody]TaskBaseVM message)
        {
            try
            {                
                return Request.CreateResponse(HttpStatusCode.OK, this.commandDispatcher.Execute(new TakeTaskCM(message.Sender, message.TaskUuid)));
            }
            catch (CommandDispatchException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.ValidationResult);
            }
        }

        [HttpPost]
        public HttpResponseMessage FinishTask([FromBody]TaskBaseVM message)
        {
            try
            {              
                return Request.CreateResponse(HttpStatusCode.OK, this.commandDispatcher.Execute(new FinishTaskCM(message.Sender, message.TaskUuid)));
            }
            catch (CommandDispatchException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.ValidationResult);
            }
        }

        [HttpPost]
        public HttpResponseMessage LeaveCommentOnTask([FromBody]LeaveCommentOnTaskVM message)
        {
            try
            {                
                return Request.CreateResponse(HttpStatusCode.OK, this.commandDispatcher.Execute(new LeaveCommentOnTaskCM(message.Sender, message.TaskUuid, message.Comment)));
            }
            catch (CommandDispatchException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.ValidationResult);
            }
        }      

        [HttpGet]
        public IEnumerable<CommentEntity> GetTaskComments(string taskId)
        {
            var result = this.queryDispatcher.Execute<CommentQuery,
                CommentsQueryResult>(new CommentQuery(taskId));

            return result.Content;
        }
    }
}