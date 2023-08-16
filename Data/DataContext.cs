using Microsoft.EntityFrameworkCore;
using Rule4.Models;

namespace Rule4.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Models.File> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
