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
    public class CorreosController : ControllerBase
    {
        private readonly ca_2Context _context;

        public CorreosController(ca_2Context context)
        {
            _context = context;
        }

        // GET: Correos
        [HttpGet("Index_Correo")]
        public async Task<IActionResult> Index_Correo()
        {
            return Ok(await _context.Correos.ToListAsync());
        }

        // GET: Correos/Details/5
        [HttpGet("Details_Correo")]
        public async Task<IActionResult> Details_Correo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correo = await _context.Correos
                .FirstOrDefaultAsync(m => m.IdCorreo == id);
            if (correo == null)
            {
                return NotFound();
            }

            return Ok(correo);
        }

        // GET: Correos/Create
               [HttpPost("Create_Correo")]
        public async Task<IActionResult> Create_Correo([Bind("IdCorreo,Nombre,Correo1,Mensaje")] Correo correo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(correo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(correo);
        }

             // POST: Correos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit_Correo")]

         public async Task<IActionResult> Edit_Correo(int id, [Bind("IdCorreo,Nombre,Correo1,Mensaje")] Correo correo)
        {
            if (id != correo.IdCorreo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(correo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorreoExists(correo.IdCorreo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return Ok(correo);
            }
            //return Ok(correo);
            return BadRequest("PETICIÓN INCORRECTA");
        }

        

        // POST: Correos/Delete/5
        [HttpPost("Delete_Correo"), ActionName("Delete_Correo")]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var correo = await _context.Correos.FindAsync(id);
            _context.Correos.Remove(correo);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return Ok("OPERACIÓN EXITOSA");
        }

        private bool CorreoExists(int id)
        {
            return _context.Correos.Any(e => e.IdCorreo == id);
        }
    }
}
