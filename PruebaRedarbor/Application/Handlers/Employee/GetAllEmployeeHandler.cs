using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using PruebaRedarbor.Infrastruture.Queries.Companies;
using PruebaRedarbor.Repositories;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Employee> repository;

        public GetAllEmployeeHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Employee>(_context);
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var includes = new Expression<Func<Domain.Models.Employee, object>>[]
            {
                p => p.Company,
                p => p.Status,
                p => p.Role
            };
            var employees = await repository.ListRecords(cancellationToken,null, includes);

            return employees.Select(employee => new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Fax = employee.Fax,
                Telephone = employee.Telephone,
                Company = new CompaniesDto { Id = employee.Company.Id, Name = employee.Company.Name},
                Role = new RolesDto { Id = employee.Role.Id, Name = employee.Role.Name},
                Status = new StatusDto { Id = employee.Status.Id, Name = employee.Status.Name},
            });
        }
    }
}
