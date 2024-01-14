using Project.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Iterfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<PagedList<T>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> expression = null);
        Task<T> GetAsync(Guid id);
        Task<T> AddAsync(T entity ); 
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(Guid id);
        
    }
}
