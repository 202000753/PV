using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediESTeca_v2.Data;
using MediESTeca_v2.Models;
using Microsoft.AspNetCore.Authorization;

namespace MediESTeca_v2.Controllers
{
    [Authorize]
    public class RequisicoesController : Controller
    {
        private readonly MediESTecaComIdentityContext _context;

        public RequisicoesController(MediESTecaComIdentityContext context)
        {
            _context = context;
        }

        // GET: Requisicoes
        public async Task<IActionResult> Index()
        {
            var mediESTecaComIdentityContext = _context.Requisicao.Include(r => r.Livro).Include(r => r.Utente);
            return View(await mediESTecaComIdentityContext.ToListAsync());
        }

        // GET: Requisicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Requisicao == null)
            {
                return NotFound();
            }

            var requisicao = await _context.Requisicao
                .Include(r => r.Livro)
                .Include(r => r.Utente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requisicao == null)
            {
                return NotFound();
            }

            return View(requisicao);
        }

        // GET: Requisicoes/Create
        public IActionResult Create()
        {
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Titulo");
            ViewData["UtenteId"] = new SelectList(_context.Utente, "Id", "Nome");
            return View();
        }

        // POST: Requisicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LivroId,UtenteId,DataRequisicao,DataEntrega")] Requisicao requisicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requisicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Titulo", requisicao.LivroId);
            ViewData["UtenteId"] = new SelectList(_context.Utente, "Id", "Nome", requisicao.UtenteId);
            return View(requisicao);
        }

        // GET: Requisicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Requisicao == null)
            {
                return NotFound();
            }

            var requisicao = await _context.Requisicao.FindAsync(id);
            if (requisicao == null)
            {
                return NotFound();
            }
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Titulo", requisicao.LivroId);
            ViewData["UtenteId"] = new SelectList(_context.Utente, "Id", "Nome", requisicao.UtenteId);
            return View(requisicao);
        }

        // POST: Requisicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LivroId,UtenteId,DataRequisicao,DataEntrega")] Requisicao requisicao)
        {
            if (id != requisicao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisicaoExists(requisicao.Id))
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
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Titulo", requisicao.LivroId);
            ViewData["UtenteId"] = new SelectList(_context.Utente, "Id", "Nome", requisicao.UtenteId);
            return View(requisicao);
        }

        // GET: Requisicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Requisicao == null)
            {
                return NotFound();
            }

            var requisicao = await _context.Requisicao
                .Include(r => r.Livro)
                .Include(r => r.Utente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requisicao == null)
            {
                return NotFound();
            }

            return View(requisicao);
        }

        // POST: Requisicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Requisicao == null)
            {
                return Problem("Entity set 'MediESTecaComIdentityContext.Requisicao'  is null.");
            }
            var requisicao = await _context.Requisicao.FindAsync(id);
            if (requisicao != null)
            {
                _context.Requisicao.Remove(requisicao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequisicaoExists(int id)
        {
          return _context.Requisicao.Any(e => e.Id == id);
        }
    }
}
