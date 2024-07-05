using System;
using System.Collections.Generic;

namespace PruebaRedarbor.Domain.Models;

public partial class Employee
{
    public int Id { get; set; }

    public int? CompanyId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public string? Email { get; set; }

    public string? Fax { get; set; }

    public string? Name { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? Password { get; set; }

    public int? PortalId { get; set; }

    public int? RoleId { get; set; }

    public int? StatusId { get; set; }

    public string? Telephone { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual Companies? Company { get; set; }

    public virtual Roles? Role { get; set; }

    public virtual Status? Status { get; set; }
}
