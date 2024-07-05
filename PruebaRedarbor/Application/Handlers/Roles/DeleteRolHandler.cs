using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using PruebaRedarbor.Repositories;
using System.Linq.Expressions;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class DeleteRolHandler : IRequestHandler<DeleteRolCommand, bool>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Roles> repository;

        public DeleteRolHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Roles>(_context);
        }

        public async Task<bool> Handle(DeleteRolCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Models.Roles, bool>> query = p => p.Id == request.Id;

            var rolItem = await repository.ListRecords(cancellationToken, query);

            if (rolItem == null)
            {
                return false;
            }

            await repository.DeleteRecord(request.Id,cancellationToken);

            return true;
        }
    }
}
