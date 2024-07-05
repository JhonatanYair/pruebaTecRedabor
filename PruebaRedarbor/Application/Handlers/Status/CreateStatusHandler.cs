using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using PruebaRedarbor.Repositories;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class CreateStatusHandler : IRequestHandler<CreateStatusCommand, StatusDto>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Status> repository;

        public CreateStatusHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Status>(_context);
        }

        public async Task<StatusDto> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            var statusItem = new Domain.Models.Status
            {
                Name = request.Name
            };

            await repository.CreateRecord(statusItem, cancellationToken);

            return new StatusDto
            {
                Id = statusItem.Id,
                Name = statusItem.Name
            };
        }
    }
}
