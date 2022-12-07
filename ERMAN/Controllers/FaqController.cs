using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly IGeneralInterface<FAQItem, FAQItemDto> _faqRepo;
        public FAQController(IGeneralInterface<FAQItem, FAQItemDto> faqRepo)
        {
            _faqRepo = faqRepo;
        }

        [HttpPost(Name = "FaqPost")]
        public void Post(FAQItemDto faq)
        {
            _faqRepo.Add(faq);
        }

        [HttpGet(Name = "FaqGet")]
        public FAQItem Get(int id)
        {
            return _faqRepo.Get(id);
        }

        [HttpDelete(Name = "FaqDelete")]
        public FAQItem Delete(int id)
        {
            return _faqRepo.Remove(id);
        }

        [HttpPut(Name = "FaqPut")]
        public void Put()
        {
            _faqRepo.Update();
        }
    }
}
