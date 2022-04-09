using CrudUser.Dtos;
using CrudUser.Dtos.Users;
using CrudUser.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace CrudUser.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "GetUsers")]
        [ProducesResponseType(typeof(UserDto[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            return user is not null ? Ok(user) : NotFound(new Error("Hubó un error"));
        }

        [HttpPost(Name = "CreateUser")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateUserInput input)
        {
            var user = await _userService.CreateAsync(input);

            return user is not null ? Ok(user) : BadRequest(new Error("Hubó un error"));
        }

        [HttpPut(Name = "UpdateUser")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UserDto user)
        {
            user = await _userService.UpdateAsync(user);

            return user is not null ? Ok(user) : BadRequest(new Error("Hubó un error"));
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.DeleteAsync(id);

            return user is not null ? Ok(user) : BadRequest(new Error("Hubó un error"));
        }
    }
}
