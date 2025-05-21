using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Entities;

public class BookingEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public string EventId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public decimal TicketPrice { get; set; }
    public int TicketCount { get; set; } = 1;

    [ForeignKey(nameof(BookingClient))]
    public string? BookingClientId { get; set; }
    public BookingClientEntity? BookingClient { get; set; }
}


