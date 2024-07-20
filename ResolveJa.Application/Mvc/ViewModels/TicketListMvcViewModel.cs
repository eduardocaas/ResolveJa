using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Core.Entities;

namespace ResolveJa.Application.Mvc.ViewModels
{
    public class TicketListMvcViewModel
    {
        public TicketListMvcViewModel(int id, string titulo, string email, DateTime? dataCriacao, int? idFuncionario, Funcionario? funcionario)
        {
            Id = id;
            Titulo = titulo;
            Email = email;
            DataCriacao = dataCriacao;
            IdFuncionario = idFuncionario;
            Funcionario = funcionario;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Email { get; set; }
        public DateTime? DataCriacao { get; set; }
        public int? IdFuncionario { get; set; }
        public Funcionario? Funcionario { get; set; }
    }
}
