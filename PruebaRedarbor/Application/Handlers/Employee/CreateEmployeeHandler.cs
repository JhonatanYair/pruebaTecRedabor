using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using PruebaRedarbor.Repositories;
using PruebaRedarbor.Application.Common;
using PruebaRedarbor.Domain.Models;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Employee> repository;

        public CreateEmployeeHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Employee>(_context);
        }

        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeItem = new Domain.Models.Employee
            {
                Name = request.Name,
                Email = request.Email,
                Fax = request.Fax,
                Telephone = request.Telephone,
                Password = Encrypt.GetSHA256(request.Password),
                CompanyId = request.CompanyId,
                PortalId = request.PortalId,
                StatusId = request.StatusId,
                RoleId = request.RoleId
            };

            await repository.CreateRecord(employeeItem, cancellationToken);

            return new EmployeeDto
            {
                Id = employeeItem.Id,
                Name = employeeItem.Name,
                Email = employeeItem.Email,
                Fax = employeeItem.Fax,
                Telephone = employeeItem.Telephone,
                //Company = new CompaniesDto { Id = employeeItem.Company.Id, Name = employeeItem.Company.Name },
                //Role = new RolesDto { Id = employeeItem.Role.Id, Name = employeeItem.Role.Name },
                //Status = new StatusDto { Id = employeeItem.Status.Id, Name = employeeItem.Status.Name },
            };
        }
    }
}
