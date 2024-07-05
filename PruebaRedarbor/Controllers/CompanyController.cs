using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Application.Handlers.Companies;
using PruebaRedarbor.Infrastruture.Queries.Companies;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using Microsoft.AspNetCore.Authorization;

namespace PruebaRedarbor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<CompaniesDto>> GetAll()
        {
            return await _mediator.Send(new GetAllCompaniesQuery());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<CompaniesDto>> GetById(int id)
        {
            var query = new GetCompanyByQuery(id);
            var companyItem = await _mediator.Send(query);

            if (companyItem == null)
            {
                return NotFound();
            }

            return companyItem;  
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CompaniesDto>> Create(CreateCompanyCommand command)
        {
            var companyItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = companyItem.Id}, companyItem);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<CompaniesDto>> Update(int id, UpdateCompanyCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }

            var companyItem = await _mediator.Send(command);
            if (companyItem == null)
            {
                return NotFound();
            }

            return Ok(companyItem);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompaniesDto>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCompanyCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
