namespace Project.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateOnly OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public int? ShopingCartId { get; set; }
        public virtual ShopingCart ShopingCart { get; set; }
    }
}
