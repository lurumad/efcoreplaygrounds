using EFCore2Playgrounds.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace EFCore2Playgrounds.OneToMany
{
    public class OneToManyDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=efcoreplaygrounds2;Trusted_Connection=yes",
                builder => builder.MigrationsAssembly("EFCore2Playgrounds"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Order>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>()
                .HasOne(typeof(State), nameof(State))
                .WithMany()
                .HasForeignKey($"{nameof(State)}{nameof(State.Id)}");
            modelBuilder.Entity<State>().Property(x => x.Id).ValueGeneratedNever();
        }
    }
}