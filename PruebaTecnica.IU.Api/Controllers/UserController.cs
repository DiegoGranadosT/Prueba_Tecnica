using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Core.Application.Contracts.Persistence.Base;
using PruebaTecnica.Core.Domain.Entities;

namespace PruebaTecnica.IU.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User, int> _repository;

        public UserController(IRepository<User, int> repository)
        {
            this._repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id) 
        {
            var user = _repository.GetByIdAsync(id);
            if (user == null) return BadRequest("No se encontro el usuario");
            return Ok(user);
        }
    }
}
