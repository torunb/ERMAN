using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqController : ControllerBase
    {
        private readonly ErmanDbContext _dbContext;

        public FaqController(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost(Name = "FaqAPI")]
        public Faq Post(FaqDto faq)
        {
            var faqNew = new Faq
            {
                Question = faq.Question,
                Answer = faq.Answer,
            };
            _dbContext.FaqTable.Add(faqNew);
            _dbContext.SaveChanges();
            return faqNew;
        }
    }
}
