using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Queries.Companies;
using PruebaRedarbor.Repositories;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class GetAllStatusHandler : IRequestHandler<GetAllStatusQuery, IEnumerable<StatusDto>>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Status> repository;

        public GetAllStatusHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Status>(_context);
        }

        public async Task<IEnumerable<StatusDto>> Handle(GetAllStatusQuery request, CancellationToken cancellationToken)
        {
            var statuses = await repository.ListRecords(cancellationToken);

            return statuses.Select(status => new StatusDto
            {
                Id = status.Id,
                Name = status.Name
            });
        }
    }
}
