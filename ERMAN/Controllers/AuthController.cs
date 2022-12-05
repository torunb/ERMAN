using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ErmanDbContext _dbContext;

        public AuthController(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public class LoginRequest
        {
            public string email { get; set; }
            public string password { get; set; }
        }

            [HttpPost("/api/login", Name = "AuthLogin")]
        public ActionResult<bool> Login(LoginRequest loginData)
        {            
                // Use Input.Email and Input.Password to authenticate the user
                // with your custom authentication logic.
                //
                // For demonstration purposes, the sample validates the user
                // on the email address maria.rodriguez@contoso.com with 
                // any password that passes model validation.

                var user = AuthenticateUser(loginData.email, loginData.password);

                if (user == false)
                {
                    return StatusCode(400);
                }

                Console.WriteLine("asdas");


                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "student"),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.
                    IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return StatusCode(200);
        }

        [HttpPost("/api/logout", Name = "Logout")]
        public async void Logout()
        {
            if(HttpContext.User.Identity.IsAuthenticated)
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        }

        private bool AuthenticateUser(string email, string passwordHash)
        {
            // For demonstration purposes, authenticate a user
            // with a static email address. Ignore the password.
            // Assume that checking the database takes 500ms
            var user = _dbContext.AuthenticationTable.Where(x => x.Username == email).First();

            if (user != null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(passwordHash, user.Password);
                return verified;
            }
            else {
                return false;
            }
        }
    }
}
