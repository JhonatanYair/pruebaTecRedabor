using MediatR;
using PruebaRedarbor.Application.DTOs;

namespace PruebaRedarbor.Infrastruture.Queries.Companies
{
    public record GetCompanyByQuery(int Id) : IRequest<CompaniesDto>;
}
