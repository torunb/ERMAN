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
            for (int i = 0; i < studentList.Count / 2; i++)
            {
                PlacementStudentDto student = studentList[i];
                studentList[i] = studentList[studentList.Count - i - 1];
                studentList[studentList.Count - i - 1] = student;
            }
            for (int i = 0; i < studentList.Count; i++)
            {
                studentList[i].Ranking = i + 1;
            }
            for (int i = 0; i < studentList.Count; i++)
            {
                for (int j = 0; j < studentList[i].PreferredUniversity.Count; j++)
                {
                    var university = _context.UniversityTable.FirstOrDefault(s => (s.UniversityName == studentList[i].PreferredUniversity[j]));
                    if (university.UniversityCapacity > 0)
                    {
                        studentList[i].UniversityId = university.Id;
                        university.UniversityCapacity--;
                        //_context.UniversityTable.
                        break;
                    }
                }
                //Console.WriteLine(studentList[i].Ranking);
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
            for (int i = 0; i < newStudentList.Count / 2; i++)
            {
                PlacementStudent student = newStudentList[i];
                newStudentList[i] = newStudentList[newStudentList.Count - i - 1];
                newStudentList[newStudentList.Count - i - 1] = student;
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
                    UniversityId = FindUniversity(newStudentList, i),
                    PreferredUniversity = newStudentList[i].PreferredUniversity
                };
                _placeRepo.Add(student);

                
                
            }
        }

        private int FindUniversity(List<PlacementStudent> newStudentList, int i)
        {
            int ReturnVal = 0;
            for (int j = 0; j < newStudentList[i].PreferredUniversity.Count; j++)
            {
                var university = _context.UniversityTable.FirstOrDefault(s => (s.UniversityName.CompareTo(newStudentList[i].PreferredUniversity[j]) == 0));
                if (university.UniversityCapacity > 0)
                {
                    ReturnVal = university.Id;
                    university.UniversityCapacity--;
                    
                    //_context.UniversityTable.
                    break;
                }
            }
            Console.WriteLine(ReturnVal);
            return ReturnVal;


        }

        [HttpPost("/deleteOneStudent", Name = "deleteOneStudent")]
        public void DeleteOneStudent(PlacementStudentDto deleteStu)
        {
            var toDelete = _context.PlacementStudentTable.FirstOrDefault(s => s.StudentId == deleteStu.StudentId);
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
