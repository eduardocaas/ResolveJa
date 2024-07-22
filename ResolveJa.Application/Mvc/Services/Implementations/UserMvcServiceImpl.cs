using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ResolveJa.Application.Mvc.MvcInputModels;
using ResolveJa.Application.Mvc.Services.Interfaces;
using ResolveJa.Infrastructure.Data.Persistence;
using ResolveJa.Web.MVC.Common;

namespace ResolveJa.Application.Mvc.Services.Implementations
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
            identityGestor.UserName = model.Empresa.Url.ToString() + "@resolveja.com";
            identityGestor.Email = model.Empresa.Url.ToString() + "@resolveja.com";
            //identityGestor.NormalizedUserName = (model.Empresa.Url.ToString() + "@email.com");

            await _context.Users.AddAsync(identityGestor);

            var hashedPassword = _passwordHasher.HashPassword(identityGestor, model.SenhaGestor);
            identityGestor.SecurityStamp = Guid.NewGuid().ToString();
            identityGestor.PasswordHash = hashedPassword;

            await _context.SaveChangesAsync();

            var userManager = _services.GetRequiredService<UserManager<IdentityUser>>();
            await userManager.AddToRoleAsync(identityGestor, Roles.Gestor);
        }

        public async Task CreateFuncionario(FuncionarioCreateInputModel model)
        {
            IdentityUser identityFuncionario = new IdentityUser();

            Guid guid = Guid.NewGuid();
            identityFuncionario.Id = guid.ToString();
            identityFuncionario.UserName = model.Funcionario.Email;
            identityFuncionario.Email = model.Funcionario.Email;

            await _context.Users.AddAsync(identityFuncionario);

            var hashedPassword = _passwordHasher.HashPassword(identityFuncionario, model.SenhaFuncionario);
            identityFuncionario.SecurityStamp = Guid.NewGuid().ToString();
            identityFuncionario.PasswordHash = hashedPassword;

            await _context.SaveChangesAsync();

            var userManager = _services.GetRequiredService<UserManager<IdentityUser>>();
            await userManager.AddToRoleAsync(identityFuncionario, Roles.Funcionario);
        }
    }
}
