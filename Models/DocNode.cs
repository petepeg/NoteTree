using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteTree.Models
{
    public class DocNode
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long Id { get; set; }
        public long TreeDocumentId { get; set; }
        public long? ParentNodeId { get; set; }
        public long NodeId { get; set; }
        public string data { get; set; } // temp data param without any formatting

    }
}
