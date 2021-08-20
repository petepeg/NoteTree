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
        private readonly ApplicationDbContext _context;

        public DocNodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DocNodes
        [HttpGet("/getAll")]
        public async Task<ActionResult<IEnumerable<DocNode>>> GetDocNodes()
        {
            return await _context.DocNodes.ToListAsync();
        }

        // GET: api/DocNodes/5
        [HttpGet("/getById/{id}")]
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
        [HttpGet("/getByDocId/{documentId}")]
        public async Task<ActionResult<IEnumerable<DocNode>>> GetDocNodes(long documentId)
        {
            return await _context.DocNodes.Where(x => x.DocumentId == documentId).ToListAsync();
        }

        // PUT: api/DocNodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/editNode/{id}")]
        public async Task<IActionResult> EditDocNode(long id, DocNode data)
        {
            if (id != data.Id)
            {
                return BadRequest("id in data must match endpoint id");
            }
            if (!DocNodeExists(id))
            {
                return NotFound();
            }

            var docNode = await _context.DocNodes.FindAsync(id);
            
            
            if(data.ParentNodeId != docNode.ParentNodeId) // parent node is being changed
            {
                if (data.ParentNodeId == null || docNode.ParentNodeId == null) return BadRequest("Cannot change root. Null is reserved for root node.");
                if (data.ParentNodeId == docNode.Id) return BadRequest("Node can't be it's own parent");
                if (!DocNodeExists(data.ParentNodeId)) return BadRequest("Parent Node Does Not Exist");
            }

            _context.Entry(docNode).State = EntityState.Modified;
            docNode.Data = data.Data;
            docNode.Title = data.Title;
            docNode.DateModified = DateTime.Now;
            docNode.ParentNodeId = data.ParentNodeId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/DocNodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/add/{documentId}")]
        public async Task<ActionResult<DocNode>> PostDocNode(int documentId, int? parentNodeId)
        {
            if (parentNodeId == null)
            {
                return BadRequest("Parent id required");
            }

            var docNode = new DocNode(documentId, parentNodeId)
            {
                Title = "New Node",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };
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
            if (docNode.ParentNodeId == null)
            {
                return BadRequest("Cannot Delete Root Node");
            }

            var parentNode = await _context.DocNodes.FindAsync(docNode.ParentNodeId);
            var childrenNodes = await _context.DocNodes
                .Where(n => n.DocumentId == docNode.DocumentId)
                .Where(n => n.ParentNodeId == id)
                .ToListAsync();


            _context.Entry(parentNode).State = EntityState.Unchanged;
            // Update all orphaned children to point to grandparent
            foreach (var node in childrenNodes)
            {
                _context.Entry(node).State = EntityState.Modified;
                node.ParentNodeId = parentNode.Id;
                node.DateModified = DateTime.Now;
            }
            _context.DocNodes.Remove(docNode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocNodeExists(long? id)
        {
            if (id == null)
            {
                return true;
            }
            return _context.DocNodes.Any(e => e.Id == id);
        }
    }
}
