namespace EFCore2Playgrounds.ManyToMany
{
    public class OrderCategory
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}