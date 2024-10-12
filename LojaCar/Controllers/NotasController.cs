using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaCar.Data;
using LojaCar.Models;

namespace LojaCar.Controllers
{
    public class NotasController : Controller
    {
        private readonly LojaCarContext _context;

        public NotasController(LojaCarContext context)
        {
            _context = context;
        }

        // GET: Notas
        public async Task<IActionResult> Index()
        {
            var notas = _context.Nota
                .Include(n => n.Comprador)
                .Include(n => n.Vendedor)
                .Include(n => n.Carro);
            return View(await notas.ToListAsync());
        }

        // GET: Notas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota
                .Include(n => n.Comprador)
                .Include(n => n.Vendedor)
                .Include(n => n.Carro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // GET: Notas/Create
        public IActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_context.Cliente, "Id", "Nome");
            ViewBag.VendedorId = new SelectList(_context.Vendedor, "Id", "Nome");
            ViewBag.CarroId = new SelectList(_context.Carro, "Id", "Modelo");
            return View();
        }

        // POST: Notas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,DataEmissao,Garantia,ValorVenda,ClienteId,VendedorId,CarroId")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                var vendedor = await _context.Vendedor.FindAsync(nota.VendedorId);
                var comissao = vendedor.CalcComissao();
                //vendedor.ComissaoAcumulada += comissao; // Acumula a comissão
                // Você pode salvar a comissão em algum lugar ou usá-la conforme necessário

                _context.Add(nota);
                //_context.Update(vendedor); // Atualiza o vendedor no contexto
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ClienteId = new SelectList(_context.Cliente, "Id", "Nome", nota.ClienteId);
            ViewBag.VendedorId = new SelectList(_context.Vendedor, "Id", "Nome", nota.VendedorId);
            ViewBag.CarroId = new SelectList(_context.Carro, "Id", "Modelo", nota.CarroId);
            return View(nota);
        }

        // GET: Notas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota
                .Include(n => n.Comprador)
                .Include(n => n.Vendedor)
                .Include(n => n.Carro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }
            ViewBag.ClienteId = new SelectList(_context.Cliente, "Id", "Nome", nota.ClienteId);
            ViewBag.VendedorId = new SelectList(_context.Vendedor, "Id", "Nome", nota.VendedorId);
            ViewBag.CarroId = new SelectList(_context.Carro, "Id", "Modelo", nota.CarroId);
            return View(nota);
        }

        // POST: Notas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,DataEmissao,Garantia,ValorVenda,ClienteId,VendedorId,CarroId")] Nota nota)
        {
            if (id != nota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaExists(nota.Id))
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
            ViewBag.ClienteId = new SelectList(_context.Cliente, "Id", "Nome", nota.ClienteId);
            ViewBag.VendedorId = new SelectList(_context.Vendedor, "Id", "Nome", nota.VendedorId);
            ViewBag.CarroId = new SelectList(_context.Carro, "Id", "Modelo", nota.CarroId);
            return View(nota);
        }

        // GET: Notas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota
                .Include(n => n.Comprador)
                .Include(n => n.Vendedor)
                .Include(n => n.Carro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nota == null)
            {
                return Problem("Entity set 'LojaCarContext.Nota'  is null.");
            }
            var nota = await _context.Nota.FindAsync(id);
            if (nota != null)
            {
                _context.Nota.Remove(nota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaExists(int id)
        {
            return (_context.Nota?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
