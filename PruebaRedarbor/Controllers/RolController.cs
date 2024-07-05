using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using PruebaRedarbor.Infrastruture.Queries.Companies;

namespace PruebaRedarbor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<RolesDto>> GetAll()
        {
            return await _mediator.Send(new GetAllRolesQuery());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<RolesDto>> GetById(int id)
        {
            var query = new GetRolByQuery(id);
            var rolItem = await _mediator.Send(query);

            if (rolItem == null)
            {
                return NotFound();
            }

            return rolItem;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<RolesDto>> Create(CreateRolCommand command)
        {
            var rolItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = rolItem.Id }, rolItem);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<RolesDto>> Update(int id, UpdateRolCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var rolItem = await _mediator.Send(command);
            if (rolItem == null)
            {
                return NotFound();
            }

            return Ok(rolItem);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<RolesDto>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteRolCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
