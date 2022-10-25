using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexiconMVCEndProject.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public double TotalPrice { get; set; }

        public List<CartItem> CartItems { get; set; }


        public int CustomerId { get; set; }
  
        public Customer Customer { get; set; }


        //public int SalesOrderId { get; set; }

        public SalesOrder SalesOrder { get; set; }
    }
}
