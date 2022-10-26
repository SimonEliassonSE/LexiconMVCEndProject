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

        public List<CreditCard> CreditCardList { get; set; }
        public Cart Cart { get; set; }

        public Receipt Receipt { get; set; }

        //public int OrderHistoryId { get; set; }

        //public OrderHistory OrderHistory { get; set; }
        //public List<SalesOrder> SalesOrderList { get; set; }

        //public SalesOrder SalesOrder { get; set; }
    }
}
