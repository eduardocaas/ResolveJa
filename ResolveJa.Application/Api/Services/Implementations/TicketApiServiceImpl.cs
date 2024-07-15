using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Application.Api.InputModels;
using ResolveJa.Application.Api.Services.Interfaces;
using ResolveJa.Application.Api.ViewModels;
using ResolveJa.Core.Entities;
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

        public Task<List<TicketListApiViewModel>> GetTickets(string cpf, string urlEmpresa)
        {
            
        }
    }
}
