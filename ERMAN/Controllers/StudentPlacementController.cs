using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentPlacementController : Controller
    {
        private readonly ErmanDbContext _dbContext;
        public StudentPlacementController(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost(Name = "StudentPlacementsAPI")]
        public StudentPlacement Post(StudentPlacementDto studentPlacement)
        {
            var studentPlacementNew = new StudentPlacement
            {
                StudentId = studentPlacement.StudentId,
                StudentFirstName = studentPlacement.StudentFirstName,
                StudentLastName = studentPlacement.StudentLastName,
                TranscriptGradeFromFour = studentPlacement.TranscriptGradeFromFour,
                TranscriptGradeFromHundred = studentPlacement.TranscriptGradeFromFour,
                TranscriptGradeContribution = studentPlacement.TranscriptGradeContribution,
                ErasmusApplicationWithGradesBehindSeUe = studentPlacement.ErasmusApplicationWithGradesBehindSeUe,
                UESECount = studentPlacement.UESECount,
                UECGPA = studentPlacement.UECGPA,
                Eng101 = studentPlacement.Eng101,
                Eng102 = studentPlacement.Eng102,
                LanguagePoints = studentPlacement.LanguagePoints,
                TranscriptPoints = studentPlacement.TranscriptPoints,
                TotalPoints = studentPlacement.TotalPoints,
                DurationPrefered = studentPlacement.DurationPrefered,
                UniversityChoices = studentPlacement.UniversityChoices,
                IsInWaitingList = false,
            };

            _dbContext.StudentPlacements.Add(studentPlacementNew);
            _dbContext.SaveChanges();
            return studentPlacementNew;
        }
        [HttpPut]
        public void Put(StudentPlacement toBeUpdated)
        {
            StudentPlacement studentPlacement = _dbContext.StudentPlacements.Find(toBeUpdated.PlacementId);
            if (studentPlacement != null)
            {
                studentPlacement.StudentId = studentPlacement.StudentId;
                studentPlacement.StudentFirstName = studentPlacement.StudentFirstName;
                studentPlacement.StudentLastName = studentPlacement.StudentLastName;
                studentPlacement.TranscriptGradeFromFour = studentPlacement.TranscriptGradeFromFour;
                studentPlacement.TranscriptGradeFromHundred = studentPlacement.TranscriptGradeFromFour;
                studentPlacement.TranscriptGradeContribution = studentPlacement.TranscriptGradeContribution;
                studentPlacement.ErasmusApplicationWithGradesBehindSeUe = studentPlacement.ErasmusApplicationWithGradesBehindSeUe;
                studentPlacement.UESECount = studentPlacement.UESECount;
                studentPlacement.UECGPA = studentPlacement.UECGPA;
                studentPlacement.Eng101 = studentPlacement.Eng101;
                studentPlacement.Eng102 = studentPlacement.Eng102;
                studentPlacement.LanguagePoints = studentPlacement.LanguagePoints;
                studentPlacement.TranscriptPoints = studentPlacement.TranscriptPoints;
                studentPlacement.TotalPoints = studentPlacement.TotalPoints;
                studentPlacement.DurationPrefered = studentPlacement.DurationPrefered;
                studentPlacement.UniversityChoices = studentPlacement.UniversityChoices;
                studentPlacement.IsInWaitingList = studentPlacement.IsInWaitingList;
                _dbContext.StudentPlacements.Update(studentPlacement);
                _dbContext.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            StudentPlacement toBeDeleted = _dbContext.StudentPlacements.Find(id);
            if (toBeDeleted != null)
            {
                _dbContext.StudentPlacements.Remove(toBeDeleted);
                _dbContext.SaveChanges();
            }
        }
        [HttpGet]
        public List<StudentPlacement> Get()
        {
            List<StudentPlacement> list = _dbContext.StudentPlacements.ToList();
            return list;
        }

        [HttpGet("{id}")]
        public StudentPlacement Get(int id) // may return null, don't give a false id as parameter
        {
            StudentPlacement studentPlacement = _dbContext.StudentPlacements.Find(id);
            return studentPlacement;
        }
    }
}
