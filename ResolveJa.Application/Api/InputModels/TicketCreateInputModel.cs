using ResolveJa.Core.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Application.Api.InputModels
{
    public class TicketCreateInputModel
    {
        [Required(ErrorMessage = "Required")]
        [MaxLength(80, ErrorMessage = "MaxLength")]
        [MinLength(3, ErrorMessage = "MinLength")]
        public string Titulo { get; set; }
        [CpfValidation(errorMessage: "Insira um CPF válido")]
        [Required(ErrorMessage = "Required")]
        public string Cpf { get; set; }
        [EmailAddress(ErrorMessage = "Insira um email válido")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(80, ErrorMessage = "MaxLength")]
        [MinLength(10, ErrorMessage = "MinLength")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(1000, ErrorMessage = "MaxLength")]
        [MinLength(10, ErrorMessage = "MinLength")]
        public string Conteudo { get; set; }
        public string UrlEmpresa { get; set; }
    }
}
