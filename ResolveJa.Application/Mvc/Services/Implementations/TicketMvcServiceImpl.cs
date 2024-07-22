using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResolveJa.Application.Mvc.Services.Interfaces;
using ResolveJa.Application.Mvc.ViewModels;
using ResolveJa.Core.Entities;
using ResolveJa.Core.Enums;
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

        public Task Atribuir(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TicketListMvcViewModel>> GetAll(int idEmpresa, int opt)
        {
            // OPT 1 == TICKETS ABERTOS, OPT 2 == TICKETS FECHADO

            var tickets = await _context.Tickets.Include(t => t.Funcionario).Where(t => t.IdEmpresa == idEmpresa).ToListAsync();
            List<TicketListMvcViewModel> viewModels = new List<TicketListMvcViewModel>();

            if (opt == 1)
            {
                var ticketsAberto = tickets.Where(t => t.Status == TicketStatusEnum.ABERTO);
                foreach (var ticket in ticketsAberto)
                {
                    viewModels.Add(new TicketListMvcViewModel(ticket.Id, ticket.Titulo, ticket.Email, ticket.DataCriacao, ticket.IdFuncionario, ticket.Funcionario));
                }

                return viewModels;
            }
            if (opt == 2)
            {
                var ticketsFechado = tickets.Where(t => t.Status == TicketStatusEnum.FECHADO);
                foreach (var ticket in ticketsFechado)
                {
                    viewModels.Add(new TicketListMvcViewModel(ticket.Id, ticket.Titulo, ticket.Email, ticket.DataCriacao, ticket.IdFuncionario, ticket.Funcionario));
                }

                return viewModels;
            }

            return new List<TicketListMvcViewModel>();
        }

        public async Task Update(Ticket ticket)
        {
            _context.ChangeTracker.Clear();
            ticket.DataFechamento = DateTime.Now;
            ticket.Status = TicketStatusEnum.FECHADO;
            _context.Update(ticket);
            await _context.SaveChangesAsync();
        }
    }
}
