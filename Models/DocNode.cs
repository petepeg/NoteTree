using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteTree.Models
{
    public class DocNode
    {
        public long Id { get; set; }
        public long DocumentId { get; set; }
        public long? ParentNodeId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Data { get; set; } // temp data param without any formatting

        public DocNode()
        {
            this.DateCreated = DateTime.Now;
            this.DateModified = DateTime.Now;
            this.Title = "New Node";
        }
        public DocNode(long documentId, long? parentNodeId)
            : this()
        {
            this.DocumentId = documentId;
            this.ParentNodeId = parentNodeId;
        }
    }
}
