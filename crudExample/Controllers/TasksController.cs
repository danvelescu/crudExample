using crudExample.Application.Tasks.Commands;
using crudExample.Application.Tasks.Dto;
using crudExample.Application.Tasks.Quries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crudExample.Controllers
{
    [ApiController]
    [Route("api")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("task")]
        public async Task<ActionResult<int>> Create(CreateTaskCommand createTaskCommand)
        {
            var result = await _mediator.Send(createTaskCommand);
            return Ok(result);
        }

        [HttpGet("task")]
        public async Task<ActionResult<TaskDto>> GetTask([FromQuery] GetTaskByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("task/assign")]
        public async Task<ActionResult> AssignTask([FromQuery] AssignTaskToUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("task")]
        public async Task<ActionResult> DeleteTask([FromQuery] DeleteTaskByIdCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("tasks")]
        public async Task<ActionResult<List<TaskDto>>> getTasksByUserId([FromQuery] GetTasksByUserIdQuery request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
    }
}
