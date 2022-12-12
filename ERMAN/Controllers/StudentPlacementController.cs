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

        [HttpPost("/studentplacement", Name = "StudentPlacementsAPI")]
        public void Post(List<StudentDto> studentList)
        {
            studentList.Sort((x, y) =>x.TotalPoints.CompareTo(y.TotalPoints));
            for(int i = 0; i < studentList.Count; i++)
            {
                studentList[i].Ranking = i + 1;
                _repository.Add(studentList[i]);
            }
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}
