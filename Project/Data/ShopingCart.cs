namespace Project.Models
{
    public class ShopingCart
    {
        public int Id { get; set; }
        public virtual Customer CustomerId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
    