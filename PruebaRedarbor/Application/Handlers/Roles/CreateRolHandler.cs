using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using PruebaRedarbor.Repositories;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class CreateRolesHandler : IRequestHandler<CreateRolCommand, RolesDto>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Roles> repository;

        public CreateRolesHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Roles>(_context);
        }

        public async Task<RolesDto> Handle(CreateRolCommand request, CancellationToken cancellationToken)
        {
            var rolItem = new Domain.Models.Roles
            {
                Name = request.Name
            };

            await repository.CreateRecord(rolItem, cancellationToken);

            return new RolesDto
            {
                Id = rolItem.Id,
                Name = rolItem.Name
            };
        }
    }
}
