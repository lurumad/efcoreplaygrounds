using System;
using System.Linq;
using EFCore2Playgrounds.ManyToMany;
using EFCore2Playgrounds.OneToMany;
using Microsoft.EntityFrameworkCore;
using Order = EFCore2Playgrounds.ManyToMany.Order;
using EFCore2Playgrounds.ValueObject;
using EFCore2Playgrounds.OneToOne;

namespace EFCore2Playgrounds
{
    class Program
    {
        static void Main(string[] args)
        {
            //ManyToMany();

            //OneToMany();

            //ValueObject();

            OneToOne();

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
                var newOrder = new OneToMany.Order();
                context.Orders.Add(newOrder);
                context.SaveChanges();
                var order = context.Orders.Include(nameof(State)).First();
                order.Release();
                context.SaveChanges();
                order = context.Orders.First();
            }
        }

        private static void ValueObject()
        {
            using (var context = new ValueObjectDbContext())
            {
                context.Database.Migrate();
                var post = Post.New("DeveloperOS Madrid 2017");
                context.Posts.Add(post);
                context.SaveChanges();
                var order = context.Posts.First();
                Console.WriteLine(post.Slug);
            }
        }

        private static void OneToOne()
        {
            using (var context = new OneToOneDbContext())
            {
                context.Database.Migrate();
                var newAuthor = Author.New(Biography.New("Lorem ipsum..."));
                context.Authors.Add(newAuthor);
                context.SaveChanges();
                var author = context.Authors.Include(nameof(Author.Biography)).First();
            }
        }
    }
}
