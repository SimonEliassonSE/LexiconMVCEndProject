using LexiconMVCEndProject.Models;

namespace LexiconMVCEndProject.ViewModels
{
    public class CartItemViewModel
    {

        public int Quantity { get; set; }

        public double Price { get; set; }

        public int CartId { get; set; }

        public Cart Cart { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }


        public List<CartItem> CartItems { get; set; }
    }
}
