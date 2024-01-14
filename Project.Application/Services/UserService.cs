using Ardalis.Result;
using AutoMapper;
using Project.Application.Interfaces;
using Project.Application.Pagination;
using Project.Core.Entities;
using Project.Core.Iterfaces;
using Project.Shared.Dtos;
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
        private readonly IMapper _mapper;

        public UserService(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public Task<User> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _user.GetAllAsync();
        }

        public async Task<PagedList<User>> GetPagedAsync(int pageNumber, int pageSize, string search = null)
        {
            if (search == null)
                return await _user.GetPagedAsync(pageNumber, pageSize);

            return await _user.GetPagedAsync(pageNumber, pageSize, u => u.Name.Equals(search) || u.DocumentNumber.Equals(search));
        }

        public async Task<Result<User>> UpdateAsync(User user)
        {
            var result = await _user.UpdateAsync(user);

            if (!result)
                return Result.Error("Erro ao  atualizar entidade");

            return Result.Success(user);  
        }

        public async Task<Result<bool>> AddUserAsync(UserAddDto userDto)
        {
            var entity = _mapper.Map<User>(userDto);

            var result = await _user.AddAsync(entity);

            if (!result)
                return Result.Error("Erro ao adicionar entidade");

            return Result.Success(result);

        }
    }
}
