using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Core.Application.Features.Auth.Command;
using PruebaTecnica.Core.Domain.Entities;

namespace PruebaTecnica.IU.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;

        public AuthController(ILogger<AuthController> logger, IMediator mediator)
        {
            this._logger = logger;
            this._mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserCreateCommand user)
        {
            var response = await _mediator.Send(user);

            return Ok(response);
        }
        
        [HttpPost("Login")]
        public async Task<ActionResult<ResponseLogin>> Login([FromBody] LoginCommand user)
        {
            var response = await _mediator.Send(user);

            return Ok(response);
        }
    }
}
