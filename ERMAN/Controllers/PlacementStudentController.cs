using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacementStudentController : ControllerBase
    {
        private readonly PlacementStudentRepository _placeRepo;
        private readonly ErmanDbContext _context;

        public PlacementStudentController(PlacementStudentRepository placeRepo, ErmanDbContext context)
        {
            _placeRepo = placeRepo;
            _context = context;
        }

        [HttpPost("/studentplacement", Name = "StudentPlacementAPI")]
        public void Post(List<PlacementStudentDto> studentList)
        {
            studentList.Sort((x, y) => Convert.ToDouble(x.TotalPoints).CompareTo(Convert.ToDouble(y.TotalPoints)));
            for(int i = 0; i < studentList.Count / 2; i++)
            {
                PlacementStudentDto student = studentList[i];
                studentList[i] = studentList[studentList.Count - i - 1];
                studentList[studentList.Count - i - 1] = student;
            }
            for(int i = 0; i < studentList.Count; i++)
            {
                studentList[i].Ranking = i + 1;
            }
            for (int i = 0; i < studentList.Count; i++)
            {
                for (int j = 0; j < studentList[i].PreferredUniversity.Count; j++)
                {
                    var university = _context.UniversityTable.FirstOrDefault(s => (s.UniversityName == studentList[i].PreferredUniversity[j].UniversityName));
                    if (university.UniversityCapacity > 0)
                    {
                        studentList[i].University = university;
                        university.UniversityCapacity--;
                        //_context.UniversityTable.
                        _context.SaveChanges();
                        break;
                    }
                }
                Console.WriteLine(studentList[i].Ranking);
                _placeRepo.Add(studentList[i]);
            }
        }

        [HttpPost("/newstudentplacement", Name = "NewStudentPlacementsAPI")]
        public void Post(PlacementStudentDto placeStu)
        {
            _placeRepo.Add(placeStu);
            List<PlacementStudent> newStudentList = _placeRepo.GetAll();
            _placeRepo.DeleteAll();
            newStudentList.Sort((x, y) => Convert.ToDouble(x.TotalPoints).CompareTo(Convert.ToDouble(y.TotalPoints)));
            for (int i = 0; i < newStudentList.Count; i++)
            {
                newStudentList[newStudentList.Count - i - 1] = newStudentList[i];
            }
            for (int i = 0; i < newStudentList.Count; i++)
            {
                newStudentList[i].Ranking = i + 1;
                var student = new PlacementStudentDto
                {
                    FirstName = newStudentList[i].FirstName,
                    LastName = newStudentList[i].LastName,
                    StudentId = newStudentList[i].StudentId,
                    Faculty = newStudentList[i].Faculty,
                    Department = newStudentList[i].Department,
                    Degree = newStudentList[i].Degree,
                    TotalPoints = newStudentList[i].TotalPoints,
                    DurationPreferred = newStudentList[i].DurationPreferred,
                    University = newStudentList[i].University,
                    PreferredUniversity = newStudentList[i].PreferredUniversity
                };

                for (int j = 0; j < newStudentList[i].PreferredUniversity.Count; j++)
                {
                    var university = _context.UniversityTable.FirstOrDefault(s => (s.UniversityName == newStudentList[i].PreferredUniversity[j].UniversityName));
                    if (university.UniversityCapacity > 0)
                    {
                        newStudentList[i].University = university;
                        university.UniversityCapacity--;
                        //_context.UniversityTable.
                        _context.SaveChanges();
                        break;
                    }
                }
                _placeRepo.Add(student);
            }
        }

        [HttpPost("/deleteOneStudent", Name = "deleteOneStudent")]
        public void DeleteOneStudent(PlacementStudentDto deleteStu)
        {
            var toDelete = _context.PlacementStudentTable.FirstOrDefault(s => s.StudentId == deleteStu.StudentId);
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


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _placeRepo.Remove(id);
        }

        [HttpDelete("deleteall")]
        public void DeleteAll()
        {
            _placeRepo.DeleteAll();
        }
    }
}
