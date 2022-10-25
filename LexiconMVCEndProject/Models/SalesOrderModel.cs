using System.ComponentModel.DataAnnotations;

namespace LexiconMVCEndProject.Models
{
    public class SalesOrderModel
    {
        [Key]
        public int SalesOrderId { get; set; }

        public int CartId { get; set; }

        public CartModel Cart { get; set; }

        public int CustomerId { get; set; }

        public CustomerModel Customer { get; set; }

    }
}
