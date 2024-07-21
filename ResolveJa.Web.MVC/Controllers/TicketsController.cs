﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResolveJa.Application.Mvc.Services.Interfaces;
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
        public async Task<IActionResult> Index()
        {
            var email = User.Identity.Name;
            var idEmpresa = await _funcionarioMvcService.GetIdEmpresa(email);

            return View(await _ticketMvcService.GetAll(idEmpresa, 1));
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        private bool TicketExists(int id)
        {
          return (_context.Tickets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
