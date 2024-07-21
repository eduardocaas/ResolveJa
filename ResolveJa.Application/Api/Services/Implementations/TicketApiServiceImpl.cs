using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Opw.HttpExceptions;
using ResolveJa.Application.Api.InputModels;
using ResolveJa.Application.Api.Services.Interfaces;
using ResolveJa.Application.Api.ViewModels;
using ResolveJa.Core.Entities;
using ResolveJa.Core.Enums;
using ResolveJa.Infrastructure.Data.Persistence;

namespace ResolveJa.Application.Api.Services.Implementations
{
    public class TicketApiServiceImpl : ITicketApiService
    {
        private readonly ResolveJaDbContext _context;
        private readonly IEmpresaApiService _empresaApiService;

        public TicketApiServiceImpl(
            ResolveJaDbContext context,
            IEmpresaApiService empresaApiService)
        {
            _context = context;
            _empresaApiService = empresaApiService;
        }

        public async Task<int> Create(TicketCreateInputModel inputModel)
        {
            Empresa empresa = await _empresaApiService.GetEmpresa(inputModel.UrlEmpresa);

            Ticket ticket = new Ticket(inputModel.Titulo, inputModel.Cpf, inputModel.Email, inputModel.Conteudo, empresa, empresa.Id );

            await _context.Ticket.AddAsync(ticket);
            await _context.SaveChangesAsync();

            return ticket.Id;
        }

        public async Task<List<TicketListApiViewModel>> GetTickets(string cpf, string urlEmpresa)
        {
            var id = await _empresaApiService.GetId(urlEmpresa);
            List<TicketListApiViewModel> tickets = new List<TicketListApiViewModel>();

            var ticketsDb = await _context.Ticket.AsNoTracking().Where(t => t.Cpf == cpf).ToListAsync();
            ticketsDb = ticketsDb.Where(t => t.IdEmpresa.Equals(id)).ToList();

            ticketsDb.ForEach(t => tickets.Add(new TicketListApiViewModel(t.Id, t.Titulo, t.Status)));
            return tickets;

        }

        public async Task<TicketDetailsApiViewModel> GetTicket(int id)
        {
            Ticket? ticket = await _context.Ticket.FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null)
                throw new NotFoundException($"Ticket com id: {id} não encontrado");

            TicketDetailsApiViewModel ticketDetails =
                new TicketDetailsApiViewModel(ticket.Status, ticket.Email, ticket.Cpf, ticket.Conteudo, ticket.Resposta);

            return ticketDetails;
        }

    }
}
