using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Application.Mvc.Services.Interfaces;
using ResolveJa.Application.Mvc.ViewModels;
using ResolveJa.Infrastructure.Data.Persistence;

namespace ResolveJa.Application.Mvc.Services.Implementations
{
    public class TicketMvcServiceImpl : ITicketMvcService
    {
        private readonly ResolveJaDbContext _context;

        public TicketMvcServiceImpl(ResolveJaDbContext context)
        {
            _context = context;
        }

        public Task<List<TicketListMvcViewModel>> GetAll(int idEmpresa)
        {
            throw new NotImplementedException();
        }
    }
}
