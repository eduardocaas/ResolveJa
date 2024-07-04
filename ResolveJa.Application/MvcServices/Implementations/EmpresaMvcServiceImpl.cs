using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ResolveJa.Application.MvcServices.Interfaces;
using ResolveJa.Application.ViewModels;
using ResolveJa.Infrastructure.Data.Persistence;
using ResolveJa.Web.MVC.Common;
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
        private readonly UserMvcServiceImpl _userMvcService;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        private readonly IServiceProvider _services;

        public EmpresaMvcServiceImpl(
            ResolveJaDbContext context, 
            UserMvcServiceImpl userMvcService,
            IPasswordHasher<IdentityUser> passwordHasher, 
            IServiceProvider services)
        {
            _context = context;
            _userMvcService = userMvcService;
            _passwordHasher = passwordHasher;
            _services = services;
        }
        
        public void CreateEmpresa(EmpresaCreateInputModel model) // Realiza persistência da Empresa e cria usuário padrão
        {
            _context.Empresas.Add(model.Empresa);
            _context.SaveChanges();

            _userMvcService.CreateGestorUser(model);
        }
    }
}
