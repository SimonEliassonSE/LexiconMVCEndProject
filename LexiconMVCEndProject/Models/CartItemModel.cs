using System.ComponentModel.DataAnnotations;

namespace LexiconMVCEndProject.Models
{
    public class CartItemModel
    {
        [Key]
        public int CartItemId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public int CartId { get; set; }

        public CartModel Cart { get; set; }

        public int ProductId { get; set; }

        public ProductModel Product { get; set; }
    }
}
