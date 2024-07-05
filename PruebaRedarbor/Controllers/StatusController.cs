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
    public class StatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<StatusDto>> GetAll()
        {
            return await _mediator.Send(new GetAllStatusQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusDto>> GetById(int id)
        {
            var query = new GetStatusByQuery(id);
            var statusItem = await _mediator.Send(query);

            if (statusItem == null)
            {
                return NotFound();
            }

            return statusItem;
        }

        [HttpPost]
        public async Task<ActionResult<StatusDto>> Create(CreateStatusCommand command)
        {
            var statusItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = statusItem.Id }, statusItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StatusDto>> Update(int id, UpdateStatusCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var statusItem = await _mediator.Send(command);
            if (statusItem == null)
            {
                return NotFound();
            }

            return Ok(statusItem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StatusDto>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteStatusCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
