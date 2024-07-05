using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Application.MvcServices.Interfaces;
using ResolveJa.Application.ViewModels;
using ResolveJa.Core.Entities;
using ResolveJa.Infrastructure.Data.Persistence;

namespace ResolveJa.Application.MvcServices.Implementations
{
    public class FuncionarioMvcServiceImpl : IFuncionarioMvcService
    {
        private readonly ResolveJaDbContext _context;

        public FuncionarioMvcServiceImpl(ResolveJaDbContext context)
        {
            _context = context;
        }

        public async Task CreateGestor(EmpresaCreateInputModel model)
        {
            Funcionario funcionario = new Funcionario();
            Empresa? empresa = _context.Empresa.FirstOrDefault(e => e.Url == model.Empresa.Url.ToString());

            funcionario.Nome = model.Empresa.Url.ToString();
            funcionario.Email = (model.Empresa.Url.ToString() + "@email.com");
            funcionario.Empresa = empresa;
            funcionario.IdEmpresa = empresa.Id;

            _context.Funcionario.Add(funcionario);
            await _context.SaveChangesAsync();
        }

        public Task<List<Funcionario>> GetAll(string email)
        {
            throw new NotImplementedException();
        }
    }
}
