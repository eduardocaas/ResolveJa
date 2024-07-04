using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ResolveJa.Application.MvcServices.Interfaces;
using ResolveJa.Application.ViewModels;
using ResolveJa.Infrastructure.Data.Persistence;
using ResolveJa.Web.MVC.Common;

namespace ResolveJa.Application.MvcServices.Implementations
{
    public class UserMvcServiceImpl : IUserMvcService
    {
        private readonly ResolveJaDbContext _context;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        private readonly IServiceProvider _services;

        
        public UserMvcServiceImpl(
            ResolveJaDbContext context, 
            IPasswordHasher<IdentityUser> passwordHasher,
            IServiceProvider services)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _services = services;
        }

        public void CreateGestorUser(EmpresaCreateInputModel model) // Cria usuário Identity para empresa e aloca na Role Gestor
        {
            IdentityUser identityGestor = new IdentityUser();

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

            var userManager = _services.GetRequiredService<UserManager<IdentityUser>>();
            userManager.AddToRoleAsync(identityGestor, Roles.Gestor);
        }
    }
}
