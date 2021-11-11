using crudExample.Application.Users.Commands;
using crudExample.Application.Users.Dto;
using crudExample.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crudExample.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("user")]
        public async Task<ActionResult<int>> Create(CreateUserCommand createUserCommand)
        {
            var result = await _mediator.Send(createUserCommand);
            return Ok(result);
        }

        [HttpGet("user")]
        public async Task<ActionResult<UserDto>> GetUser([FromQuery] GetUserByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("user")]
        public async Task<ActionResult<string>> DeleteUser(DeleteUserByIdCommand deleteUserByIdCommand)
        {
            var result = await _mediator.Send(deleteUserByIdCommand);
            return NoContent();
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<UserDto>>> GetUsers([FromQuery] GetPaginatedUsersQuery query)
        {
            var result = await _mediator.Send(query);
            return result;
        }


        [HttpPut("user")]
        public async Task<ActionResult<UserDto>> UpdateUser(UpdateUserCommand request) {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
