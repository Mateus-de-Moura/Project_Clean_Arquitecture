using Microsoft.EntityFrameworkCore;
using Project.Core.Iterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using Project.Application.Pagination;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Project.Infrastructure.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public readonly DbSet<T> _DbSet;
        public readonly AppDbContext _AppDbContext;

        public BaseRepository(AppDbContext appDbContext)
        {
            _DbSet = appDbContext.Set<T>(); 
            _AppDbContext = appDbContext;
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _DbSet.ToListAsync();
        }

        public Task<T> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<T>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> expression = null)
        {
            var query = _DbSet.AsQueryable();
            query = expression is null ? query : query.Where(expression);

            var count = await query.CountAsync();
            var paged = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedList<T>(paged, pageNumber, pageSize, count);
           
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }

}
