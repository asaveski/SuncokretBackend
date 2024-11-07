namespace SuncokretBackend.Models
{
    public class CategorizedProduct
    {
        public int ProductID { get; set; }
        public Product? Product { get; set; } // Foreign key relationship
        public int CategoryID { get; set; }
        public Category? Category { get; set; } // Foreign key relationship
    }
}
