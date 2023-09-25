using MainAssessment.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MainAssessment.Services
{
    public class UserAuthenticationService
    {
        public UserAuthenticationService() { }

        public ClaimsPrincipal AuthenticateUser(User user)
        {
            if (user.name == "test" && user.password == "test")
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Role, "User") };

                var identity = new ClaimsIdentity(claims, "CookieAuthentication");

                var claimsPrincipal = new ClaimsPrincipal(identity);

                return claimsPrincipal;
                              

            }
            else
            {
                throw new Exception("unauthorized User");
            }

        }
    }
}
