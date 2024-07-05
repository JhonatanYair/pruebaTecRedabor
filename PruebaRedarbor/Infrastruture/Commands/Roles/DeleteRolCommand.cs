using MediatR;

namespace PruebaRedarbor.Infrastruture.Commands.Companies
{
    public record DeleteRolCommand(int Id) : IRequest<bool>;

}
