namespace LexiconMVCEndProject.Models
{
    public class TempCart
    {
       public double TotalPrice { get; set; }

        public string errorMessage { get; set; }

        public List<Product> productTempList = new List<Product>();

    }
}
