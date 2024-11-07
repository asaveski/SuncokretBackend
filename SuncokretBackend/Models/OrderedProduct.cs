using System.ComponentModel.DataAnnotations.Schema;

namespace SuncokretBackend.Models
{
    public class OrderedProduct
    {
        public int OrderedProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; } // TEXT
        
        [Column(TypeName = "decimal(10, 2)")] 
        public decimal ProductPrice { get; set; }
        
        public int Quantity { get; set; }

        public int ProductID { get; set; }
        public Product? Product { get; set; } // Foreign key relationship

        public int CartID { get; set; }
        public Cart? Cart { get; set; } // Foreign key relationship
    }
}
