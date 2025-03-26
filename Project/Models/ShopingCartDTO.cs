using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class ShopingCartDTO
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
