using LexiconMVCEndProject.Models;

namespace LexiconMVCEndProject.ViewModels
{
    public class AddCreditCardViewModel
    {
        public int CCId { get; set; }
        public string CreditNumber { get; set; }
        public string CCV { get; set; }
        public string Bank { get; set; }
        public double Value { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<CreditCard> Creditcards { get; set; }

    }
}
