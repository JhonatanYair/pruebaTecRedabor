using System;
using System.Collections.Generic;

namespace PruebaRedarbor.Domain.Models;

public partial class Companies
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Employee> Employee { get; set; } = new List<Employee>();
}
