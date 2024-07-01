using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Infrastructure.Data.Persistence
{
    public class ResolveJaDbContextFactory : IDesignTimeDbContextFactory<ResolveJaDbContext>
    {
        public ResolveJaDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
                

            var optionsBuilder = new DbContextOptionsBuilder<ResolveJaDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("LocalConnectionTest"));

            return new ResolveJaDbContext(optionsBuilder.Options);
        }
    }
}
