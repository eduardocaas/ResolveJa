using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Application.Api.ViewModels
{
    public struct TicketListApiViewModel
    {
        public TicketListApiViewModel(int id, string titulo, int status)
        {
            Id = id;
            Titulo = titulo;
            Status = status;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Status { get; set; }

    }
}
