using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteTree.Contexts;
using NoteTree.Models;

namespace NoteTree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeDocumentsController : ControllerBase
    {
        private readonly TreeDocumentContext _context;

        public TreeDocumentsController(TreeDocumentContext context)
        {
            _context = context;
        }

        // GET: api/TreeDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreeDocument>>> GetTreeDocuments()
        {
            return await _context.TreeDocuments.ToListAsync();
        }

        // GET: api/TreeDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TreeDocument>> GetTreeDocument(long id)
        {
            var treeDocument = await _context.TreeDocuments.FindAsync(id);

            if (treeDocument == null)
            {
                return NotFound();
            }

            return treeDocument;
        }

        // PUT: api/TreeDocuments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreeDocument(long id, TreeDocument treeDocument)
        {
            if (id != treeDocument.Id)
            {
                return BadRequest();
            }

            _context.Entry(treeDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreeDocumentExists(id))
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

        // POST: api/TreeDocuments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TreeDocument>> PostTreeDocument(TreeDocument treeDocument)
        {
            _context.TreeDocuments.Add(treeDocument);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTreeDocument), new { id = treeDocument.Id }, treeDocument);
        }

        // DELETE: api/TreeDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreeDocument(long id)
        {
            var treeDocument = await _context.TreeDocuments.FindAsync(id);
            var docNodes =  await _context.DocNodes.Where(x => x.TreeDocumentId == id).ToListAsync();
            if(treeDocument == null)
            {
                return NotFound();
            }

            _context.TreeDocuments.Remove(treeDocument);

            foreach(var node in docNodes)
            {
                _context.DocNodes.Remove(node);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TreeDocumentExists(long id)
        {
            return _context.TreeDocuments.Any(e => e.Id == id);
        }
    }
}
