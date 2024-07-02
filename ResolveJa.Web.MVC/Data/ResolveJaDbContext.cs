/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResolveJa.Core.Entities;

namespace ResolveJa.Infrastructure.Data.Persistence
{
    public class ResolveJaDbContext : IdentityDbContext
    {
        public ResolveJaDbContext (DbContextOptions<ResolveJaDbContext> options)
            : base(options)
        {
        }

        public DbSet<ResolveJa.Core.Entities.Funcionario> Funcionario { get; set; } = default!;

        public DbSet<ResolveJa.Core.Entities.Empresa>? Empresa { get; set; }
    }
}
*/