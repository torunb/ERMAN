using ERMAN.Dtos;
using ERMAN.Models;

namespace ERMAN.Repositories
{
    public class FaqRepository
    {
        private readonly ErmanDbContext _dbContext;

        public FaqRepository(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public FAQItem Add(FAQItemDto faq)
        {
            var faqNew = new FAQItem
            {
                FAQAnswer = faq.FAQAnswer,
                FAQQuestion = faq.FAQQuestion,
            };

            _dbContext.FAQTable.Add(faqNew);
            _dbContext.SaveChanges();

            return faqNew;
        }

        public FAQItem Remove(int id)
        {
            FAQItem toBeDeleted = _dbContext.FAQTable.Find(id);
            if (toBeDeleted != null)
            {
                _dbContext.FAQTable.Remove(toBeDeleted);
                _dbContext.SaveChanges();
            }
            return toBeDeleted;
        }

        public FAQItem Get(int id)
        {
            FAQItem toBeFind = _dbContext.FAQTable.Find(id);
            return toBeFind;
        }

        public List<FAQItem> GetAll()
        {
            List<FAQItem> allFaqs = _dbContext.FAQTable.ToList();
            return allFaqs;
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }
    }
}
