using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using PruebaRedarbor.Repositories;
using System.Linq.Expressions;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class UpdateRolHandler : IRequestHandler<UpdateRolCommand, RolesDto>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Roles> repository;

        public UpdateRolHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Roles>(_context);
        }

        public async Task<RolesDto> Handle(UpdateRolCommand request, CancellationToken cancellationToken)
        {

            Expression<Func<Domain.Models.Roles, bool>> query = p => p.Id == request.Id;

            var rolItem = await repository.ListRecords(cancellationToken,query);

            if(rolItem == null)
            {
                return null;
            }

            rolItem[0].Name = request.Name;

            await repository.UpdateRecord(rolItem[0], cancellationToken);

            return new RolesDto
            {
                Id = rolItem[0].Id,
                Name = rolItem[0].Name
            };

        }
    }
}
