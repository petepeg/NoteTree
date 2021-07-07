using Microsoft.EntityFrameworkCore;
using NoteTree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteTree.Contexts
{
    public class TreeDocumentContext : DbContext
    {
        public TreeDocumentContext(DbContextOptions<TreeDocumentContext> options)
            : base(options)
        {
        }
        public DbSet<TreeDocument> TreeDocuments { get; set; }
        public DbSet<DocNode> DocNodes { get; set; }
    }
}
