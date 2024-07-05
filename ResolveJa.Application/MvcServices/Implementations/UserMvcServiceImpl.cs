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

        public async Task CreateGestor(EmpresaCreateInputModel model) // Cria usuário Identity para empresa e aloca na Role Gestor
        {
            IdentityUser identityGestor = new IdentityUser();

            Guid guid = Guid.NewGuid();
            identityGestor.Id = guid.ToString();
            identityGestor.UserName = model.Empresa.Url.ToString() + "@email.com";
            identityGestor.Email = (model.Empresa.Url.ToString() + "@email.com");
            //identityGestor.NormalizedUserName = (model.Empresa.Url.ToString() + "@email.com");

            await _context.Users.AddAsync(identityGestor);

            var hashedPassword = _passwordHasher.HashPassword(identityGestor, model.SenhaGestor);
            identityGestor.SecurityStamp = Guid.NewGuid().ToString();
            identityGestor.PasswordHash = hashedPassword;

            await _context.SaveChangesAsync();

            var userManager = _services.GetRequiredService<UserManager<IdentityUser>>();
            await userManager.AddToRoleAsync(identityGestor, Roles.Gestor);
        }
    }
}
