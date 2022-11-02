namespace LexiconMVCEndProject.Models
{
    public class TempCart
    {
       public double TotalPrice { get; set; }

        //we need a Cart and the Cart needs a customer to be created, so we will use a list of products instead
        public List<Product> productTempList = new List<Product>();

    }
}
