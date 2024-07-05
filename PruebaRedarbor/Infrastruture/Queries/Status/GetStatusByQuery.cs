using MediatR;
using PruebaRedarbor.Application.DTOs;

namespace PruebaRedarbor.Infrastruture.Queries.Companies
{
    public record GetStatusByQuery(int Id) : IRequest<StatusDto>;
}
