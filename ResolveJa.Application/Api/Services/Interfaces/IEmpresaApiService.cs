using ResolveJa.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Application.Api.Services.Interfaces
{
    public interface IEmpresaApiService
    {
        Task<Empresa?> GetEmpresa(string url);
        Task<int?> GetId(string url);
    }
}
