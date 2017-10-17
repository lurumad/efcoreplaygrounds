using Microsoft.EntityFrameworkCore;

namespace EFCore2Playgrounds.OneToOne
{
    public class OneToOneDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Biography> Biographies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=efcoreplaygrounds2;Trusted_Connection=yes",
                builder => builder.MigrationsAssembly("EFCore2Playgrounds"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasOne(x => x.Biography).WithOne().HasForeignKey<Biography>(x => x.Id);
        }
    }
}
