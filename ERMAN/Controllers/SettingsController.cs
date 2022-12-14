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
        [HttpPost("/api/settings/drop", Name = "DropProgram")]
        public void dropProgram()
        {
            var userId = HttpContext.Items["userId"];
            var toDelete = _context.PlacementStudentTable.FirstOrDefault(s => s.StudentId == userId);
            if (toDelete.University != null)
            {
                List<PlacementStudent> studentList = _context.PlacementStudentTable.Where(s => (s.Ranking > toDelete.Ranking && s.University == null)).ToList();
                bool studentFound = false;

                for (int i = 0; i < studentList.Count || !studentFound; i++)
                {
                    foreach (University university in studentList[i].PreferredUniversity)
                    {
                        if (university.UniversityName == toDelete.University.UniversityName)
                        {
                            var StudentToChange = _context.PlacementStudentTable.FirstOrDefault(s => s.StudentId == studentList[i].StudentId);
                            StudentToChange.University = toDelete.University;
                            studentFound = true;
                            _context.SaveChanges();
                        }
                    }
                }
            }
            toDelete.Ranking = -1;
            toDelete.University = null;
            toDelete.TotalPoints = "0";
            _context.SaveChanges();

        }

        [Authorize(Roles ="Student")]
        [HttpPost("/api/settings/chnageFirstName", Name = "ChangeFirstName")]
        public void changeFirstName(String name)
        {
            var userId = HttpContext.Items["userId"];
            var Student = _context.PlacementStudentTable.FirstOrDefault(s => s.StudentId == userId);
            Student.FirstName = name;
            _context.SaveChanges();
        }
    }
}
