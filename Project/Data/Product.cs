namespace Project.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int? ShopingCartId { get; set; }
        public virtual ShopingCart ShopingCart { get; set; }
    }
}
