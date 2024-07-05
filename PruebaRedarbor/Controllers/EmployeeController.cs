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
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            return await _mediator.Send(new GetAllEmployeesQuery());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetById(int id)
        {
            var query = new GetEmployeeByQuery(id);
            var employeeItem = await _mediator.Send(query);

            if (employeeItem == null)
            {
                return NotFound();
            }

            return employeeItem;
        }

        [HttpPost]
        public async Task<ActionResult<RolesDto>> Create(CreateEmployeeCommand command)
        {
            var employeeItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = employeeItem.Id }, employeeItem);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<RolesDto>> Update(int id, UpdateEmployeeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var employeeItem = await _mediator.Send(command);
            if (employeeItem == null)
            {
                return NotFound();
            }

            return Ok(employeeItem);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDto>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<ActionResult<EmployeeDto>> Login(GetEmployeeByEmailQuery command)
        {
            var employeeItem = await _mediator.Send(command);

            if (employeeItem == null)
            {
                return NotFound();
            }

            return Ok(employeeItem);
        }

    }
}
