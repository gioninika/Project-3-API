using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        [Required]
        public DateOnly OrderDate { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public double TotalAmount { get; set; }
    }
}
