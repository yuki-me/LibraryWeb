using LibraryWebAPI.Data;
using LibraryWebAPI.Model;

namespace LibraryWebAPI.Repository
{
    public class IssueBookRepository
    {
        private readonly DataContext _context;

        public IssueBookRepository(DataContext context)
        {
            _context = context;
        }
        public IQueryable<IssueBook> GetIssueBooks()
        {
            return (IQueryable<IssueBook>)_context.IssueBooks.AsQueryable();
        }
        public IssueBook? GetIssueBook(string id)
        {
            return _context.IssueBooks.Find(id);
        }
        public string? CreateIssueBook(IssueBook issueBook)
        {
            if (issueBook.Id.Trim() == null) throw new Exception("Issue Book id must be empty");
            var found = GetIssueBook(issueBook.Id);
            if (found != null) throw new Exception($"Issue Book with this id {issueBook.Id} already exist");
            try
            {
                _context.IssueBooks.Add(issueBook);
                return _context.SaveChanges() == 0 ? null : issueBook.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateIssueBook(IssueBook issueBook)
        {
            var found = GetIssueBook(issueBook.Id);
            if (found == null) throw new Exception($"Book with this id {issueBook.Id} does exist");

            found.StuId = issueBook.StuId;
            found.BookId = issueBook.BookId;
            found.UserId = issueBook.UserId;
            found.Quantity = issueBook.Quantity;
            found.IssueDate = issueBook.IssueDate;
            found.StatusId = issueBook.StatusId;
            try
            {
                _context.IssueBooks.Update(found);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteIssueBook(IssueBook issueBook)
        {
            try
            {
                _context.IssueBooks.Remove(issueBook);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteBook(string id)
        {
            var found = GetIssueBook(id);
            if (found == null) throw new Exception($"Book with this id {id} does not exist");
            return DeleteIssueBook(found);
        }
    }
}
