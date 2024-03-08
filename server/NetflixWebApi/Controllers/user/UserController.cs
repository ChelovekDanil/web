﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Application.Service;
using Netflix.Domain.Interface.Services;
using Netflix.Domain.Models;

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
        [ProducesResponseType<UsersTodo>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<string>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserAsync(string Username)
        {
            if (Username is null)
            {
                return BadRequest("invalid data");
            }

            var response = await _userService.GetUserAsync(Username);

            if (response is null)
            {
                return StatusCode(500, "server error ;(");
            }

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType<UsersTodo>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<string>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUserAsync(string Username, string Password)
        {
            if (Username is null || Password is null)
            {
                return BadRequest("invalid data");
            }

            var resonse = await _userService.CreateUserAsync(Username, Password);
            
            if (resonse is null)
            {
                return StatusCode(500, "Server error :(");
            }

            return Ok(resonse);
        }

        [HttpPut]
        [ProducesResponseType<string>(StatusCodes.Status201Created)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<string>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUserAsync(string Username, string NewUsername)
        {
            if (Username is null || NewUsername is null)
            {
                return BadRequest("invalid data");
            }

            var response = await _userService.UpdateUserAsync(Username, NewUsername);

            if (response is null)
            {
                return StatusCode(500, "server error ^(");
            }

            return StatusCode(201, response);
        }

        [HttpDelete]
        [ProducesResponseType<int>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<string>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUserAsync(string Username)
        {
            if (Username is null)
            {
                return BadRequest("invalid data");
            }

            var response = await _userService.DeleteUserAsync(Username);

            if (response == 0)
            {
                return StatusCode(500, "user not found");
            }

            return Ok(response);
        }
    }
}