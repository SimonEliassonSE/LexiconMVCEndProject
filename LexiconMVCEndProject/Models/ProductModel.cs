using System.ComponentModel.DataAnnotations;

namespace LexiconMVCEndProject.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int ProductSaldo { get; set; }

        public string IMG { get; set; }

        public int CategoryID { get; set; }

        public CategoryModel Category { get; set; }

    }
}
