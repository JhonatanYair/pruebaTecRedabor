using MediatR;
using PruebaRedarbor.Application.DTOs;

namespace PruebaRedarbor.Infrastruture.Commands.Companies
{
    public record UpdateStatusCommand(int Id,string Name): IRequest<StatusDto>;
}
