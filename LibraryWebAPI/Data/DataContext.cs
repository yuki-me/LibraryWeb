using LibraryWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Configurations.StudentConfigure(modelBuilder);
            Configurations.UserConfigure(modelBuilder);
            Configurations.StatusConfigure(modelBuilder);
            Configurations.BookConfigure(modelBuilder);
            Configurations.IssueBookConfigure(modelBuilder);
            Configurations.ReturnBookConfigure(modelBuilder);
        }
        public DbSet<Students> Students { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<IssueBook> IssueBooks { get; set; }
        public DbSet<ReturnBook> ReturnBook { get; set; }
    }
}
