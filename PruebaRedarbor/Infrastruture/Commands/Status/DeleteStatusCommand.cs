using MediatR;

namespace PruebaRedarbor.Infrastruture.Commands.Companies
{
    public record DeleteStatusCommand(int Id) : IRequest<bool>;

}
