using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Core.Entities
{
    public class Funcionario : BaseEntity
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataAdmissao { get; set; } = DateTime.Now;

        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
    }
}
