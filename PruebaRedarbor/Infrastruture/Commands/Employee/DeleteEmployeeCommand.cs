using MediatR;

namespace PruebaRedarbor.Infrastruture.Commands.Companies
{
    public record DeleteEmployeeCommand(int Id) : IRequest<bool>;

}
