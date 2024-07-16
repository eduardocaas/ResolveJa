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
        public TicketStatusEnum Status { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Conteudo { get; set; }
        public string Resposta { get; set; }
    }
}
