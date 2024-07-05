using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using PruebaRedarbor.Infrastruture.Queries.Companies;
using PruebaRedarbor.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<CompaniesDto>>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Companies> repository;

        public GetAllCompaniesHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Companies>(_context);
        }

        public async Task<IEnumerable<CompaniesDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await repository.ListRecords(cancellationToken);

            return companies.Select(company => new CompaniesDto
            {
                Id = company.Id,
                Name = company.Name
            });

        }
    }
}
