using ERMAN.Dtos;
using ERMAN.Models;

namespace ERMAN.Repositories
{
    public class FaqRepository : IGeneralInterface<FAQItem, FAQItemDto>
    {
        private readonly ErmanDbContext _dbContext;

        public FaqRepository(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(FAQItemDto student)
        {
            var faqNew = new FAQItem
            {
                FAQAnswer = student.FAQAnswer,
                FAQQuestion = student.FAQQuestion,
            };

            _dbContext.FAQTable.Add(faqNew);
            _dbContext.SaveChanges();
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

        public void Update()
        {
            _dbContext.SaveChanges();
        }
    }
}
