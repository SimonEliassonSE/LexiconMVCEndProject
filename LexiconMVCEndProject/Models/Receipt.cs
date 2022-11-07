using System.ComponentModel.DataAnnotations;

namespace LexiconMVCEndProject.Models
{
    public class Receipt
    {

        [Key]
        public string ReceiptId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string OrderDate { get; set; }
        public double TotalCost { get; set; }

        public List<ReceiptItem> ReceiptItems { get; set; } = new List<ReceiptItem>();

        // Create a class called ReciptItem Contaning al the values you need in recipt for the orderd products
        // List<ReciptItem> ReciptItems {get; set;}
        // Ones this is done addmigration and update database

    }
}
