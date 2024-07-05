using MediatR;
using PruebaRedarbor.Application.DTOs;

namespace PruebaRedarbor.Infrastruture.Commands.Companies
{
    public record CreateRolCommand(string Name): IRequest<RolesDto>;
}
