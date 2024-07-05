using MediatR;
using PruebaRedarbor.Application.DTOs;

namespace PruebaRedarbor.Infrastruture.Commands.Companies
{
    public record UpdateRolCommand(int Id,string Name): IRequest<RolesDto>;
}
