using System.ComponentModel.DataAnnotations;

namespace LexiconMVCEndProject.Models
{
    public class Receipt
    {
        [Key]
        public int ReceiptId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime ReceiptDate { get; set; }
        public string OrderDate { get; set; }
        public double TotalCost { get; set; }

        //public string ProductName { get; set; }
        //public string ProductDescription { get; set; }
        //public string ProductPrice { get; set; }

        //public List<string> productDetails { get; set; } = new List<string>();
        //public static List<string> newReceipt(string ProductName, string ProductDescription, string ProductPrice)
        //{

        //    productDetails.Add(ProductName);
        //    productDetails.Add(ProductDescription);
        //    productDetails.Add(ProductPrice);

        //    return productDetails;
        //}

       


 

    }
}
