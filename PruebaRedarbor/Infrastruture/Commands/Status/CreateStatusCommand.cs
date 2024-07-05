using MediatR;
using PruebaRedarbor.Application.DTOs;

namespace PruebaRedarbor.Infrastruture.Commands.Companies
{
    public record CreateStatusCommand(string Name): IRequest<StatusDto>;
}
