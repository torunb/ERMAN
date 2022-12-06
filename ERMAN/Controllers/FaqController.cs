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

        [HttpPost(Name = "FAQAPI")]
        public void Post(FAQItemDto faq)
        {
            _faqRepo.Add(faq);
        }

        //[HttpPut]
        //public void Put(FAQItem toBeUpdated)
        //{
        //    FAQItem faqUpdate = _faqRepo.FAQTable.Find(toBeUpdated.FAQItemId);
        //    if (faqUpdate != null)
        //    {
        //        faqUpdate.FAQQuestion = toBeUpdated.FAQQuestion;
        //        faqUpdate.FAQAnswer = toBeUpdated.FAQAnswer;
        //        _faqRepo.FAQTable.Update(faqUpdate);
        //        _faqRepo.SaveChanges();
        //    }
        //}
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    FAQItem toBeDeleted = _faqRepo.FAQTable.Find(id);
        //    if (toBeDeleted != null)
        //    {
        //        _faqRepo.FAQTable.Remove(toBeDeleted);
        //        _faqRepo.SaveChanges();
        //    }
        //}
        //[HttpGet]
        //public List<FAQItem> Get()
        //{
        //    List<FAQItem> list = _faqRepo.FAQTable.ToList();
        //    return list;
        //}
        //[HttpGet("{id}")]
        //public FAQItem Get(int id) // may return null, don't give a false id as parameter
        //{
        //    FAQItem gettingFAQ = _faqRepo.FAQTable.Find(id);
        //    return gettingFAQ;
        //    //return (FAQItem)_faqRepo.FAQTable.ToList().Where(x => x.FAQItemId == id);
        //}
    }
}
