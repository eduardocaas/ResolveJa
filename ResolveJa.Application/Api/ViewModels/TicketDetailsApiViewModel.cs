using ResolveJa.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Application.Api.ViewModels
{
    public struct TicketDetailsApiViewModel
    {
        public TicketDetailsApiViewModel(TicketStatusEnum status, string email, string cpf, string conteudo, string resposta)
        {
            Status = status;
            Email = email;
            Cpf = cpf;
            Conteudo = conteudo;
            Resposta = resposta;
        }

        public TicketStatusEnum Status { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Conteudo { get; set; }
        public string Resposta { get; set; }
    }
}
