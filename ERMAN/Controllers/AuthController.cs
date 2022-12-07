using ERMAN.Models;
using ERMAN.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Data;

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

        public class RegisterRequest
        {
            public string email { get; set; }
            public string password { get; set; }
            public string role { get; set; }
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

                var userId = AuthenticateUser(loginData.email, loginData.password);

                if (userId == null)
                {
                    // user does not exists or wrong password
                    return StatusCode(400);
                }

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, "student"),
                        new Claim(type: "userID", value: userId.ToString()) // this userID is never null here because if it is null then we early return above
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

        [HttpPost("/api/register", Name = "AuthRegister")]
        public ActionResult<bool> Register(RegisterRequest registerData)
        {
            var user = _dbContext.AuthenticationTable.Where(x => x.Username == registerData.email).FirstOrDefault();

            if (user != null)
            {
                // there is already a user with that username            
                return StatusCode(400);
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerData.password);

            var newUser = new Authentication
            {
                Username = registerData.email,
                Password = passwordHash,
                Type = UserType.Student,
            };
            _dbContext.AuthenticationTable.Add(newUser);
            _dbContext.SaveChanges();

            return StatusCode(200);
        }

        [Authorize(Roles = "student")]
        [HttpPost("/api/logout", Name = "Logout")]
        public async void Logout()
        {
            if (HttpContext.User.Identity.IsAuthenticated) {
                Console.WriteLine(string.Join("\t", HttpContext.User.Claims.ToList()));

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }

        private Nullable<int> AuthenticateUser(string email, string passwordHash)
        {
            // For demonstration purposes, authenticate a user
            // with a static email address. Ignore the password.
            // Assume that checking the database takes 500ms
            var user = _dbContext.AuthenticationTable.Where(x => x.Username == email).FirstOrDefault();

            if (user != null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(passwordHash, user.Password);
                return user.Id;
            }
            else {
                return null;
            }
        }
    }
}
