using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResolveJa.Application.Mvc.Services.Interfaces;
using ResolveJa.Application.Mvc.ViewModels;
using ResolveJa.Core.Entities;
using ResolveJa.Core.Enums;
using ResolveJa.Infrastructure.Data.Persistence;

namespace ResolveJa.Web.MVC.Controllers
{
    [Authorize(Roles = "Gestor,Funcionario")]
    public class TicketsController : Controller
    {
        private readonly ResolveJaDbContext _context;
        private readonly ITicketMvcService _ticketMvcService;
        private readonly IFuncionarioMvcService _funcionarioMvcService;

        public TicketsController(ResolveJaDbContext context, ITicketMvcService ticketMvcService, IFuncionarioMvcService funcionarioMvcService)
        {
            _context = context;
            _ticketMvcService = ticketMvcService;
            _funcionarioMvcService = funcionarioMvcService;
        }

        // GET: Tickets
        public async Task<IActionResult> Index(int status)
        {
            var email = User.Identity.Name;
            var idEmpresa = await _funcionarioMvcService.GetIdEmpresa(email);
            if (status == 1)
            {
                ViewData["TitleTicket"] = "Tickets (ABERTO)";
                return View(await _ticketMvcService.GetAll(idEmpresa, 1));
            }
            if (status == 2)
            {
                ViewData["TitleTicket"] = "Tickets (FECHADO)";
                return View(await _ticketMvcService.GetAll(idEmpresa, 2));
            }
            return View(await _ticketMvcService.GetAll(idEmpresa, 3));
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ticket.Status == TicketStatusEnum.ABERTO)
                ViewData["Status"] = 0;

            if (ticket.Status == TicketStatusEnum.FECHADO)
                ViewData["Status"] = 1;

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Titulo,Cpf,Email,Status,Conteudo,Resposta,DataCriacao,DataFechamento,IdEmpresa,IdFuncionario,Id")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Empresa");
            if (ModelState.IsValid)
            {
                try
                { 
                    await _ticketMvcService.Update(ticket);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { status = 2 });
            }
            return View(ticket);
        }

        // GET: Tickets/Atribuir/5
        [Authorize(Roles = "Gestor")]
        public async Task<IActionResult> Atribuir(int? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var email = User.Identity.Name;
            var idEmpresa = await _funcionarioMvcService.GetIdEmpresa(email);
            var funcionarios = await _funcionarioMvcService.GetAll(idEmpresa);

            var ticket = await _context.Ticket.FirstOrDefaultAsync(t => t.Id == id);

            TicketAtribuirMvcViewModel viewModel = new TicketAtribuirMvcViewModel(funcionarios, ticket);

            if (viewModel.Ticket == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        //POST: Tickets/Atribuir/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Atribuir(int id, [Bind("Ticket.Titulo,Ticket.Cpf,Ticket.Email,Ticket.Status,Ticket.Conteudo,Ticket.Resposta,Ticket.DataCriacao,Ticket.DataFechamento,Ticket.IdEmpresa,Ticket.IdFuncionario,Ticket.Id")] TicketAtribuirMvcViewModel viewModel)
        {
            /*if (id != viewModel.Ticket.Id)
            {
                return NotFound();
            }*/

            if (ModelState.IsValid)
            {
                try
                {
                    await _ticketMvcService.Atribuir(viewModel.Ticket);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(viewModel.Ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel.Ticket);
        }

        [Authorize(Roles = "Gestor")]
        public async Task<IActionResult> Report()
        {
            var email = User.Identity.Name;
            var idEmpresa = await _funcionarioMvcService.GetIdEmpresa(email);

            var ticketsAberto = await _ticketMvcService.GetAll(idEmpresa, 1);
            var ticketsFechado = await _ticketMvcService.GetAll(idEmpresa, 2);

            ViewData["TicketsAberto"] = ticketsAberto.Count;
            ViewData["TicketsFechado"] = ticketsFechado.Count;

            return View();
        }
        

        private bool TicketExists(int id)
        {
          return (_context.Tickets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
