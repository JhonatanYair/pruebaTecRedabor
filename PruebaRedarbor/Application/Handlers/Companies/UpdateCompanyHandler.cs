using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using PruebaRedarbor.Repositories;
using System.Linq.Expressions;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, CompaniesDto>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Companies> repository;

        public UpdateCompanyHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Companies>(_context);
        }

        public async Task<CompaniesDto> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {

            Expression<Func<Domain.Models.Companies, bool>> query = p => p.Id == request.Id;

            var companyItem = await repository.ListRecords(cancellationToken,query);

            if(companyItem == null)
            {
                return null;
            }

            companyItem[0].Name = request.Name;

            await repository.UpdateRecord(companyItem[0], cancellationToken);

            return new CompaniesDto
            {
                Id = companyItem[0].Id,
                Name = companyItem[0].Name
            };

        }
    }
}
