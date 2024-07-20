using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Application.Mvc.ViewModels;

namespace ResolveJa.Application.Mvc.Services.Interfaces
{
    public interface ITicketMvcService
    {
        Task<List<TicketListMvcViewModel>> GetAll(int idEmpresa);
    }
}
