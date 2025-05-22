namespace Business.Models
{
    public class UpdateBookingRequest
    {
        public string EventId { get; set; } = null!;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; } = null!;
        public decimal TicketPrice { get; set; }
        public int TicketCount { get; set; } = 1;
        public decimal TotalAmount { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
    }
}