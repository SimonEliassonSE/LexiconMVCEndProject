using System.ComponentModel.DataAnnotations;

namespace LexiconMVCEndProject.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } 

        public List<ProductModel> Products { get; set; }
    }

}
