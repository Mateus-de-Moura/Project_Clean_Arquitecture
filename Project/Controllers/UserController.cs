using Microsoft.AspNetCore.Mvc;
using Project.Application.Interfaces;
using Project.Models;

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


        [HttpGet("Users")]
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
    }
}
