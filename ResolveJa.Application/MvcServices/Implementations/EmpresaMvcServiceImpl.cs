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

        public EmpresaMvcServiceImpl(
            ResolveJaDbContext context, 
            UserMvcServiceImpl userMvcService)
        {
            _context = context;
            _userMvcService = userMvcService;
        }
        
        public void CreateEmpresa(EmpresaCreateInputModel model) // Realiza persistência da Empresa e cria usuário padrão
        {
            _context.Empresas.Add(model.Empresa);
            _context.SaveChanges();

            _userMvcService.CreateGestorUser(model);
        }
    }
}
