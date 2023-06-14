using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiGitUsers.Applications.Users.Queries;

namespace WebApiGitUsers.Controllers
{
    [Route("User")]
    [ApiController]
    public class GitApiUserController : ControllerBase
    {
        private readonly IMediator  _mediator;
        public GitApiUserController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost("retrieveUsers")]
        public async Task<IActionResult> RetrieveUsers([FromBody] GetUsersQuery request)
        {
            try
            {
                var result = await _mediator.Send(request);
                return result.Count > 0 ? Ok(result) : NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
         
        }
    }
}
