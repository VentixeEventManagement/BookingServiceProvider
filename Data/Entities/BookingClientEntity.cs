using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Entities;

public class  BookingClientEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;

    [ForeignKey(nameof(BookingLocation))]
    public string? BookingLocationId { get; set; }
    public BookingLocationEntity? BookingLocation { get; set; }
}


