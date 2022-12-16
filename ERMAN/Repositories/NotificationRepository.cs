using ERMAN.Models;

namespace ERMAN.Repositories
{
    public class NotificationRepository
    {
        private readonly ErmanDbContext _dbContext;

        public NotificationRepository(ErmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Notification notification)
        {
            _dbContext.NotificationTable.Add(notification);
            _dbContext.SaveChanges();
        }


        public void Read(int notificationId)
        {
            var notification = _dbContext.NotificationTable.Where(notification => notification.Id == notificationId).FirstOrDefault();
            notification.Read = true;
            _dbContext.SaveChanges();
        }

        public List<Notification> GetAll()
        {
            List<Notification> allNotifications = _dbContext.NotificationTable.ToList();
            return allNotifications;
        }
    }
}