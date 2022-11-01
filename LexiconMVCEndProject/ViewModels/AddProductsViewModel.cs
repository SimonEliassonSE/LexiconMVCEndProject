using LexiconMVCEndProject.Models;

namespace LexiconMVCEndProject.ViewModels
{
    public class AddProductsViewModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int ProductSaldo { get; set; }

        public string IMG { get; set; }
        public string Brand { get; set; }

        public int CategoryID { get; set; }

        //public Category Category { get; set; }

        public List<Product> Products { get; set; }
    }
}
