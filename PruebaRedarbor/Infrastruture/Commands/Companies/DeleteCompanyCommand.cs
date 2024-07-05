using MediatR;

namespace PruebaRedarbor.Infrastruture.Commands.Companies
{
    public record DeleteCompanyCommand(int Id) : IRequest<bool>;

}
