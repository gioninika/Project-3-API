namespace Project.Models
{
    public class ShopingCart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
