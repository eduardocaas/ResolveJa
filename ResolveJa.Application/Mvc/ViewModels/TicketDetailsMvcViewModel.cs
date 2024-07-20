using ResolveJa.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Application.Mvc.ViewModels
{
    public class TicketDetailsMvcViewModel
    {
        public TicketDetailsMvcViewModel(int id, string titulo, string email, string conteudo, string? resposta, DateTime dataCriacao, DateTime? dataFechamento, int? idFuncionario, Funcionario? funcionario)
        {
            Id = id;
            Titulo = titulo;
            Email = email;
            Conteudo = conteudo;
            Resposta = resposta;
            DataCriacao = dataCriacao;
            DataFechamento = dataFechamento;
            IdFuncionario = idFuncionario;
            Funcionario = funcionario;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Email { get; set; }
        public string Conteudo { get; set; }
        public string? Resposta { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataFechamento { get; set; }
        public int? IdFuncionario { get; set; }
        public Funcionario? Funcionario { get; set; }
    }
}
