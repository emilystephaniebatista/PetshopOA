using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petshop.Server;
using PetshopOA.Shared;

namespace Petshop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizacaosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AutorizacaosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Autorizacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autorizacao>>> GetAutorizacao()
        {
            return await _context.Autorizacao.ToListAsync();
        }

        // GET: api/Autorizacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autorizacao>> GetAutorizacao(int id)
        {
            var autorizacao = await _context.Autorizacao.FindAsync(id);

            if (autorizacao == null)
            {
                return NotFound();
            }

            return autorizacao;
        }

        // PUT: api/Autorizacaos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutorizacao(int id, Autorizacao autorizacao)
        {
            if (id != autorizacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(autorizacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorizacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Autorizacaos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Autorizacao>> PostAutorizacao(Autorizacao autorizacao)
        {
            _context.Autorizacao.Add(autorizacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutorizacao", new { id = autorizacao.Id }, autorizacao);
        }

        // DELETE: api/Autorizacaos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Autorizacao>> DeleteAutorizacao(int id)
        {
            var autorizacao = await _context.Autorizacao.FindAsync(id);
            if (autorizacao == null)
            {
                return NotFound();
            }

            _context.Autorizacao.Remove(autorizacao);
            await _context.SaveChangesAsync();

            return autorizacao;
        }

        private bool AutorizacaoExists(int id)
        {
            return _context.Autorizacao.Any(e => e.Id == id);
        }
    }
}
