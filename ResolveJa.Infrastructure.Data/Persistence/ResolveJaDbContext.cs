using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Infrastructure.Data.Persistence
{
    public class ResolveJaDbContext : IdentityDbContext
    {
        public ResolveJaDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
