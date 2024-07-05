using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using PruebaRedarbor.Infrastruture.Queries.Companies;
using PruebaRedarbor.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<RolesDto>>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Roles> repository;

        public GetAllRolesHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Roles>(_context);
        }

        public async Task<IEnumerable<RolesDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await repository.ListRecords(cancellationToken);

            return roles.Select(company => new RolesDto
            {
                Id = company.Id,
                Name = company.Name
            });
        }
    }
}
