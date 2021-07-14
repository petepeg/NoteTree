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
    public class DocumentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DocumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetDocuments()
        {
            // this will eventully be used return a list of all documents owner by a user. Nodelist can be left null.
            return await _context.Documents.ToListAsync();
        }

        // GET: api/Documents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetDocument(long id)
        {
            var document = await _context.Documents.FindAsync(id);
            document.NodeList = await _context.DocNodes
                .Where(n => n.DocumentId == id)
                .ToListAsync();

            if (document == null)
            {
                return NotFound();
            }

            return document;
        }

        // PUT: api/Documents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // At the moment this really just changes the title. Title and Id are the only required feilds.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocument(long id, Document data) 
        {

            var document = await _context.Documents.FindAsync(id);

            if (data.Id != id)
            {
                return BadRequest("id in data must match endpoint id");
            }

            if (data.NodeList != null)
            {
                return BadRequest("Use node endpoints to add/modify nodes");
            }


            if (data.Title == null)
            {
                return BadRequest("New Title Required");
            }

            _context.Entry(document).State = EntityState.Modified; // starts context tracking and  marks all feilds as modified t obe updated on nsave
            document.Title = data.Title;
            document.DateModified = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentExists(id))
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

        // POST: api/Documents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // POST will create and empty document with a single root node
        [HttpPost]
        public async Task<ActionResult<Document>> PostDocument()
        {
            var document = new Document();
            document.Title = "New Document";
            document.DateCreated = DateTime.Now;
            document.DateModified = DateTime.Now;

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            var docNode = new DocNode(document.Id, null);
            _context.DocNodes.Add(docNode);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDocument), new { id = document.Id }, document);
        }

        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(long id)
        {
            var document = await _context.Documents.FindAsync(id);
            
            if(document == null)
            {
                return NotFound();
            }

            _context.Documents.Remove(document);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentExists(long id)
        {
            return _context.Documents.Any(e => e.Id == id);
        }
    }
}
