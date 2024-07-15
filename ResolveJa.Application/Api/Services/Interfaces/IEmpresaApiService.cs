using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Application.Api.Services.Interfaces
{
    public interface IEmpresaApiService
    {
        Task<int?> GetId(string url);
    }
}
