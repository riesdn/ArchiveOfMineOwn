﻿using System;
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
    public class AuthorsController: ControllerBase {
        private readonly AOMOContext _context;

        public AuthorsController(AOMOContext context) {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthor() {
            return await _context.Authors.ToListAsync();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id) {
            var author = await _context.Authors.FindAsync(id);

            if (author == null) {
                return NotFound();
            }

            return author;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author) {
            if (id != author.Id) {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!AuthorExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Authors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author) {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id) {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return author;
        }

        private bool AuthorExists(int id) {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
