using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IGeneralInterface<Instructor, InstructorDto> _instrRepo;
        public InstructorController(IGeneralInterface<Instructor, InstructorDto> instrRepo)
        {
            _instrRepo = instrRepo;
        }

        [HttpPost(Name = "InstructorPost")]
        public void Post(InstructorDto faq)
        {
            _instrRepo.Add(faq);
        }

        [HttpGet(Name = "InstructorGet")]
        public Instructor Get(int id)
        {
            return _instrRepo.Get(id);
        }

        [HttpDelete(Name = "InstructorDelete")]
        public Instructor Delete(int id)
        {
            return _instrRepo.Remove(id);
        }

        //[HttpPut(Name = "InstructorPut")]
        //public void Put()
        //{
        //    _instrRepo.Update();
        //}
    }
}
