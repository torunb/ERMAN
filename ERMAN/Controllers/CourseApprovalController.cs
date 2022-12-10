//using ERMAN.Dtos;
//using ERMAN.Models;
//using ERMAN.Repositories;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace ERMAN.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CourseApprovalController : ControllerBase
//    {
//        private readonly CourseApprovalRepository _courseApprovalRepo;
//        public CourseApprovalController(CourseApprovalRepository courseApprovalRepo)
//        {
//            _courseApprovalRepo = courseApprovalRepo;
//        }

//        [HttpGet("/api/Checklist", Name = "ChecklistGet")]
//        public Checklist Get(int id)
//        {
//            return _checklistRepo.Get(id);
//        }

//        [HttpPost("/api/ChecklistCheck", Name = "ChecklistCheck")]
//        public void Check(int index)
//        {
//            var userId = (int)HttpContext.Items["userID"];
//            _checklistRepo.Check(userId, index);
//        }

//        [HttpGet("/api/ChecklistAll", Name = "ChecklistGetAll")]
//        public IEnumerable<Checklist> Get()
//        {
//            var userId = (int)HttpContext.Items["userID"];
//            return _checklistRepo.GetAll(userId);
//        }
//    }
//}
