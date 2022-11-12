using System.ComponentModel.DataAnnotations;

namespace LexiconMVCEndProject.Models
{
    public class ReceiptItem
    {
        [Key]
        public int ReceiptItemId { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string Description { get; set; }

        public string IMG { get; set; }

        public string Brand { get; set; }

        public int ReceiptId { get; set; }

        public Receipt Receipt { get; set; }
    }
}
