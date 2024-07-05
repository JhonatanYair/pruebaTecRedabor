using MediatR;
using PruebaRedarbor.Application.Common;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using PruebaRedarbor.Repositories;
using System.Linq.Expressions;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Employee> repository;

        public UpdateEmployeeHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Employee>(_context);
        }

        public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {

            Expression<Func<Domain.Models.Employee, bool>> query = p => p.Id == request.Id;

            var employeeItem = await repository.ListRecords(cancellationToken,query);

            if(employeeItem == null)
            {
                return null;
            }

            employeeItem[0].Name = request.Name;

            await repository.UpdateRecord(employeeItem[0], cancellationToken);

            return new EmployeeDto
            {
                Id = employeeItem[0].Id,
                Name = employeeItem[0].Name,
                Email = request.Email,
                Fax = request.Fax,
                Telephone = request.Telephone,
                CompanyId = request.CompanyId,
                PortalId = request.PortalId,
                StatusId = request.StatusId,
                RoleId = request.RoleId
            };

        }
    }
}
