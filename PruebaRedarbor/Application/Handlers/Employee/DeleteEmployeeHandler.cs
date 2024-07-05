using MediatR;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Commands.Companies;
using PruebaRedarbor.Repositories;
using System.Linq.Expressions;

namespace PruebaRedarbor.Application.Handlers.Companies
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Employee> repository;

        public DeleteEmployeeHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Employee>(_context);
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Models.Employee, bool>> query = p => p.Id == request.Id;

            var employeeItem = await repository.ListRecords(cancellationToken, query);

            if (employeeItem == null)
            {
                return false;
            }

            await repository.DeleteRecord(request.Id,cancellationToken);

            return true;

        }
    }
}
