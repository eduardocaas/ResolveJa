using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Application.ViewModels;

namespace ResolveJa.Application.MvcServices.Interfaces
{
    public interface IFuncionarioMvcService
    {
        void CreateGestor(EmpresaCreateInputModel model);
    }
}
