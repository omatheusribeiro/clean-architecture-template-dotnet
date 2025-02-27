using clean_architecture_dotnet.Application.Services.Users.Interfaces;
using clean_architecture_dotnet.Application.ViewModels.Users;
using clean_architecture_dotnet.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clean_architecture_dotnet.Api.Controllers.V1.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContactController : ControllerBase
    {
        private readonly IUserContactService _userContactService;

        public UserContactController(IUserContactService userContactService)
        {
            _userContactService = userContactService;
        }

        [HttpPut("PutContact")]
        [Authorize]
        public async Task<ActionResult<UserContactViewModel>> Put([FromBody] UserContactViewModel contact)
        {
            var response = await _userContactService.Put(contact);

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
