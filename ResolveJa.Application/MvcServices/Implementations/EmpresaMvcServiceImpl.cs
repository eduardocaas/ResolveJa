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
            IdentityUser identityGestor = new IdentityUser();

            _context.Empresas.Add(model.Empresa);
            _context.SaveChanges();

            Guid guid = Guid.NewGuid();
            identityGestor.Id = guid.ToString();
            identityGestor.UserName = model.Empresa.Url.ToString();
            identityGestor.Email = (model.Empresa.Url.ToString() + "@email.com");
            identityGestor.NormalizedUserName = (model.Empresa.Url.ToString() + "@email.com");

            _context.Users.Add(identityGestor);

            var hashedPassword = _passwordHasher.HashPassword(identityGestor, model.SenhaGestor);
            identityGestor.SecurityStamp = Guid.NewGuid().ToString();
            identityGestor.PasswordHash = hashedPassword;

            _context.SaveChanges();
        }
    }
}
