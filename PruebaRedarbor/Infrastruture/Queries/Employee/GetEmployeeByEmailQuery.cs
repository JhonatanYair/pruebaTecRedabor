using MediatR;
using PruebaRedarbor.Application.DTOs;

namespace PruebaRedarbor.Infrastruture.Queries.Companies
{
    public record GetEmployeeByEmailQuery(string Email,string Password) : IRequest<EmployeeDto>;
}
