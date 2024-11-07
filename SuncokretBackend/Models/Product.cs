using System.ComponentModel.DataAnnotations.Schema;

namespace SuncokretBackend.Models
{
    public class Product
    { 
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; } 
        public string? Size { get; set; }
        
        [Column(TypeName = "decimal(10, 2)")] 
        public decimal ProductPrice { get; set; }
        
        public string? ProductFacebookURL { get; set; }
        public bool ProductAvailability { get; set; }

        public int ManufacturerID { get; set; }
        
        // Navigation property
        public Manufacturer Manufacturer { get; set; } = null!; // Foreign key relationship, ensures non-null

        // Navigation properties
        public ICollection<ProductPromotion> Promotions { get; set; } = new List<ProductPromotion>();
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<CategorizedProduct>? CategorizedProducts { get; set; } // For many-to-many relationship with Category

    }
}
