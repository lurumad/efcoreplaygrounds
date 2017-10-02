using System.Collections.Generic;

namespace EFCore2Playgrounds.ManyToMany
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        internal List<OrderCategory> orderCategories { get; set; } = new List<OrderCategory>();
    }
}