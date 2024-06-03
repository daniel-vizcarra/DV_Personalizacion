
using Microsoft.EntityFrameworkCore;
using DV_Api.Models;

namespace DV_Api.Data
{
    public class DV_Context : DbContext
    {
        public DV_Context(DbContextOptions<DV_Context> options) : base(options) { }

        public DbSet<DV_Author> DV_Authors { get; set; }
        public DbSet<DV_Book> DV_Books { get; set; }
    }
}
