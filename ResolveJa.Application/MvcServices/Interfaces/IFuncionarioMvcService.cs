using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Application.InputModels;
using ResolveJa.Application.ViewModels;
using ResolveJa.Core.Entities;

namespace ResolveJa.Application.MvcServices.Interfaces
{
    public interface IFuncionarioMvcService
    {
        Task CreateGestor(EmpresaCreateInputModel model);
        Task<List<Funcionario>> GetAll(string emailGestor);
        Task CreateFuncionario(Funcionario funcionario, FuncionarioCreateInputModel inputModel);
        Funcionario ValidFuncionario(Funcionario funcionario, string emailGestor);
        void DeleteFuncionarioEmpresa(int idEmpresa);
        void DeleteFuncionario(int id);
    }
}
