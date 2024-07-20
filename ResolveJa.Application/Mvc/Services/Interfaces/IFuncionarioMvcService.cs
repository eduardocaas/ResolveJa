using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Application.Mvc.MvcInputModels;
using ResolveJa.Core.Entities;

namespace ResolveJa.Application.Mvc.Services.Interfaces
{
    public interface IFuncionarioMvcService
    {
        Task CreateGestor(EmpresaCreateInputModel model);
        Task<List<Funcionario>> GetAll(string emailGestor);
        Task<int> GetIdEmpresa(string email);
        Task CreateFuncionario(Funcionario funcionario, FuncionarioCreateInputModel inputModel);
        Funcionario ValidFuncionario(Funcionario funcionario, string emailGestor);
        void DeleteFuncionarioEmpresa(int idEmpresa);
        Task DeleteFuncionario(int id);
    }
}
