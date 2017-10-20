using System.Collections.Generic;
using System.Linq;

namespace EFCore2Playgrounds.Model.ManyToMany
{
    public class Order
    {
        public int Id { get; set; }
        internal List<OrderCategory> orderCategories { get; set; } = new List<OrderCategory>();

        public IEnumerable<Category> GetCategories()
        {
            return orderCategories.Select(x => x.Category);
        }

        public void AddCategory(Category category)
        {
            orderCategories.Add(new OrderCategory {CategoryId = category.Id, Order = this});
        }
    }
}