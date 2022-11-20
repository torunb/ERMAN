using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERMAN;
using ERMAN.Models;

namespace ERMAN.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentUsersController : ControllerBase
    {
        private readonly ErmanDbContext _context;

        public StudentUsersController(ErmanDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name ="Login")]
        public bool login( StudentUser studentUser, string Password)
        {
            if (StudentUserExistsByUsername(studentUser.Username))
            {
                return studentUser.Password == Password;

            }
            return false;



        }

        [HttpPut(Name = "StudentUserChange")]
        public bool changePassword( string Password, StudentUser studentUser)
        {
            if( StudentUserExists(studentUser.Id))
            {
                try { 
                    studentUser.Password = Password;
                    _context.StudentUserTable.Update(studentUser);
                    _context.SaveChangesAsync();
                    return true;

                }
                catch {
                    return false;
                }

            }
            return false;
        }

        private bool StudentUserExists(int id)
        {
          return _context.StudentUserTable.Any(e => e.Id == id);
        }
        private bool StudentUserExistsByUsername(string Username)
        {
            return _context.StudentUserTable.Any(e => e.Username == Username);
        }
    }
}
