using System.ComponentModel.DataAnnotations;

namespace LexiconMVCEndProject.Models
{
    public class SalesOrder
    {
        [Key]
        public int SalesOrderId { get; set; }

        public int CartId { get; set; }

        public Cart Cart { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

    }
}
