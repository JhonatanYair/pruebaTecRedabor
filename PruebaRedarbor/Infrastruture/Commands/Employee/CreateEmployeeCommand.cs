using MediatR;
using PruebaRedarbor.Application.DTOs;
using System.ComponentModel.Design;

namespace PruebaRedarbor.Infrastruture.Commands.Companies
{
    public record CreateEmployeeCommand(string Name,string Email, string Telephone, string Fax, string Password,int PortalId,int CompanyId, int RoleId,int StatusId) : IRequest<EmployeeDto>;
}
