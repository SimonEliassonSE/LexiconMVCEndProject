using System.ComponentModel.DataAnnotations;

namespace LexiconMVCEndProject.Models
{
    public class CreditCard
    {
        [Key]
        public int CCId { get; set; }
        public string CreditNumber{ get; set; }
        public string CCV { get; set; }
        public string Bank { get; set; }
        public double Value { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
