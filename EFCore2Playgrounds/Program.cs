using System;
using System.Linq;
using EFCore2Playgrounds.ManyToMany;
using EFCore2Playgrounds.OneToMany;
using Microsoft.EntityFrameworkCore;
using Order = EFCore2Playgrounds.ManyToMany.Order;

namespace EFCore2Playgrounds
{
    class Program
    {
        static void Main(string[] args)
        {
            //ManyToMany();

            OneToMany();

            Console.Read();
        }

        private static void ManyToMany()
        {
            using (var dbContext = new ManyToManyDbContext())
            {
                dbContext.Database.Migrate();
                var category = new Category {Id = 1, Name = "Vip"};
                dbContext.Categories.Add(category);
                dbContext.SaveChanges();
                var order = new Order();
                dbContext.Orders.Add(order);
                dbContext.SaveChanges();
                order = dbContext.Orders.Include("orderCategories").SingleOrDefault(o => o.Id == 1);
                order.AddCategory(new Category() {Id = 1});
                dbContext.Orders.Add(order);
                var affected = dbContext.SaveChanges();
                Console.WriteLine(affected == 2 ? "Expected amount of objects saved" : "affected count is not 2 ");
            }
        }

        private static void OneToMany()
        {
            using (var context = new OneToManyDbContext())
            {
                context.Database.Migrate();
                if (!context.States.Any())
                {
                    context.States.AddRange(State.GetStatus());
                    context.SaveChanges();
                }
                var order = new OneToMany.Order();
                context.Orders.Add(order);
                context.SaveChanges();
                var order2 = context.Orders.Include("State").First();
                order2.Release();
                context.SaveChanges();
                var order3 = context.Orders.First();
            }
        }
    }
}
