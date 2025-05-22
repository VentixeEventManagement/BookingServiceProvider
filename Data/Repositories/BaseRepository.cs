using Azure;
using Data.Contexts;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context;
    protected readonly DbSet<TEntity> _table;
    protected BaseRepository(DataContext context)
    {
        _context = context;
        _table = context.Set<TEntity>();
    }

    public virtual async Task<RepositoryResponse<IEnumerable<TEntity>>> GetAllAsync()
    {
        try
        {
            var entities = await _table.ToListAsync();
            return new RepositoryResponse<IEnumerable<TEntity>> { Success = true, Response = entities };
        }
        catch (Exception ex)
        {
            return new RepositoryResponse<IEnumerable<TEntity>>
            {
                Success = false,
                Error = ex.Message,
            };
        }
    }

    public virtual async Task<RepositoryResponse<TEntity?>> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _table.FirstOrDefaultAsync(expression) ?? throw new Exception("Not Found.");
            return new RepositoryResponse<TEntity?> { Success = true, Response = entity };
        }
        catch (Exception ex)
        {
            return new RepositoryResponse<TEntity?>
            {
                Success = false,
                Error = ex.Message
            };
        }
    }

    public virtual async Task<RepositoryResponse> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        var Response = await _table.AnyAsync(expression);
        return Response
            ? new RepositoryResponse { Success = true }
            : new RepositoryResponse { Success = false, Error = "NotFound" };
    }

    public virtual async Task<RepositoryResponse> AddAsync(TEntity entity)
    {
        try
        {
            _table.Add(entity);
            await _context.SaveChangesAsync();
            return new RepositoryResponse { Success = true };
        }
        catch (Exception ex)
        {
            return new RepositoryResponse
            {
                Success = false,
                Error = ex.Message
            };
        }
    }

    public virtual async Task<RepositoryResponse> UpdateAsync(TEntity entity)
    {
        try
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();
            return new RepositoryResponse { Success = true };
        }
        catch (Exception ex)
        {
            return new RepositoryResponse
            {
                Success = false,
                Error = ex.Message,
            };
        }
    }

    public virtual async Task<RepositoryResponse> DeleteAsync(TEntity entity)
    {
        try
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();
            return new RepositoryResponse { Success = true };
        }
        catch (Exception ex)
        {
            return new RepositoryResponse
            {
                Success = false,
                Error = ex.Message
            };
        }
    }
}