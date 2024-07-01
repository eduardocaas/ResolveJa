using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Infrastructure.Data.Persistence
{
    public class ResolveJaDbContextFactory
    {
        public ResolveJaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ResolveJaDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Trusted_Connection=True;TrustServerCertificate=True;Database=ResolveJa_Test;");

            return new ResolveJaDbContext(optionsBuilder.Options);
        }
    }
}
