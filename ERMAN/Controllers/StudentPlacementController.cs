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
        
        [HttpPost("/newstudentplacement", Name = "NewStudentPlacementsAPI")]
        public void Post(StudentDto student)
        {
            if (student != null)
            {
                _repository.Add(student);

                List<Student> studentList = _repository.GetAll();
                studentList.Sort((x, y) => x.TotalPoints.CompareTo(y.TotalPoints));
                _repository.DeleteAll();
                for (int i = 0; i < studentList.Count; i++)
                {
                    studentList[i].Ranking = i + 1;
                    var newStudent = new StudentDto
                    {
                        Ranking = studentList[i].Ranking,
                        TotalPoints = studentList[i].TotalPoints,
                        FirstName = studentList[i].FirstName,
                        LastName = studentList[i].LastName,
                        Degree = studentList[i].Degree,
                        Faculty = studentList[i].Faculty,
                        Department = studentList[i].Department,
                        UniversityPreference = studentList[i].UniversityPreference,
                        DurationPreffered = studentList[i].DurationPreffered,
                        Email = studentList[i].Email,
                        StudentId = studentList[i].StudentId,
                        IsRejected = (bool)studentList[i].IsRejected,
                        AuthId = studentList[i].AuthId,
                    };
                    _repository.Add(newStudent);
                }
            }
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}
