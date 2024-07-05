
using Microsoft.EntityFrameworkCore;
using PruebaRedarbor.Infrastruture.Configurations;
using System;
using System.Collections.Generic;
using PruebaRedarbor.Domain.Models;

namespace PruebaRedarbor.Infrastruture;

public partial class PruebaRebardorContext : DbContext
{
    public PruebaRebardorContext(DbContextOptions<PruebaRebardorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Companies> Companies { get; set; }

    public virtual DbSet<Employee> Employee { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Status> Status { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.CompaniesConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.RolesConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.StatusConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
