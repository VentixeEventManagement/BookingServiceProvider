using Business.Models;
using Data.Entities;
using Data.Models;

namespace Business.Services
{
    public interface IBookingService
    {
        Task<RepositoryResponse> CreateBookingAsync(CreateBookingRequest request);
        Task<RepositoryResponse<IEnumerable<BookingEntity>>> GetAllBookingsAsync();
        Task<RepositoryResponse<BookingEntity?>> GetBookingByIdAsync(string id);
        Task<RepositoryResponse> UpdateBookingAsync(string id, UpdateBookingRequest request);
        Task<RepositoryResponse> DeleteBookingAsync(string id);
    }
}