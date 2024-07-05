using MediatR;
using PruebaRedarbor.Application.DTOs;

namespace PruebaRedarbor.Infrastruture.Queries.Companies
{
    public record GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>;
}
