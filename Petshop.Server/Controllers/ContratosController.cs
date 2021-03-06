﻿using System;
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
    public class ContratosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContratosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Contratoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContrato()
        {
            return await _context.Contrato.ToListAsync();
        }

        // GET: api/Contratoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contrato>> GetContrato(int id)
        {
            var contrato = await _context.Contrato.FindAsync(id);

            if (contrato == null)
            {
                return NotFound();
            }

            return contrato;
        }

        // PUT: api/Contratoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContrato(int id, ContratoDto contrato)
        {
            var contrato2 = new Contrato
            {
                Numerocontrato = contrato.Numerocontrato,
                FuncionarioId = int.Parse(contrato.FuncionarioId)
            };

            if (id != contrato2.Id)
            {
                return BadRequest();
            }

            _context.Entry(contrato2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoExists(id))
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

        // POST: api/Contratoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Contrato>> PostContrato(ContratoDto contrato)
        {
            var contrato2 = new Contrato
            {
                Numerocontrato = contrato.Numerocontrato,
                FuncionarioId = int.Parse(contrato.FuncionarioId)
            };
            _context.Contrato.Add(contrato2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContrato", new { id = contrato2.Id }, contrato2);
        }

        // DELETE: api/Contratoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contrato>> DeleteContrato(int id)
        {
            var contrato = await _context.Contrato.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }

            _context.Contrato.Remove(contrato);
            await _context.SaveChangesAsync();

            return contrato;
        }

        private bool ContratoExists(int id)
        {
            return _context.Contrato.Any(e => e.Id == id);
        }
    }
}
