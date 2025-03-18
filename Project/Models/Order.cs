namespace Project.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateOnly OrderDate { get; set; }
        public int CustomerId { get; set; }
        public double TotalAmount { get; set; }
    }
}
