using EFCore2Playgrounds.Model.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace EFCore2Playgrounds.Infrastructure
{
    public class ValueObjectDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=efcoreplaygrounds2;Trusted_Connection=yes",
                builder => builder.MigrationsAssembly("EFCore2Playgrounds.Infrastructure"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Post>().HasKey(x => x.Id);
            modelBuilder.Entity<Post>().OwnsOne(x => x.Title);
            modelBuilder.Entity<Post>().OwnsOne(x => x.Slug);
        }
    }
}