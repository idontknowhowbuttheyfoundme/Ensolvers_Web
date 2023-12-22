using Ensolvers_Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ensolvers_Infrastructure.DataContext
{
    public class EnsolversDbContext : DbContext
    {
        public EnsolversDbContext(DbContextOptions<EnsolversDbContext> options) : base(options) { }
        public DbSet<Note> Notes { get; set; }
    }
}
