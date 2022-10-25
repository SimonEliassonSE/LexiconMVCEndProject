using System.ComponentModel.DataAnnotations;

namespace LexiconMVCEndProject.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public double TotalPrice { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
