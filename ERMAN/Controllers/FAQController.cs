using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : Controller
    {
        private readonly ErmanDbContext _dbContext;
        public FAQController(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost(Name = "FAQAPI")]
        // [HttpPost(Name = "FAQAPI")]
        public FAQItem Post(FAQItemDto faq)
        {
            FAQItem faqNew = new FAQItem
            {
                FAQQuestion = faq.FAQQuestion,
                FAQAnswer = faq.FAQAnswer,
            };

            _dbContext.FAQTable.Add(faqNew);
            _dbContext.SaveChanges();
            return faqNew;
        }
        [HttpPut]
        public void Put(FAQItem toBeUpdated)
        {
            FAQItem faqUpdate = _dbContext.FAQTable.Find(toBeUpdated.FAQItemId);
            if (faqUpdate != null)
            {
                faqUpdate.FAQQuestion = toBeUpdated.FAQQuestion;
                faqUpdate.FAQAnswer = toBeUpdated.FAQAnswer;
                _dbContext.FAQTable.Update(faqUpdate);
                _dbContext.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete( int id)
        {
            FAQItem toBeDeleted = _dbContext.FAQTable.Find(id);
            if ( toBeDeleted != null)
            {
                _dbContext.FAQTable.Remove(toBeDeleted);
                _dbContext.SaveChanges();
            }
        }
        [HttpGet]
        public List<FAQItem> Get()
        {
            List<FAQItem> list = _dbContext.FAQTable.ToList();
            return list;
        }
        [HttpGet("{id}")]
        public FAQItem Get(int id) // may return null, don't give a false id as parameter
        {
            FAQItem gettingFAQ = _dbContext.FAQTable.Find(id);
            return gettingFAQ;
            //return (FAQItem)_dbContext.FAQTable.ToList().Where(x => x.FAQItemId == id);
        }
    }
}
        /*
        [Route("api/[controller]")]
        [ApiController]
        public class FAQController : Controller
        {
            private readonly ErmanDbContext _dbContext;
            public FAQController(ErmanDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            [HttpPost]
            // [HttpPost(Name = "FAQAPI")]
            public FAQItem Post(FAQItemDto faq)
            {
                var faqNew = new FAQItem
                {
                    FAQQuestion = faq.FAQQuestion,
                    FAQAnswer = faq.FAQAnswer,
                    IsChecked = faq.IsChecked,
                    UserId = faq.UserId,
                };

                _dbContext.FAQTable.Add(faqNew);
                _dbContext.SaveChanges();
                return faqNew;
            }
            [HttpGet]
            public void AddFAQItem(FAQItem toBeAdded)
            {
                _dbContext.FAQTable.Add(toBeAdded);
                _dbContext.SaveChanges();
            }
            [HttpGet]
            public void UpdateFAQItem(FAQItem toBeUpdated)
            {
                _dbContext.FAQTable.Update(toBeUpdated);
                _dbContext.SaveChanges();

            }
            [HttpGet]
            public void CheckChangeFAQItem(FAQItem toBeUpdated)
            {
                if (toBeUpdated.IsChecked) {
                    toBeUpdated.IsChecked = false;
                } else {
                    toBeUpdated.IsChecked = true;
                }
                _dbContext.FAQTable.Update(toBeUpdated);
                _dbContext.SaveChanges();

            }
            [HttpGet]
            public void DeleteFAQItem(FAQItem toBeDeleted)
            {
                _dbContext.FAQTable.Remove(toBeDeleted);
                _dbContext.SaveChanges();

            }
            [HttpGet]
            public List<FAQItem> GetFAQList()
            {
                List<FAQItem> list = _dbContext.FAQTable.ToList();
                return list;
            }

        }
    }*/
