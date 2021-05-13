using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CrudUser.Dtos.Users;
using CrudUser.Services;

namespace CrudUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDto user)
        {
            user = await _userService.CreateAsync(user);

            return user is null ? BadRequest() : Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto user)
        {
            user = await _userService.UpdateAsync(user);

            return user is null ? BadRequest() : Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.DeleteAsync(id);

            return user is null ? BadRequest() : Ok(user);
        }
    }
}
