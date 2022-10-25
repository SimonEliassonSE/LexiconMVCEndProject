using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexiconMVCEndProject.Models
{
    public class Customer
    {
        
        [Key]
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        //public int CartId { get; set; }
        //[ForeignKey ("CartId")]
        public Cart Cart { get; set; }

        public List<SalesOrder> SalesOrders { get; set; }

        //public SalesOrder SalesOrder { get; set; }



    }
}
