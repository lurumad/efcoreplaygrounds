using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCore2Playgrounds
{
    static void Main(string[] args)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.Database.Migrate();
                var draftState = new State { Id = 1, Name = "Draft" };
                var cancelState = new State { Id = 2, Name = "Cancel" };
                dbContext.States.Add(draftState);
                dbContext.States.Add(cancelState);
                dbContext.SaveChanges();
                var category = new Category { Name = "Vip" };
                dbContext.Categories.Add(category);
                dbContext.SaveChanges();
                var order = new Order();
                order.AddCategory(category);
                dbContext.Orders.Add(order);
                var affected = dbContext.SaveChanges();
                if (affected == 2) Console.WriteLine("Expected amount of objects saved");
                        else Console.WriteLine("affected count is not 2 ");
            }

            Console.Read();
        }
    }

    public class Order
    {
        public int Id { get; set; }
        private int StateId;
        private State State { get; set; }
        private List<OrderCategory> _orderCategories { get; set; } = new List<OrderCategory>();

        public Order()
        {
            StateId = 1;
        }

        public void Cancel()
        {
            StateId = 2;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _orderCategories.Select(x => x.Category);
        }

        public void AddCategory(Category category)
        {
            _orderCategories.Add(new OrderCategory { Category = category, Order = this });
        }
    }

    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OrderCategory
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MyDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderCategory> OrderCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=efcoreplaygrounds;Trusted_Connection=yes",
                builder => builder.MigrationsAssembly("EFCore2Playgrounds"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>() .Property(x => x.Id).ValueGeneratedNever();
            modelBuilder.Entity<Order>()
                .HasOne(typeof(State), nameof(State))
                .WithMany()
                .HasForeignKey("StateId");

            modelBuilder.Entity<OrderCategory>()
                .HasKey(x => new { x.OrderId, x.CategoryId });

            modelBuilder.Entity<OrderCategory>()
                .HasOne(oc=>oc.Order)
                .WithMany("_orderCategories")
                .HasForeignKey("OrderId");
            modelBuilder.Entity<OrderCategory>()
                .HasOne(oc => oc.Category)
                .WithMany()
                .HasForeignKey("CategoryId");
        }
    }
}
