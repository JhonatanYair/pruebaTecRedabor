using MediatR;
using PruebaRedarbor.Application.Common;
using PruebaRedarbor.Application.DTOs;
using PruebaRedarbor.Infrastruture;
using PruebaRedarbor.Infrastruture.Queries.Companies;
using PruebaRedarbor.Repositories;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;

namespace PruebaRedarbor.Application.Handlers.Employee
{
    public class GetEmployeeByLoginHandler : IRequestHandler<GetEmployeeByEmailQuery, EmployeeDto>
    {
        private readonly PruebaRebardorContext _context;
        private readonly IRepository<Domain.Models.Employee> repository;

        public GetEmployeeByLoginHandler(PruebaRebardorContext context)
        {
            _context = context;
            repository = new Repository<Domain.Models.Employee>(_context);
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByEmailQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Models.Employee, bool>> query = p => p.Email == request.Email;

            var includes = new Expression<Func<Domain.Models.Employee, object>>[]
            {
                                        p => p.Company,
                                        p => p.Status,
                                        p => p.Role
            };

            var employeeItem = await repository.ListRecords(cancellationToken, query, includes);

            string passEncrypt = Encrypt.GetSHA256(request.Password);

            if (employeeItem != null && employeeItem[0].Password == passEncrypt)
            {
                employeeItem[0].LastLogin = DateTime.Now;
                await repository.UpdateRecord(employeeItem[0], cancellationToken);

                var tokenHandler = new JwtSecurityTokenHandler();
                var byteKey = Encoding.UTF8.GetBytes(AuthConfig.secretKeyJwt);
                var tokenDes = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity( new Claim[]
                    {
                        new Claim(ClaimTypes.Name,employeeItem[0].Name)
                    }),
                    Expires = DateTime.UtcNow.AddDays(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey), SecurityAlgorithms.HmacSha256Signature),
                };

                var token = tokenHandler.CreateToken(tokenDes);

                return new EmployeeDto
                {
                    Id = employeeItem[0].Id,
                    Name = employeeItem[0].Name,
                    Email = employeeItem[0].Email,
                    Fax = employeeItem[0].Fax,
                    CreatedOn = employeeItem[0].CreatedOn,  
                    LastLogin = employeeItem[0].LastLogin,
                    Token = tokenHandler.WriteToken(token),
                    Company = new CompaniesDto { Id = employeeItem[0].Company.Id, Name = employeeItem[0].Company.Name },
                    Role = new RolesDto { Id = employeeItem[0].Role.Id, Name = employeeItem[0].Role.Name },
                    Status = new StatusDto { Id = employeeItem[0].Status.Id, Name = employeeItem[0].Status.Name }
                };
            }
            else
            {
                return null;
            }

        }
    }
}
