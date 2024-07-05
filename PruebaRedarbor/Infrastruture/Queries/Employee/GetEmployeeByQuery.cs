using MediatR;
using PruebaRedarbor.Application.DTOs;

namespace PruebaRedarbor.Infrastruture.Queries.Companies
{
    public record GetEmployeeByQuery(int Id) : IRequest<EmployeeDto>;
}
