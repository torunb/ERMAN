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
                List<PlacementStudent> studentList = _context.PlacementStudentTable.Where(s => (s.Ranking > toDelete.Ranking && s.UniversityId == 0)).ToList();
                bool studentFound = false;

                for (int i = 0; i < studentList.Count || !studentFound; i++)
                {
                    foreach (string UniversityName in studentList[i].PreferredUniversity)
                    {
                        var university = _context.UniversityTable.FirstOrDefault(s => (s.Id == toDelete.UniversityId));
                        if (UniversityName == university.UniversityName)
                        {
                            var StudentToChange = _context.PlacementStudentTable.FirstOrDefault(s => s.Id == studentList[i].Id);
                            StudentToChange.UniversityId = toDelete.UniversityId;
                            studentFound = true;
                            _context.SaveChanges();
                        }
                    }
                }
            }
            toDelete.Ranking = -1;
            toDelete.UniversityId = 0;
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
