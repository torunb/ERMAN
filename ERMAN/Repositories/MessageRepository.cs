using ERMAN.Dtos;
using ERMAN.Models;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Repositories
{
    public class MessageRepository
    {
        private ErmanDbContext _dbContext;

        public MessageRepository(ErmanDbContext _context)
        {
            this._dbContext = _context;
        }
        public void Add(MessageDto message)
        {
            var messageNew = new Message
            {
                senderId = message.senderId,
                receiverId = message.receiverId,
                receiverType = message.receiverType,
                messageText = message.messageText,
            };

            _dbContext.MessageTable.Add(messageNew);
            _dbContext.SaveChanges();
        }

        public Message Remove(int id)
        {
            Message toDelete = _dbContext.MessageTable.Find(id);
            if (toDelete != null)
            {
                _dbContext.MessageTable.Remove(toDelete);
                _dbContext.SaveChanges();
            }
            return toDelete;
        }

        public Message Get(int id)
        {
            Message toFind = _dbContext.MessageTable.Find(id);
            return toFind;
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }

    }
}

