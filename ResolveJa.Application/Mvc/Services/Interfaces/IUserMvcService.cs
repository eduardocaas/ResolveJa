using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Application.Mvc.MvcInputModels;

namespace ResolveJa.Application.Mvc.Services.Interfaces
{
    public interface IUserMvcService
    {
        Task CreateGestor(EmpresaCreateInputModel model);
        Task CreateFuncionario(FuncionarioCreateInputModel model);
    }
}
