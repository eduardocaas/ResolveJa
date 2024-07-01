using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Core.Entities
{
    public class Empresa : BaseEntity
    {
        public string Url { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public string Ramo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataAdmissao { get; private set; } = DateTime.Now;
    }
}
