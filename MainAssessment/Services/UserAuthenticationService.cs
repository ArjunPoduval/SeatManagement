using MainAssessment.DTO;
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
                List<Claim> claims = new() { new Claim(ClaimTypes.Role, "User") };

                ClaimsIdentity identity = new(claims, "CookieAuthentication");

                ClaimsPrincipal claimsPrincipal = new(identity);

                return claimsPrincipal;


            }
            else
            {
                throw new Exception("unauthorized User");
            }

        }
    }
}
