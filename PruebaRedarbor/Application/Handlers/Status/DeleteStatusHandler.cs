using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using PruebaRedarbor.Repositories;
using System.Linq.Expressions;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class DeleteStatusHandler : IRequestHandler<DeleteStatusCommand, bool>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Status> repository;

        public DeleteStatusHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Status>(_context);
        }

        public async Task<bool> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Models.Status, bool>> query = p => p.Id == request.Id;

            var statusItem = await repository.ListRecords(cancellationToken, query);

            if (statusItem == null)
            {
                return false;
            }

            await repository.DeleteRecord(request.Id,cancellationToken);

            return true;
        }
    }
}
