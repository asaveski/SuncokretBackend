namespace SuncokretBackend.Models
{
    public class CartStatus
    {
        public int CartStatusID { get; set; }
        public int CartID { get; set; }
        public Cart? Cart { get; set; } // Foreign key relationship
        public string? CartStatusDescription { get; set; }
    }
}
