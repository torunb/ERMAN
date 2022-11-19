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

        public void AddFAQItem(FAQItem toBeAdded)
        {
            _dbContext.FAQTable.Add(toBeAdded);
            _dbContext.SaveChanges();
        }
        public void UpdateFAQItem(FAQItem toBeUpdated)
        {
            _dbContext.FAQTable.Update(toBeAdded);
            _dbContext.SaveChanges();

        }
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
        public void DeleteFAQItem(FAQItem toBeDeleted)
        {
            _dbContext.FAQTable.Delete(toBeAdded);
            _dbContext.SaveChanges();

        }


    }
}
