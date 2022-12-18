using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ERMAN.Repositories;
using ERMAN.Services;
using Microsoft.EntityFrameworkCore;
using ERMAN.Models;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase { 
        private StudentRepository _studentRepository;
        private PlacementStudentRepository _placementStudentRepository;
        private ErmanDbContext _context;

        public SettingsController( StudentRepository studentRepository, 
            PlacementStudentRepository placementStudentRepository, ErmanDbContext context)
        {
            _studentRepository = studentRepository;
            _placementStudentRepository = placementStudentRepository;
            _context = context;
            
        }
    
        [Authorize(Roles ="Student")]
        [HttpPost("/api/settings/cancel", Name = "DropProgram")]
        public void dropProgram()
        {
            var userId = (int)HttpContext.Items["userId"];
            var toDelete = _context.PlacementStudentTable.FirstOrDefault(s => Convert.ToInt32(s.Id) == userId);
            if (toDelete.UniversityId != 0)
            {
                List<PlacementStudent> studentList = _context.PlacementStudentTable.Where(s => (s.Ranking > toDelete.Ranking)).ToList();
                bool studentFound = false;
                var university = _context.UniversityTable.FirstOrDefault(s => (s.Id == toDelete.UniversityId));
                for (int i = 0; i < studentList.Count && studentFound == false; i++)
                {
                    for (int j = 0; j < studentList[i].PreferredUniversity.Count; j++)
                    {
                        if ((studentList[i].PreferredUniversity[j] == university.UniversityName) && studentFound == false && (studentList[i].UniversityId == 0 || studentList[i].UniversityId == null) && studentList[i].Ranking != -1)
                        {

                            var StudentToChange = _context.PlacementStudentTable.FirstOrDefault(s => s.StudentId == studentList[i].StudentId);
                            StudentToChange.UniversityId = university.Id;
                            studentFound = true;

                        }
                    }
                }
                if (studentFound == false)
                {
                    university.UniversityCapacity++;
                }
            }
            toDelete.Ranking = -1;
            toDelete.UniversityId = null;
            toDelete.TotalPoints = "0";
            _context.SaveChanges();

        }

        [Authorize(Roles ="Student")]
        [HttpPost("/api/settings/changeProperties", Name = "ChangeProperties")]
        public void changeFirstName(Student student)
        {
            var userId = (int) HttpContext.Items["userId"];
            var StudentPlacement = _context.PlacementStudentTable.FirstOrDefault(s => Convert.ToInt32(s.Id) == userId);
            StudentPlacement.FirstName = student.FirstName;
            StudentPlacement.LastName = student.LastName;
            var Student = _context.StudentTable.FirstOrDefault(s => Convert.ToInt32(s.Id) == userId);
            Student.Email = student.Email;
            Student.FirstName = student.FirstName;
            Student.LastName = student.LastName;
            Student.Faculty = student.Faculty;
            _context.SaveChanges();
        }
    }
}
