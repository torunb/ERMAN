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
        private readonly StudentRepository _repository;
        public StudentPlacementController(StudentRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(Name = "StudentPlacementsAPI")]
        public void Post(StudentDto student)
        {
            int rankDetermined = 0;
            student.Ranking = rankDetermined;
            _repository.Add(student);

        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}
