using ERMAN.Models;
using System.Reflection.Metadata;

namespace ERMAN.Repositories
{
    public class MessageRepository : IDisposable
    {
        private ErmanDbContext _context;

        public MessageRepository(ErmanDbContext _context)
        {
            this._context = _context;
        }

        public IEnumerable<Message> GetMessages()
        {
            return _context.MessageTable.ToList();
        }

        public Student GetMessageByID(int id)
        {
            return _context.MessageTable.Find(id);
        }

        public void InsertMessage( Message message)
        {
            _context.MessageTable.Add(message);
        }

        public void DeleteMessage(int messageID)
        {
            Message message = _context.MessageTable.Find(messageID);
            _context.MessageTable.Remove(message);
        }

        public void UpdateMessage(Message message)
        {
            _context.Entry(message).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MessageRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

