using LexiconMVCEndProject.Models;

namespace LexiconMVCEndProject.ViewModels
{
    public class AddCustomerViewModel
    {
        //public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string ApplicationUserId { get; set; }

        public List<Customer> Customers { get; set; }

    }
}
