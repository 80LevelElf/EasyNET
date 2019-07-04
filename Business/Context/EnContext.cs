using EN.Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace EN.Business.Context
{
    public class EnContext : DbContext
    {
        public EnContext(DbContextOptions<EnContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
