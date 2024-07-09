using ResolveJa.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Application.ViewModels
{
    public class EmpresaCreateInputModel
    {
        public Empresa Empresa { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        [Display(Name = "Senha Gestor")]
        public string SenhaGestor { get; set; }
    }
}
