using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using PruebaRedarbor.Repositories;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CompaniesDto>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Companies> repository;

        public CreateCompanyHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Companies>(_context);
        }

        public async Task<CompaniesDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyItem = new Domain.Models.Companies
            {
                Name = request.Name
            };

            await repository.CreateRecord(companyItem,cancellationToken);

            return new CompaniesDto
            {
                Id = companyItem.Id,
                Name = companyItem.Name
            };

        }
    }
}
