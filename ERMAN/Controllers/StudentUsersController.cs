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
    }
}
