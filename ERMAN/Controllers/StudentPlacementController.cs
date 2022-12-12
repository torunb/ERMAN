using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentPlacementController : Controller
    {
        private readonly IGeneralInterface<Student,StudentDto> repository;
        public StudentPlacementController(IGeneralInterface<Student,StudentDto> repository)
        {
            this.repository = repository;
        }

        [HttpPost(Name = "StudentPlacementsAPI")]
        public void Post(Student student)
        {
            int rankDetermined = 0;
            student.Ranking = rankDetermined;
            repository.Add(student);

        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Remove(id);
        }

        //[HttpGet]
        //public List<StudentPlacement> Get()
        //{
        //    List<StudentPlacement> list = _dbContext.StudentPlacements.ToList();
        //    return list;
        //}

        [HttpGet("{id}")]
        public StudentPlacement Get(int id) // may return null, don't give a false id as parameter
        {
            return repository.Get(id);
        }


        //[HttpGet("waitingList")]
        //public List<StudentPlacement> GetWaitingList() // may return null, don't give a false id as parameter
        //{
        //    List<StudentPlacement> list = _studentPlacementsRepository.ToWaitingList().ToList();
        //    return list;
        //}
    }
}
