using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Application.Api.InputModels
{
    public class TicketCreateInputModel
    {
        public string Titulo { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Conteudo { get; set; }
        public string UrlEmpresa { get; set; }
    }
}
