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
        private readonly UniversityRepository _universityRepository;
        private readonly ErmanDbContext _context;
        public StudentPlacementController(StudentRepository repository, UniversityRepository universityRepository, ErmanDbContext context)
        {
            _repository = repository;
            _universityRepository = universityRepository;
            _context = context;
        }

        [HttpPost("/studentplacement", Name = "StudentPlacementsAPI")]
        public void Post(List<StudentDto> studentList)
        {
            studentList.Sort((x, y) =>x.TotalPoints.CompareTo(y.TotalPoints));
            for(int i = 0; i < studentList.Count; i++)
            {
                studentList[i].Ranking = i + 1;
                for (int j = 0; j < studentList[i].UniversityPreference.Count; j++)
                {
                    var university = _context.UniversityTable.FirstOrDefault(s => (s.UniversityName == studentList[i].UniversityPreference[j].UniversityName));
                    if(university.UniversityCapacity > 0)
                    {
                        studentList[i].University = university;
                        university.UniversityCapacity--;
                        //_context.UniversityTable.
                        _context.SaveChanges();
                        break;
                    }
                }
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
                        IsRejected = studentList[i].IsRejected,
                        AuthId = studentList[i].AuthId,
                    };
                    for (int j = 0; j < studentList[i].UniversityPreference.Count; j++)
                    {

                        var university = _context.UniversityTable.FirstOrDefault(s => (s.UniversityName == studentList[i].UniversityPreference[j].UniversityName));
                        if (university.UniversityCapacity > 0)
                        {
                            studentList[i].University = university;
                            university.UniversityCapacity--;
                            //_context.UniversityTable.
                            _context.SaveChanges();
                            break;
                        }
                    }
                    _repository.Add(newStudent);
                }
            }
        }

        [HttpPost("/deleteOneStudent", Name = "deleteOneStudent")]
        public void DeleteOneStudent(StudentDto deleteStu)
        {
            var toDelete = _context.StudentTable.FirstOrDefault(s => s.StudentId == deleteStu.StudentId);
            if(toDelete.University != null)
            {
                List<Student> studentList = _context.StudentTable.Where(s => (s.Ranking > toDelete.Ranking && s.University == null )).ToList();
                bool studentFound = false;

                for (int i = 0; i < studentList.Count || !studentFound; i++)
                {
                    foreach (University university in studentList[i].UniversityPreference)
                    {
                        if(university.UniversityName == toDelete.University.UniversityName)
                        {
                            var StudentToChange = _context.StudentTable.FirstOrDefault(s => s.StudentId == studentList[i].StudentId);
                            StudentToChange.University = toDelete.University;
                            studentFound = true;
                            _context.SaveChanges();
                        }
                    }

                }
            }
            toDelete.Ranking = -1;
            toDelete.University = null;
            toDelete.TotalPoints = 0;
            _context.SaveChanges();
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}
