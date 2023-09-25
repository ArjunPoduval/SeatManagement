using MainAssessment.DTO;
using MainAssessment.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MainAssessment.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class UserController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> Authenticate(User user)
        {
            try
            {
                var userAuth = new UserAuthenticationService();
                var claimsPrincipal = userAuth.AuthenticateUser(user);
                await HttpContext.SignInAsync("CookieAuthentication", claimsPrincipal);
                return Ok();
            }
            catch (Exception ex)
            {
                await HttpContext.SignOutAsync("CookieAuthentication");

                return Unauthorized();
            }
        }
    }
}
