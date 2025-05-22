using Data.Entities;
using Data.Models;
using Data.Repository;
using System.Linq.Expressions;

namespace Data.Repositories;

public interface IBookingRepository : IBaseRepository<BookingEntity>
{
    Task<RepositoryResponse<BookingEntity?>> GetAsync(Expression<Func<BookingEntity>> expression);
}
