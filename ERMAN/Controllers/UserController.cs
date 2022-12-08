using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepo;

        public UserController(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost(Name = "UserPost")]
        public void Post(UserDto user)
        {
            _userRepo.Add(user);
        }

        [HttpGet(Name = "UserGet")]
        public User Get(int id)
        {
            return _userRepo.Get(id);
        }

        [HttpDelete(Name = "UserDelete")]
        public User Delete(int id)
        {
            return _userRepo.Remove(id);
        }

        [HttpPut(Name = "UserPut")]
        public void Put()
        {
            _userRepo.Update();
        }
    }
}
