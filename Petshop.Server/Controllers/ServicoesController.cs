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
    public class ServicoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Servicoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servico>>> GetServico()
        {
            return await _context.Servico.ToListAsync();
        }

        // GET: api/Servicoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servico>> GetServico(int id)
        {
            var servico = await _context.Servico.FindAsync(id);

            if (servico == null)
            {
                return NotFound();
            }

            return servico;
        }

        // PUT: api/Servicoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServico(int id, ServicoDto servico)
        {

            var servico2 = new Servico
            {
                Descricao = servico.Descricao,
                FuncionarioId =  int.Parse(servico.FuncionarioId),
                ClienteId = int.Parse(servico.ClienteId)
            };

            if (id != servico2.Id)
            {
                return BadRequest();
            }

            _context.Entry(servico2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicoExists(id))
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

        // POST: api/Servicoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Servico>> PostServico(ServicoDto servico)
        {
            var servico2 = new Servico
            {
                Descricao = servico.Descricao,
                FuncionarioId = int.Parse(servico.FuncionarioId),
                ClienteId = int.Parse(servico.ClienteId)
            };
            _context.Servico.Add(servico2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServico", new { id = servico2.Id }, servico2);
        }

        // DELETE: api/Servicoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Servico>> DeleteServico(int id)
        {
            var servico = await _context.Servico.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }

            _context.Servico.Remove(servico);
            await _context.SaveChangesAsync();

            return servico;
        }

        private bool ServicoExists(int id)
        {
            return _context.Servico.Any(e => e.Id == id);
        }
    }
}
