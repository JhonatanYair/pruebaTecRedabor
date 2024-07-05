using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using PruebaRedarbor.Infrastruture;
using Microsoft.EntityFrameworkCore;


namespace TestUnitPruebaRedarbor.Shared
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        private readonly string connectionBDTestLocal = "Data Source=localhost,1435;Initial Catalog=PruebaRebardorTest;Integrated Security=False;User ID=sa;Password=redarbor123#;Encrypt=False;Trust Server Certificate=True;";

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<PruebaRebardorContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<PruebaRebardorContext>(options =>
                {
                    options.UseSqlServer(connectionBDTestLocal);
                });
            });
        }
    }
}
