using MediatR;
using PruebaRedarbor.Application.DTOs;

namespace PruebaRedarbor.Infrastruture.Queries.Companies
{
    public record GetRolByQuery(int Id) : IRequest<RolesDto>;
}
