using ResolveJa.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Core.Validations;

namespace ResolveJa.Core.Entities
{
    public class Ticket : BaseEntity
    {
        public Ticket() { }

        public Ticket(string titulo, string cpf, string email, string conteudo, Empresa empresa, int idEmpresa)
        {
            Titulo = titulo;
            Cpf = cpf;
            Email = email;
            Conteudo = conteudo;
            Empresa = empresa;
            IdEmpresa = idEmpresa;       
        }

        public string Titulo { get; set; }
        //[CpfValidation(errorMessage: "Insira um CPF válido")]
        public string Cpf { get; set; }
        public string Email { get; set; }
        public TicketStatusEnum Status { get; set; }
        public string Conteudo { get; set; }
        public string Resposta { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataFechamento { get; set; }

        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
        [Display(Name = "Nome do Funcionário")]
        public int? IdFuncionario { get; set; }
        public Funcionario? Funcionario { get; set; }

    }
}
