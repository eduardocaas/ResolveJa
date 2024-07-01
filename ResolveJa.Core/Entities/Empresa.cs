using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Core.Entities
{
    public class Empresa : BaseEntity
    {
        public string Url { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Ramo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAdmissao { get; set; } = DateTime.Now;
    }
}
