using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Application.Mvc.Services.Interfaces;
using ResolveJa.Application.Mvc.ViewModels;

namespace ResolveJa.Application.Mvc.Services.Implementations
{
    public class TicketMvcServiceImpl : ITicketMvcService
    {
        public Task<List<TicketListMvcViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
