using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Opw.HttpExceptions;
using ResolveJa.Application.Api.Services.Interfaces;
using ResolveJa.Application.Api.ViewModels;
using ResolveJa.Core.Entities;
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

        public async Task<Empresa?> GetEmpresa(string url)
        {
            Empresa? empresa = await _context.Empresa.FirstOrDefaultAsync(e => e.Url == url);

            if (empresa == null)
                throw new NotFoundException($"Empresa com URL: {url} não encontrada!");
            return empresa;
        }

        public async Task<int?> GetId(string url)
        {
            int? id = await _context.Empresa.Where(e => e.Url == url).Select(e => e.Id).FirstOrDefaultAsync();

            if (id == null || id == 0)
                throw new NotFoundException($"Empresa com URL: {url} não encontrada!");
            return id;
        }

        public Task<EmpresaUrlApiViewModel> GetUrl(string url)
        {
            throw new NotImplementedException();
        }
    }
}
