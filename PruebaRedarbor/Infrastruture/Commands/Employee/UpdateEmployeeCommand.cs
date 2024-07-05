using MediatR;
using PruebaRedarbor.Application.DTOs;

namespace PruebaRedarbor.Infrastruture.Commands.Companies
{
    public record UpdateEmployeeCommand(int Id ,string Name, string Email, string Telephone, string Fax, int PortalId, int CompanyId, int RoleId, int StatusId) : IRequest<EmployeeDto>;
}
