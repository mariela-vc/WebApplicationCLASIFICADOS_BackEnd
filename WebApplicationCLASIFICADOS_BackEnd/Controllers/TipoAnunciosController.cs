using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationCLASIFICADOS_BackEnd.Models;

namespace WebApplicationCLASIFICADOS_BackEnd.Controllers
{
   [ApiController]
    public class TipoAnunciosController : ControllerBase
    {
        private readonly ca_2Context _context;

        public TipoAnunciosController(ca_2Context context)
        {
            _context = context;
        }

        // GET: TipoAnuncios
        [HttpGet("Index2")]
        public async Task<IActionResult> Index2()
        {
            return Ok(await _context.TipoAnuncios.ToListAsync());
        }

        // GET: TipoAnuncios/Details/5
        [HttpGet("Details2")]
        public async Task<IActionResult> Details2(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAnuncio = await _context.TipoAnuncios
                .FirstOrDefaultAsync(m => m.IdTipo == id);
            if (tipoAnuncio == null)
            {
                return NotFound();
            }

            return Ok(tipoAnuncio);
        }

             
       
        [HttpPost("Create2")]
        
        public async Task<IActionResult> Create2([Bind("IdTipo,TipoAnuncio1")] TipoAnuncio tipoAnuncio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoAnuncio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(tipoAnuncio);
        }

                // POST: TipoAnuncios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit2")]
       
        public async Task<IActionResult> Edit2(int id, [Bind("IdTipo,TipoAnuncio1")] TipoAnuncio tipoAnuncio)
        {
            if (id != tipoAnuncio.IdTipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoAnuncio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoAnuncioExists(tipoAnuncio.IdTipo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(tipoAnuncio);
            }
            return BadRequest("PETICIÓN INCORRECTA");
        }

               // POST: TipoAnuncios/Delete/5
        [HttpPost("Delete2"), ActionName("Delete2")]
                public async Task<IActionResult> DeleteConfirmed2(int id)
        {
            var tipoAnuncio = await _context.TipoAnuncios.FindAsync(id);
            _context.TipoAnuncios.Remove(tipoAnuncio);
            await _context.SaveChangesAsync();
            return Ok("OPERACIÓN EXITOSA");
        }

        private bool TipoAnuncioExists(int id)
        {
            return _context.TipoAnuncios.Any(e => e.IdTipo == id);
        }
    }
}
