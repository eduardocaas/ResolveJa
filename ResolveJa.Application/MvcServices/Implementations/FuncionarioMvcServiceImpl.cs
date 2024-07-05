using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Application.MvcServices.Interfaces;
using ResolveJa.Application.ViewModels;
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

        public void CreateGestor(EmpresaCreateInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}
