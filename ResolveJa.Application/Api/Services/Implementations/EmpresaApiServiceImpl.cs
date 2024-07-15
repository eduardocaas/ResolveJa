using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Task<int> GetId(string url)
        {
            throw new NotImplementedException();
        }
    }
}
