using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Core.Entities
{
    public class Funcionario : BaseEntity
    {
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataAdmissao { get; private set; }

        public int IdEmpresa { get; private set; }
        public Empresa Empresa { get; private set; }
    }
}
