namespace SuncokretBackend.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string? StreetName { get; set; }

        public string? City { get; set; }
        public int Number { get; set; }
        public string? AddressType { get; set; }

        public int CustomerID { get; set; }
        public Customer? Customer { get; set; } // Foreign key relationship
    }
}
