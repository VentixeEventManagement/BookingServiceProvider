using Data.Models;
using System.Linq.Expressions;

namespace Data.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<RepositoryResponse> AddAsync(TEntity entity);
        Task<RepositoryResponse> DeleteAsync(TEntity entity);
        Task<RepositoryResponse> ExistsAsync(Expression<Func<TEntity, bool>> expression);
        Task<RepositoryResponse<IEnumerable<TEntity>>> GetAllAsync();
        Task<RepositoryResponse<TEntity?>> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<RepositoryResponse> UpdateAsync(TEntity entity);
    }
}