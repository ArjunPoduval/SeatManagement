using MainAssessment.DTO;
using MainAssessment.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MainAssessment.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class UserAuthController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> Authenticate(User user)
        {
            try
            {
                UserAuthenticationService userAuth = new();
                System.Security.Claims.ClaimsPrincipal claimsPrincipal = userAuth.AuthenticateUser(user);
                await HttpContext.SignInAsync("CookieAuthentication", claimsPrincipal);
                return Ok();
            }
            catch (Exception)
            {
                await HttpContext.SignOutAsync("CookieAuthentication");

                return Unauthorized();
            }
        }
    }
}
