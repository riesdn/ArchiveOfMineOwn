using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArchiveOfMineOwn.Data;
using ArchiveOfMineOwn.Models;

namespace ArchiveOfMineOwn.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class WorksController: ControllerBase {
        private readonly AOMOContext _context;

        public WorksController(AOMOContext context) {
            _context = context;
        }

        // GET: api/Works
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Work>>> GetWork() {
            return await _context.Works.ToListAsync();
        }

        // GET: api/Works/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Work>> GetWork(int id) {
            var work = await _context.Works.FindAsync(id);

            if (work == null) {
                return NotFound();
            }

            return work;
        }

        // PUT: api/Works/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWork(int id, Work work) {
            if (id != work.Id) {
                return BadRequest();
            }

            _context.Entry(work).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!WorkExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Works
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Work>> PostWork(Work work) {
            _context.Works.Add(work);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWork", new { id = work.Id }, work);
        }

        // DELETE: api/Works/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Work>> DeleteWork(int id) {
            var work = await _context.Works.FindAsync(id);
            if (work == null) {
                return NotFound();
            }

            _context.Works.Remove(work);
            await _context.SaveChangesAsync();

            return work;
        }

        private bool WorkExists(int id) {
            return _context.Works.Any(e => e.Id == id);
        }
    }
}
