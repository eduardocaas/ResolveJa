using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Application.Api.InputModels;
using ResolveJa.Application.Api.ViewModels;

namespace ResolveJa.Application.Api.Services.Interfaces
{
    public interface ITicketApiService
    {
        Task<int> Create(TicketCreateInputModel inputModel);
        Task<List<TicketListApiViewModel>> GetTickets(string cpf, string urlEmpresa);
    }
}
