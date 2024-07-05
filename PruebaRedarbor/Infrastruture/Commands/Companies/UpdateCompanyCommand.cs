using MediatR;
using PruebaRedarbor.Application.DTOs;

namespace PruebaRedarbor.Infrastruture.Commands.Companies
{
    public record UpdateCompanyCommand(int Id,string Name): IRequest<CompaniesDto>;
}
