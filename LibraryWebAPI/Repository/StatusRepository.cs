using LibraryWebAPI.Data;
using LibraryWebAPI.Model;

namespace LibraryWebAPI.Repository
{
    public class StatusRepository
    {
        private readonly DataContext _context;

        public StatusRepository(DataContext context)
        {
            _context = context;
        }
        public IQueryable<Status> GetStatus()
        {
            return (IQueryable<Status>)_context.Status.AsQueryable();
        }
        public Status? GetStatu(string id)
        {
            return _context.Status.Find(id);
        }
        public string? CreateStatus(Status status)
        {
            if (status.Id.Trim() == null) throw new Exception("Status id must be empty");
            var found = GetStatu(status.Id);
            if (found != null) throw new Exception($"Status with this id {status.Id} already exist");

            try
            {
                _context.Status.Add(status);
                return _context.SaveChanges() == 0 ? null : status.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateStatus(Status status)
        {
            var found = GetStatu(status.Id);
            if (found == null) throw new Exception($"Status with this id {status.Id} does not exist");

            found.Name = status.Name;
            try
            {
                _context.Status.Update(found);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteStatus(Status status)
        {
            try
            {
                _context.Status.Remove(status);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteStatus(string id)
        {
            var found = GetStatu(id);
            if (found == null) throw new Exception($"Status with this id {id} does not exist");
            return DeleteStatus(found);
        }
    }
}
