using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Domain.Models;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Queries.Companies;
using PruebaRedarbor.Repositories;
using System.Linq.Expressions;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByQuery, EmployeeDto>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Employee> repository;

        public GetEmployeeByIdHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Employee>(_context);
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Models.Employee, bool>> query = p => p.Id == request.Id;
            var includes = new Expression<Func<Domain.Models.Employee, object>>[]
            {
                            p => p.Company,
                            p => p.Status,
                            p => p.Role
            };
            var employeeItem = await repository.ListRecords(cancellationToken, query, includes);

            if (employeeItem == null)
            {
                return null;
            }

            return new EmployeeDto
            {
                Id = employeeItem[0].Id,
                Name = employeeItem[0].Name,
                Email = employeeItem[0].Email,
                Fax = employeeItem[0].Fax,
                Telephone = employeeItem[0].Telephone,
                Company = new CompaniesDto { Id = employeeItem[0].Company.Id, Name = employeeItem[0].Company.Name },
                Role = new RolesDto { Id = employeeItem[0].Role.Id, Name = employeeItem[0].Role.Name },
                Status = new StatusDto { Id = employeeItem[0].Status.Id, Name = employeeItem[0].Status.Name },
            };

        }
    }
}
