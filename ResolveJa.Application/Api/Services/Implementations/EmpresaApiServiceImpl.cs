using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opw.HttpExceptions;
using ResolveJa.Application.Api.Services.Interfaces;
using ResolveJa.Infrastructure.Data.Persistence;

namespace ResolveJa.Application.Api.Services.Implementations
{
    public class EmpresaApiServiceImpl : IEmpresaApiService
    {
        private readonly ResolveJaDbContext _context;

        public EmpresaApiServiceImpl(ResolveJaDbContext context)
        {
            _context = context;
        }

        public Task<int?> GetId(string url)
        {
            int? id = _context.Empresa.Where(e => e.Url == url).Select(e => e.Id).FirstOrDefault();
            if (id == null)
                throw new NotFoundException($"Empresa com URL: {url} não encontrada!");
            return Task.FromResult(id);
        }
    }
}
