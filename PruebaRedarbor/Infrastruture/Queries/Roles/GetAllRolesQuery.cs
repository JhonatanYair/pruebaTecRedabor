using MediatR;
using PruebaRedarbor.Application.DTOs;

namespace PruebaRedarbor.Infrastruture.Queries.Companies
{
    public record GetAllRolesQuery : IRequest<IEnumerable<RolesDto>>;
}
