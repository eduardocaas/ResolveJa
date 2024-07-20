using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<TicketListMvcViewModel>> GetAll(int idEmpresa)
        {
            var tickets = await _context.Tickets.Where(t => t.IdEmpresa == idEmpresa).ToListAsync();

            List<TicketListMvcViewModel> viewModels = new List<TicketListMvcViewModel>();

            foreach (var ticket in tickets)
            {
                viewModels.Add(new TicketListMvcViewModel(ticket.Id, ticket.Titulo, ticket.Email, ticket.DataCriacao, ticket.IdFuncionario, ticket.Funcionario));    
            }

            return viewModels;
        }
    }
}
