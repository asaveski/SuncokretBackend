namespace SuncokretBackend.Models
{
    public class Manufacturer
    {
        public int ManufacturerID { get; set; }
        public string? ManufacturerName { get; set; }
        public byte[]? ManufacturerLogo { get; set; }

        public ICollection<Product>? Products { get; set; } // One-to-many relationship

        //kolekcija dogadjaja
    }
}
