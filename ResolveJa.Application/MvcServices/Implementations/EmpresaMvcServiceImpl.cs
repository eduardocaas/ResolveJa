using Microsoft.AspNetCore.Identity;
using ResolveJa.Application.MvcServices.Interfaces;
using ResolveJa.Application.ViewModels;
using ResolveJa.Infrastructure.Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Application.MvcServices.Implementations
{
    public class EmpresaMvcServiceImpl : IEmpresaMvcService
    {
        private readonly ResolveJaDbContext _context;
        public readonly IPasswordHasher<IdentityUser> _passwordHasher;

        public EmpresaMvcServiceImpl(ResolveJaDbContext context, IPasswordHasher<IdentityUser> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public void CreateEmpresa(EmpresaCreateInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}
