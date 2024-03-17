using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Application.Service;
using Netflix.Domain.Interface.Services;
using Netflix.Domain.Models;
using NetflixWebApi.Constract;

namespace NetflixWebApi.Controllers.user
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType<UserResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserAsync(string Username)
        {
            if (Username is null)
            {
                return BadRequest("invalid data");
            }

            var response = await _userService.GetUserAsync(Username);

            if (response is null)
            {
                return BadRequest("user not founded");
            }

            return Ok(new UserResponse(response.Id, response.Username));
        }

        [HttpPost]
        [ProducesResponseType<UsersTodo>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUserAsync(string Username, string Password)
        {
            if (Username is null || Password is null)
            {
                return BadRequest("invalid data");
            }

            var response = await _userService.CreateUserAsync(Username, Password);
            
            if (response is null)
            {
                return BadRequest("Server error :(");
            }

            return Ok(new UserResponse(response.Id, response.Username));
        }

        [HttpPut]
        [ProducesResponseType<string>(StatusCodes.Status201Created)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserRequest updateUser)
        {
            if (updateUser.Username is null || updateUser.NewUsername is null)
            {
                return BadRequest("invalid data");
            }

            var response = await _userService.UpdateUserAsync(updateUser.Username, updateUser.NewUsername);

            if (response is null)
            {
                return BadRequest("server error ^(");
            }

            return StatusCode(201, response);
        }

        [HttpDelete]
        [ProducesResponseType<int>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUserAsync(string Username)
        {
            if (Username is null)
            {
                return BadRequest("invalid data");
            }

            var response = await _userService.DeleteUserAsync(Username);

            if (response == 0)
            {
                return BadRequest("user not found");
            }

            return Ok(response);
        }
    }
}
