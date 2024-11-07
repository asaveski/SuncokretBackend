namespace SuncokretBackend.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public byte[]? CategoryImage { get; set; } // VARBINARY

        // Navigation property for many-to-many relationship
        public ICollection<CategorizedProduct>? CategorizedProducts { get; set; }
    }
}
