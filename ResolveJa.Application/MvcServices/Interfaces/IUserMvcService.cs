using ResolveJa.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Application.InputModels;

namespace ResolveJa.Application.MvcServices.Interfaces
{
    public interface IUserMvcService
    {
        Task CreateGestor(EmpresaCreateInputModel model);
        Task CreateFuncionario(FuncionarioCreateInputModel model);
    }
}
