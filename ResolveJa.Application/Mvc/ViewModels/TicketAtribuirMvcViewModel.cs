using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Core.Entities;

namespace ResolveJa.Application.Mvc.ViewModels
{
    public class TicketAtribuirMvcViewModel
    {
        public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
        public Ticket Ticket { get; set; }
    }
}
