using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResolveJa.Application.Api.InputModels;
using ResolveJa.Application.Api.Services.Interfaces;
using ResolveJa.Core.Entities;

namespace ResolveJa.Application.Api.Services.Implementations
{
    public class TicketApiServiceImpl : ITicketApiService
    {
        public Task Create(TicketCreateInputModel inputModel)
        {


            //Ticket ticket = new Ticket(inputModel.Titulo, inputModel.Cpf, inputModel.Email, inputModel.Conteudo);
        }
    }
}
