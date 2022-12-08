using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly FaqRepository _faqRepo;
        public FAQController(FaqRepository faqRepo)
        {
            _faqRepo = faqRepo;
        }

        [HttpPost(Name = "FaqPost")]
        [Authorize(Roles = "Coordinator")]
        public void Post(FAQItemDto faq)
        {
            _faqRepo.Add(faq);
        }

        [HttpGet(Name = "FaqGetAll")]
        public List<FAQItem> GetAll()
        {
            return _faqRepo.GetAll();
        }

        [HttpDelete(Name = "FaqDelete")]
        public FAQItem Delete(int id)
        {
            return _faqRepo.Remove(id);
        }

        //[HttpPut(Name = "FaqPut")]
        //public void Put()
        //{
        //    _faqRepo.Update();
        //}
    }
}
