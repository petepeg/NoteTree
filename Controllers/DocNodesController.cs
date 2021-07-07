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
    public class DocNodesController : ControllerBase
    {
        private readonly TreeDocumentContext _context;

        public DocNodesController(TreeDocumentContext context)
        {
            _context = context;
        }

        // GET: api/DocNodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocNode>>> GetDocNodes()
        {
            return await _context.DocNodes.ToListAsync();
        }

        // GET: api/DocNodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocNode>> GetDocNode(long id)
        {
            var docNode = await _context.DocNodes.FindAsync(id);

            if (docNode == null)
            {
                return NotFound();
            }

            return docNode;
        }

        // GET: api/DocNodes/DocId/5
        [HttpGet("DocId/{treeDocumentId}")]
        public async Task<ActionResult<IEnumerable<DocNode>>> GetDocNodes(long treeDocumentId)
        {
            return await _context.DocNodes.Where(x => x.TreeDocumentId == treeDocumentId).ToListAsync();
        }

        // PUT: api/DocNodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocNode(long id, DocNode docNode)
        {
            if (id != docNode.Id)
            {
                return BadRequest();
            }

            _context.Entry(docNode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocNodeExists(id))
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

        // POST: api/DocNodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DocNode>> PostDocNode(DocNode docNode)
        {
            _context.DocNodes.Add(docNode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocNode", new { id = docNode.Id }, docNode);
        }

        // DELETE: api/DocNodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocNode(long id)
        {
            var docNode = await _context.DocNodes.FindAsync(id);
            if (docNode == null)
            {
                return NotFound();
            }

            _context.DocNodes.Remove(docNode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocNodeExists(long id)
        {
            return _context.DocNodes.Any(e => e.Id == id);
        }
    }
}
