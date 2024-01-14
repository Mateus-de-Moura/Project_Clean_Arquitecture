using Microsoft.AspNetCore.Mvc;
using Project.Application.Interfaces;
using Project.Core.Entities;
using Project.Models;
using Project.Shared.Dtos;

namespace Project.Controllers
{
    [ApiController]
    [Route("v1")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _User;
        public UserController(IUserService user)
        {
            _User = user;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _User.GetUsersAsync();

            if (result is not null)
                return Ok(result);
            else 
                return BadRequest();    
        }

        [HttpGet("GetPaged")]
        public async Task<IActionResult> GetUsersPagined([FromQuery]PaginationParams paginationParams)
        {
            var usersPaginate = await _User.GetPagedAsync(paginationParams.pageNumber, paginationParams.pageSize, paginationParams.Search);

            return Ok(usersPaginate);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(UserAddDto user)
        {
            var result = await _User.AddUserAsync(user);

            if (result.IsSuccess)
                return Ok("Usuário adicionado");
            else
                return BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(User user)
        {
            var result = await _User.UpdateAsync(user);

            return Ok(result);
        }
    }
}
