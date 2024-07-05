﻿using ResolveJa.Application.MvcServices.Interfaces;
using ResolveJa.Application.ViewModels;
using ResolveJa.Infrastructure.Data.Persistence;
namespace ResolveJa.Application.MvcServices.Implementations
{
    public class EmpresaMvcServiceImpl : IEmpresaMvcService
    {
        private readonly ResolveJaDbContext _context;
        private readonly IUserMvcService _userMvcService;

        public EmpresaMvcServiceImpl(
            ResolveJaDbContext context, 
            IUserMvcService userMvcService)
        {
            _context = context;
            _userMvcService = userMvcService;
        }
        
        public void CreateEmpresa(EmpresaCreateInputModel model) // Realiza persistência da Empresa e cria usuário padrão
        {
            _context.Empresas.Add(model.Empresa);
            _context.SaveChanges();

            _userMvcService.CreateGestor(model);
        }
    }
}
