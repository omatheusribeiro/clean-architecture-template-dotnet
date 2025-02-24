﻿using clean_architecture_dotnet.Application.Services.Users.Interfaces;
using clean_architecture_dotnet.Application.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clean_architecture_dotnet.Api.Controllers.V1.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userService.GetAll();

            if(response.StatusCode == 400)
                return NotFound(response);

            return Ok(response);

        }

        [HttpGet("GetUserById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _userService.GetById(id);

            if (response.StatusCode == 400)
                return NotFound(response);

            return Ok(response);

        }

        [HttpPut("PutUser")]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> Put([FromBody] UserViewModel user)
        {
            var response = await _userService.Put(user);

            return Ok(response);
        }

        [HttpPost("PostUser")]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> Post([FromBody] UserViewModel user)
        {
            var response = await _userService.Post(user);

            return Ok(response);
        }

        [HttpDelete("DeleteUser")]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> Delete([FromBody] UserViewModel user)
        {
            var response = await _userService.Delete(user);

            return Ok(response);
        }
    }
}
