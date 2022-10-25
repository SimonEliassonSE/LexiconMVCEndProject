using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace LexiconMVCEndProject.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int ProductSaldo { get; set; }

        public Image IMG { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }

    }
}
