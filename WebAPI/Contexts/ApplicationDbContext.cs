using Microsoft.EntityFrameworkCore;
using NoteTree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteTree.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocNode> DocNodes { get; set; }
    }
}
