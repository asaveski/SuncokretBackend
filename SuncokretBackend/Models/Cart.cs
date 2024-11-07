namespace SuncokretBackend.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public int CustomerID { get; set; }
        public Customer? Customer { get; set; } // Foreign key relationship
        public string? EmailAddress { get; set; }
        public DateTime OrderDate { get; set; }

        public int AddressID { get; set; }
        public Address? Address { get; set; } // Foreign key relationship

        public ICollection<OrderedProduct>? OrderedProducts { get; set; }
    }
}
