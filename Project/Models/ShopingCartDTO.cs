using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class ShopingCartDTO
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public virtual ICollection<Product> Products { get; set; }
    }
}
