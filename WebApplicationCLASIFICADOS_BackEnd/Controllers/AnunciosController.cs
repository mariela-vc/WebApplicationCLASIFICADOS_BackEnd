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
    public class AnunciosController : ControllerBase
    {
        private readonly ca_2Context _context;

        public AnunciosController(ca_2Context context)
        {
            _context = context;
        }

        // GET: Anuncios
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Anuncios.ToListAsync());
        }

        // GET: Anuncios/Details/5
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncios
                .FirstOrDefaultAsync(m => m.IdAnuncio == id);
            if (anuncio == null)
            {
                return NotFound();
            }

            return Ok(anuncio);
        }


        // POST: Anuncios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]

        public async Task<IActionResult> Create([Bind("IdAnuncio,Titulo,Tipo,Precio,Imagen")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anuncio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(anuncio);
        }



        // POST: Anuncios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(int id, [Bind("IdAnuncio,Titulo,Tipo,Precio,Imagen")] Anuncio anuncio)
        {
            if (id != anuncio.IdAnuncio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anuncio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnuncioExists(anuncio.IdAnuncio))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return Ok(anuncio);
            }

            return BadRequest("PETICIÓN INCORRECTA");
        }


        // POST: Anuncios/Delete/5
        [HttpPost("Delete"), ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anuncio = await _context.Anuncios.FindAsync(id);
            _context.Anuncios.Remove(anuncio);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return Ok("OPERACIÓN EXITOSA");
        }

        private bool AnuncioExists(int id)
        {
            return _context.Anuncios.Any(e => e.IdAnuncio == id);
        }
    }
}
