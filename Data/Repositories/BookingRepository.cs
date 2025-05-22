using Data.Contexts;
using Data.Entities;
using Data.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class BookingRepository(DataContext context) : BaseRepository<BookingEntity>(context), IBookingRepository
{
    public override async Task<RepositoryResponse<IEnumerable<BookingEntity>>> GetAllAsync()
    {
        try 
        {
            var entities = await _table
                .Include(x => x.BookingClient)
                .ThenInclude(x => x!.BookingLocation)
                .ToListAsync();
            return new RepositoryResponse<IEnumerable<BookingEntity>> { Success = true, Response = entities };

        } catch (Exception ex)
        {
            return new RepositoryResponse<IEnumerable<BookingEntity>> 
            {
                Success = false,
                Error = ex.Message
            };
        }
    }

    public override async Task<RepositoryResponse<BookingEntity?>> GetAsync(Expression<Func<BookingEntity, bool>> expression)
    {
        try
        {
            var entity = await _table
                .Include(x => x.BookingClient)
                .ThenInclude(x => x!.BookingLocation)
                .FirstOrDefaultAsync(expression) ?? throw new Exception("Not Found.");
            return new RepositoryResponse<BookingEntity?> { Success = true, Response = entity };

        }
        catch (Exception ex)
        {
            return new RepositoryResponse<BookingEntity?>
            {
                Success = false,
                Error = ex.Message,
            };
        }
    }

}
