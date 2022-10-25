using System.ComponentModel.DataAnnotations;

namespace LexiconMVCEndProject.Models
{
    public class CartModel
    {
        [Key]
        public int CartId { get; set; }

        public double TotalPrice { get; set; }

        public List<CartItemModel> CartItems { get; set; }
    }
}
