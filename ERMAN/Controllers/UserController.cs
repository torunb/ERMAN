using ERMAN.Models;
using ERMAN.Dtos;
using ERMAN.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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

        [HttpGet("/api/user-info", Name = "UserGetInfo")]
        [Authorize]
        public UserInfoDTO Get()
        {
            var userId = (int) HttpContext.Items["userID"];
            var userInfo = _userService.Get(userId);

            return userInfo;
        }

        [HttpGet("/api/user-info/all", Name = "UserGetInfo")]
        [Authorize]
        public List<UserInfoDTO> GetAll()
        {
            var usersInfo = _userService.GetAll();
            return usersInfo;
        }

        //[HttpGet(Name = "UserGetAll")]
        //public List<User> Get()
        //{
        //    return _userService.GetAll();
        //}
    }
}
