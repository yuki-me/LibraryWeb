using LibraryWebAPI.Data;
using LibraryWebAPI.Model;

namespace LibraryWebAPI.Repository
{
    public class ReturnBookRepository
    {
        private readonly DataContext _context;

        public ReturnBookRepository(DataContext context)
        {
            _context = context;
        }
        public IQueryable<ReturnBook> GetReturnBooks()
        {
            return (IQueryable<ReturnBook>)_context.ReturnBook.AsQueryable();
        }
        public ReturnBook? GetReturnBook(string id)
        {
            return _context.ReturnBook.Find(id);
        }
        public string? CreateReturnBook(ReturnBook returnBook)
        {
            if (returnBook.Id.Trim() == null) throw new Exception("Issue Book id must be empty");
            var found = GetReturnBook(returnBook.Id);
            if (found != null) throw new Exception($"Issue Book with this id {returnBook.Id} already exist");
            try
            {
                _context.ReturnBook.Add(returnBook);
                return _context.SaveChanges() == 0 ? null : returnBook.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateReturnBook(ReturnBook returnBook)
        {
            var found = GetReturnBook(returnBook.Id);
            if (found == null) throw new Exception($"Book with this id {returnBook.Id} does exist");

            found.StuId = returnBook.StuId;
            found.BookId = returnBook.BookId;
            found.UserId = returnBook.UserId;
            found.Quantity = returnBook.Quantity;
            found.ReturnDate = returnBook.ReturnDate;
            try
            {
                _context.ReturnBook.Update(found);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteReturnBook(ReturnBook returnBook)
        {
            try
            {
                _context.ReturnBook.Remove(returnBook);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteBook(string id)
        {
            var found = GetReturnBook(id);
            if (found == null) throw new Exception($"Book with this id {id} does not exist");
            return DeleteReturnBook(found);
        }
    }
}
