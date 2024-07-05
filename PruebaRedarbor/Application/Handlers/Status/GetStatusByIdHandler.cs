using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Queries.Companies;
using PruebaRedarbor.Repositories;
using System.Linq.Expressions;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class GetStatusByIdHandler : IRequestHandler<GetStatusByQuery, StatusDto>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Status> repository;

        public GetStatusByIdHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Status>(_context);
        }

        public async Task<StatusDto> Handle(GetStatusByQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Models.Status, bool>> query = p => p.Id == request.Id;

            var statusItem = await repository.ListRecords(cancellationToken, query);

            if (statusItem == null)
            {
                return null;
            }

            return new StatusDto
            {
                Id = statusItem[0].Id,
                Name = statusItem[0].Name
            };
        }
    }
}
