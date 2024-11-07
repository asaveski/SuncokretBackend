namespace SuncokretBackend.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; } // VARCHAR(10)
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; } // VARCHAR(20)

    }
}
