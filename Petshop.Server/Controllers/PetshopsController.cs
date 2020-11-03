using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetshopsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PetshopsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Petshops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetshopOA.Shared.Petshop>>> GetPetshops()
        {
            return await _context.Petshops.ToListAsync();
        }

        // GET: api/Petshops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetshopOA.Shared.Petshop>> GetPetshop(int id)
        {
            var petshop = await _context.Petshops.FindAsync(id);

            if (petshop == null)
            {
                return NotFound();
            }

            return petshop;
        }

        // PUT: api/Petshops/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetshop(int id, PetshopOA.Shared.Petshop petshop)
        {
            if (id != petshop.Id)
            {
                return BadRequest();
            }

            _context.Entry(petshop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetshopExists(id))
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

        // POST: api/Petshops
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PetshopOA.Shared.Petshop>> PostPetshop(PetshopOA.Shared.Petshop petshop)
        {
            _context.Petshops.Add(petshop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetshop", new { id = petshop.Id }, petshop);
        }

        // DELETE: api/Petshops/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PetshopOA.Shared.Petshop>> DeletePetshop(int id)
        {
            var petshop = await _context.Petshops.FindAsync(id);
            if (petshop == null)
            {
                return NotFound();
            }

            _context.Petshops.Remove(petshop);
            await _context.SaveChangesAsync();

            return petshop;
        }

        private bool PetshopExists(int id)
        {
            return _context.Petshops.Any(e => e.Id == id);
        }
    }
}
