using EFCore2Playgrounds.Model;
using EFCore2Playgrounds.Model.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace EFCore2Playgrounds.Infrastructure
{
    public class ManyToManyDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderCategory> OrderCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=efcoreplaygrounds;Trusted_Connection=yes",
                builder => builder.MigrationsAssembly("EFCore2Playgrounds.Infrastructure"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(x => x.Id)
                .ValueGeneratedNever();
            modelBuilder.Entity<OrderCategory>()
                .HasKey(x => new {x.OrderId, x.CategoryId});
            modelBuilder.Entity<OrderCategory>()
                .HasOne(typeof(Order), nameof(Order))
                .WithMany(Constanst.OrderOrderCategories)
                .HasForeignKey($"{nameof(Order)}{nameof(Order.Id)}");
            modelBuilder.Entity<OrderCategory>()
                .HasOne(typeof(Category), nameof(Category))
                .WithMany(Constanst.CategoryOrderCategories)
                .HasForeignKey($"{nameof(Category)}{nameof(Category.Id)}");
        }
    }
}