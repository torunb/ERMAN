using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoRepository _todoRepo;
        private readonly CourseProposalRepository _proposalRepo;

        public TodoController(TodoRepository todoRepo, CourseProposalRepository proposalRepo)
        {
            _todoRepo = todoRepo;
            _proposalRepo = proposalRepo;
        }

        public class TodoResponse {
            public int pendingProposals { get; set; }
        }

        [HttpGet]
        [Authorize(Roles = "Coordinator, Instructor")]
        public TodoResponse GetCoordinatorTodos()
        {
            var pendingProposals = _proposalRepo.GetAll().ToList().Count;

            var response = new TodoResponse
            {
                pendingProposals = pendingProposals,
            };

            return response;
        }

        //[HttpGet]
        //[Authorize(Roles = "Student")]
        //public IEnumerable<Todo> GetStudentTodos()
        //{
        //    var userId = (int)HttpContext.Items["userID"];
        //    var userType = HttpContext.Items["userType"];

        //    var pendingProposals = _proposalRepo.GetAll().ToList().Count;


        //    return _todoRepo.GetAll(userId);
        //}


        [HttpPost]
        [Authorize(Roles = "Coordinator")]
        public void Post(TodoDto todo)
        {
            var userId = HttpContext.Items["userID"];
            var userType = HttpContext.Items["userType"];
            todo.UserType = (string) userType;
            todo.UserId = Convert.ToInt32(userId);
            _todoRepo.Add(todo);
        }
    }
}
