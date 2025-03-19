namespace Project.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int? ShopingCartId { get; set; }
        public virtual ShopingCart ShopingCart { get; set; }
    }
}
