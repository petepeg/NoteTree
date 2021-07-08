using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteTree.Models
{
    public class Document
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Title { get; set; }
        public List<DocNode> NodeList { get; set; }



    }
}
