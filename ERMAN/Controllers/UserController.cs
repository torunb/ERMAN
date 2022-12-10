using ERMAN.Models;
using ERMAN.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        //[HttpGet(Name = "UserGetAll")]
        //public List<User> Get()
        //{
        //    return _userService.GetAll();
        //}
    }
}
