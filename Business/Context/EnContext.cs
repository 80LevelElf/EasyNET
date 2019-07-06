using EN.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace EN.Business.Context
{
    public class EnContext : DbContext
    {
        public EnContext(DbContextOptions<EnContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<Item>().HasKey(x => x.Id);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
