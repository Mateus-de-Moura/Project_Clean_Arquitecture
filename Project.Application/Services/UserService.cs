using Project.Application.Interfaces;
using Project.Application.Pagination;
using Project.Core.Entities;
using Project.Core.Iterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Services
{
    internal class UserService : IUserService
    {
        private readonly IUser _user;

        public UserService(IUser user)
        {
            _user = user;
        }

        public Task<User> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _user.GetAllAsync();
        }

        public async Task<PagedList<User>> GetPagedAsync(int pageNumber, int pageSize,  string search = null)
        {
            if (search == null)
                return await _user.GetPagedAsync(pageNumber, pageSize);

            return await _user.GetPagedAsync(pageNumber, pageSize, u => u.Name.Equals(search) || u.DocumentNumber.Equals(search));
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
