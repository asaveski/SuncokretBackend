using System.ComponentModel.DataAnnotations.Schema;

namespace SuncokretBackend.Models
{
    public class ProductPromotion
    {
        public int ProductPromotionID { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; } // Foreign key relationship
        
        [Column(TypeName = "decimal(10, 2)")] 
        public decimal NewPrice { get; set; }
        public DateTime PromotionStartDate { get; set; }
        public DateTime PromotionEndDate { get; set; }
    }
}
