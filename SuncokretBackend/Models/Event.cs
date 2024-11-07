namespace SuncokretBackend.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string? EventName { get; set; }
        public string? EventDescription { get; set; } 
        public string? EventFacebookURL { get; set; }
        public string? EventAddress { get; set; }
        public DateTime EventDate { get; set; }

        public int ManufacturerID { get; set; }
        public Manufacturer? Manufacturer { get; set; } // Foreign key relationship
        //kolekcija proizvoda

    }
}
