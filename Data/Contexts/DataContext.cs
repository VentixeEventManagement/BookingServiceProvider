using Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<BookingEntity> Bookings { get; set; }
    public DbSet<BookingClientEntity> BookingClients { get; set; }
    public DbSet<BookingLocationEntity> BookingLocations { get; set; }    
}
