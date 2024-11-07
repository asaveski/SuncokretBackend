namespace SuncokretBackend.Models
{
    public class ProductImage
    {
        public int ProductImageID { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; } // Foreign key relationship
        public byte[]? Image { get; set; } // VARBINARY
        public string? ErrorText { get; set; }
    }
}
