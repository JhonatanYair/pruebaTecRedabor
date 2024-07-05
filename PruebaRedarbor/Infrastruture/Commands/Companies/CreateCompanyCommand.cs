using MediatR;
using PruebaRedarbor.Application.DTOs;

namespace PruebaRedarbor.Infrastruture.Commands.Companies
{
    public record CreateCompanyCommand(string Name): IRequest<CompaniesDto>;
}
