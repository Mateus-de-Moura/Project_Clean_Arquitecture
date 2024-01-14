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
using Project.Shared.Entity;

namespace Project.Infrastructure.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public readonly DbSet<T> _DbSet;
        public readonly AppDbContext _AppDbContext;

        public BaseRepository(AppDbContext appDbContext)
        {
            _DbSet = appDbContext.Set<T>(); 
            _AppDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _DbSet.AddAsync(entity);

                var rows = await _AppDbContext.SaveChangesAsync();

                return rows > 0;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado ao adicionar entidade: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);
            _DbSet.Remove(entity);
            var rows = await _AppDbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _DbSet.ToListAsync();
        }

        public async Task<T> GetAsync(Guid id) => await _DbSet.FirstOrDefaultAsync(u => u.Id == id);
        

        public async Task<PagedList<T>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> expression = null)
        {
            var query = _DbSet.AsQueryable();
            query = expression is null ? query : query.Where(expression);

            var count = await query.CountAsync();
            var paged = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedList<T>(paged, pageNumber, pageSize, count);
           
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _DbSet.Update(entity);
            var rows = await _AppDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }

}
