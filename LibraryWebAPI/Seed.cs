using LibraryWebAPI.Data;
using LibraryWebAPI.Model;

namespace LibraryWebAPI
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }
        public void SeedData()
        {
            if (!_context.Students.Any())
            {
                var student = new List<Students>()
                {
                    new Students()
                    {
                        Id = "S0001",
                        Name = "Sophanit",
                        Gender = "Male",
                        Age = 20,
                        Contact = "012345678"
                    },
                    new Students()
                    {
                        Id = "S0002",
                        Name = "Sopheak",
                        Gender= "Male",
                        Age = 22,
                        Contact= "021333222"
                    }
                };
                _context.Students.AddRange(student);
                _context.SaveChanges();
            }
            if (!_context.Users.Any())
            {
                var user = new List<Users>()
                {
                    new Users()
                    {
                        Id = "U0001",
                        Name = "Nit",
                        UserName = "Nit",
                        Email = "nit@gmail.com",
                        Password = "1234",
                        Age = 20,
                        Contact = "012321123"
                    }
                };
                _context.Users.AddRange(user);
                _context.SaveChanges();
            }
            if (!_context.Status.Any())
            {
                var status = new List<Status>()
                {
                    new Status()
                    {
                        Id = "ST0001",
                        Name = "Pending"
                    },
                    new Status()
                    {
                        Id = "ST0002",
                        Name = "Done"
                    }
                };
                _context.Status.AddRange(status);
                _context.SaveChanges();
            }
            if (!_context.Books.Any())
            {
                var book = new List<Books>()
                {
                    new Books()
                    {
                        Id = "B0001",
                        Title = "C Programming",
                        Description = "",
                        Author = "",
                        Quantity = 25
                    },
                    new Books()
                    {
                        Id = "B0002",
                        Title = "C++ Programming",
                        Description = "",
                        Author = "",
                        Quantity = 25
                    }
                };
                _context.Books.AddRange(book);
                _context.SaveChanges();
            }
            if (!_context.IssueBooks.Any())
            {
                var issueBook = new List<IssueBook>()
                {
                    new IssueBook()
                    {
                        Id = "IB0001",
                        StuId = "S0001",
                        BookId = "B0001",
                        UserId = "U0001",
                        Quantity = 1,
                        IssueDate = new DateTime(2022,09,04),
                        StatusId = "ST0001",
                    }
                };
                _context.IssueBooks.AddRange(issueBook);
                _context.SaveChanges();
            }
            if (!_context.ReturnBook.Any())
            {
                var returnBook = new List<ReturnBook>()
                {
                    new ReturnBook()
                    {
                        Id = "IB0001",
                        StuId = "S0001",
                        BookId = "B0001",
                        UserId = "U0001",
                        Quantity = 1,
                        ReturnDate = new DateTime(2022,09,05),
                    }
                };
                _context.ReturnBook.AddRange(returnBook);
                _context.SaveChanges();
            }

        }
        public static void SeedDataToDataBase(IHost app)
        {
            var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
            if (scopedFactory == null) return;
            using (var scope = scopedFactory.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<Seed>();
                service.SeedData();
            }
        }
    }
}
