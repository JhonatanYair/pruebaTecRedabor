using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using PruebaRedarbor.Repositories;
using System.Linq.Expressions;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, bool>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Companies> repository;

        public DeleteCompanyHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Companies>(_context);
        }

        public async Task<bool> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Models.Companies, bool>> query = p => p.Id == request.Id;

            var companyItem = await repository.ListRecords(cancellationToken, query);

            if (companyItem == null)
            {
                return false;
            }

            await repository.DeleteRecord(request.Id,cancellationToken);

            return true;

        }
    }
}
