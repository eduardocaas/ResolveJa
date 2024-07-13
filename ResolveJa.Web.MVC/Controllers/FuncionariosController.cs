using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResolveJa.Application.Mvc.MvcInputModels;
using ResolveJa.Application.Mvc.MvcServices.Interfaces;
using ResolveJa.Core.Entities;
using ResolveJa.Infrastructure.Data.Persistence;

namespace ResolveJa.Web.MVC.Controllers
{
    [Authorize(Roles = "Gestor")]
    public class FuncionariosController : Controller
    {
        private readonly ResolveJaDbContext _context;
        private readonly IFuncionarioMvcService _funcionarioMvcService;

        public FuncionariosController(
            ResolveJaDbContext context,
            IFuncionarioMvcService funcionarioMvcService)
        {
            _context = context;
            _funcionarioMvcService = funcionarioMvcService;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            var emailGestor = User.Identity.Name;
            return View(await _funcionarioMvcService.GetAll(emailGestor));
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Funcionario == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Funcionario,Funcionario.Email,Funcionario.Nome,Funcionario.DataAdmissao,Funcionario.IdEmpresa,Funcionario.Id, SenhaFuncionario")] FuncionarioCreateInputModel inputModel)
        {
            var emailGestor = User.Identity.Name;
            inputModel.Funcionario = _funcionarioMvcService.ValidFuncionario(inputModel.Funcionario, emailGestor);

            ModelState.Remove("Funcionario.Empresa");
            ModelState.Remove("Funcionario.IdEmpresa");

            if (ModelState.IsValid)
            {
                await _funcionarioMvcService.CreateFuncionario(inputModel.Funcionario, inputModel);
                return RedirectToAction(nameof(Index));
            }
            return View(inputModel);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Funcionario == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Email,Nome,DataAdmissao,IdEmpresa,Id")] Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.Id))
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
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Funcionario == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Funcionario == null)
            {
                return Problem("Entity set 'ResolveJaDbContext.Funcionario'  is null.");
            }
            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario != null)
            {
                await _funcionarioMvcService.DeleteFuncionario(id);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
          return (_context.Funcionario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
