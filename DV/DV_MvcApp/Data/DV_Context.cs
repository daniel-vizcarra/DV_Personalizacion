// Data/DV_Context.cs
using Microsoft.EntityFrameworkCore;
using DV_MvcApp.Models;

namespace DV_MvcApp.Data
{
    public class DV_Context : DbContext
    {
        public DV_Context(DbContextOptions<DV_Context> options) : base(options) { }

        public DbSet<DV_Author> DV_Authors { get; set; }
        public DbSet<DV_Book> DV_Books { get; set; }
    }
}
