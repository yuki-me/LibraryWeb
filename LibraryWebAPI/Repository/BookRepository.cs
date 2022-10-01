using LibraryWebAPI.Data;
using LibraryWebAPI.Model;

namespace LibraryWebAPI.Repository
{
    public class BookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }
        public IQueryable<Books> GetBooks()
        {
            return (IQueryable<Books>)_context.Books.AsQueryable();
        }
        public Books? GetBook(string id)
        {
            return _context.Books.Find(id);
        }
        public string? CreateBook(Books book)
        {
            if (book.Id.Trim() == null) throw new Exception("Book id must be empty");
            var found = GetBook(book.Id);
            if (found != null) throw new Exception($"Book with this id {book.Id} already exist");
            try
            {
                _context.Books.Add(book);
                return _context.SaveChanges() == 0 ? null : book.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateBook(Books book)
        {
            var found = GetBook(book.Id);
            if (found == null) throw new Exception($"Book with this id {book.Id} does exist");

            found.Title = book.Title;
            found.Description = book.Description;
            found.Author = book.Author;
            found.Quantity = book.Quantity;
            try
            {
                _context.Books.Update(found);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteBook(Books book)
        {
            try
            {
                _context.Books.Remove(book);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteBook(string id)
        {
            var found = GetBook(id);
            if (found == null) throw new Exception($"Book with this id {id} does not exist");
            return DeleteBook(found);
        }
    }
}
