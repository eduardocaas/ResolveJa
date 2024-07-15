using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Application.Api.ApiInputModels
{
    public class TicketCreateInputModel
    {
        public string Titulo { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string Conteudo { get; private set; }
        public string UrlEmpresa { get; private set; }
    }
}
