using ERMAN.Dtos;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Controllers
{
    public class ErasmusOfficeController : ControllerBase
    {
        private readonly PlacementStudentRepository _placeRepo;
        private readonly ErmanDbContext _context;

        public ErasmusOfficeController(PlacementStudentRepository repo, ErmanDbContext context)
        {
            _placeRepo = repo;
            _context = context;
        }

        [HttpPost("/studentplacement", Name = "StudentPlacementAPI")]
        [Authorize(Roles = "ExchangeOffice")]
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
    }
}
