using Ardalis.Result;
using Project.Application.Pagination;
using Project.Core.Entities;
using Project.Core.Iterfaces;
using Project.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Interfaces
{
    public interface IUserService 
    {      
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetByIdAsync(Guid Id);
        Task<Result<User>> UpdateAsync(User user);
        Task<Result<bool>> AddUserAsync(UserAddDto user);
        Task<PagedList<User>> GetPagedAsync(int pageNumber, int pageSize, string search = "");
    }
}
