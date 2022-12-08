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
        private readonly IGeneralInterface<StudentPlacement,StudentPlacementDto> repository;
        public StudentPlacementController(IGeneralInterface<StudentPlacement,StudentPlacementDto> repository)
        {
            this.repository = repository;
        }

        [HttpPost(Name = "StudentPlacementsAPI")]
        public void Post(StudentPlacementDto studentPlacement)
        {
            repository.Add(studentPlacement);
        }

        //[HttpPut]
        //public void Put(StudentPlacement toBeUpdated)
        //{
        //    StudentPlacement studentPlacement = _dbContext.StudentPlacements.Find(toBeUpdated.PlacementId);
        //    if (studentPlacement != null)
        //    {
        //        studentPlacement.StudentId = studentPlacement.StudentId;
        //        studentPlacement.StudentFirstName = studentPlacement.StudentFirstName;
        //        studentPlacement.StudentLastName = studentPlacement.StudentLastName;
        //        studentPlacement.TranscriptGradeFromFour = studentPlacement.TranscriptGradeFromFour;
        //        studentPlacement.TranscriptGradeFromHundred = studentPlacement.TranscriptGradeFromFour;
        //        studentPlacement.TranscriptGradeContribution = studentPlacement.TranscriptGradeContribution;
        //        studentPlacement.ErasmusApplicationWithGradesBehindSeUe = studentPlacement.ErasmusApplicationWithGradesBehindSeUe;
        //        studentPlacement.UESECount = studentPlacement.UESECount;
        //        studentPlacement.UECGPA = studentPlacement.UECGPA;
        //        studentPlacement.Eng101 = studentPlacement.Eng101;
        //        studentPlacement.Eng102 = studentPlacement.Eng102;
        //        studentPlacement.LanguagePoints = studentPlacement.LanguagePoints;
        //        studentPlacement.TranscriptPoints = studentPlacement.TranscriptPoints;
        //        studentPlacement.TotalPoints = studentPlacement.TotalPoints;
        //        studentPlacement.DurationPrefered = studentPlacement.DurationPrefered;
        //        studentPlacement.UniversityChoices = studentPlacement.UniversityChoices;
        //        studentPlacement.IsInWaitingList = studentPlacement.IsInWaitingList;
        //        _dbContext.StudentPlacements.Update(studentPlacement);
        //        _dbContext.SaveChanges();
        //    }
        //}

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
