using Microsoft.AspNetCore.Mvc;
using QualityManagement.API.Filters;
using QualityManagement.API.Resources;

namespace QualityManagement.API.Controllers.v1.Authentication
{
    [ApiController]
    [Route("[controller]")]
    [MicrosoftTokenFilter]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet("access_token")]
        public IActionResult GetAccessToken()
        {
            return Ok(TokenConfigurator.CreateToken());
        }
    }
}