using MediatR;
using PruebaRedarbor.Application.DTOs;

namespace PruebaRedarbor.Infrastruture.Queries.Companies
{
    public record GetAllCompaniesQuery : IRequest<IEnumerable<CompaniesDto>>;
}
