using clean_architecture_dotnet.Application.Services.Login.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clean_architecture_dotnet.Api.Controllers.V1.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("GetLogin")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLogin(string email)
        {
            var response = await _loginService.GetLogin(email);

            if(response.StatusCode == 400)
                return NotFound(response);

            if (response.StatusCode == 500)
                return BadRequest(response);

            return Ok(response);

        }
    }
}
