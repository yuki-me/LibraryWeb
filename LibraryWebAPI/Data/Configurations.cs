using LibraryWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebAPI.Data
{
    public class Configurations
    {
        public static void StudentConfigure(ModelBuilder modelBuilder)
        {
            var etb = modelBuilder.Entity<Students>();
            etb.ToTable("tblStudents").HasKey(x => x.Id);
            etb.Property(x => x.Id).HasMaxLength(8);
            etb.Property(x => x.Name).IsRequired(false).HasMaxLength(30);
            etb.Property(x => x.Gender).IsRequired(false).HasMaxLength(6);
            etb.Property(x => x.Age);
            etb.Property(x => x.Contact).IsRequired(false).HasMaxLength(30);
        }
        public static void UserConfigure(ModelBuilder modelBuilder)
        {
            var etb = modelBuilder.Entity<Users>();
            etb.ToTable("tblUsers").HasKey(x => x.Id);
            etb.Property(x => x.Id).HasMaxLength(8);
            etb.Property(x => x.Name).IsRequired(false).HasMaxLength(30);
            etb.Property(x => x.Email).IsRequired(false).HasMaxLength(30);
            etb.Property(x => x.Password).IsRequired(false).HasMaxLength(30);
            etb.Property(x => x.Age);
            etb.Property(x => x.Contact).IsRequired(false).HasMaxLength(30);
        }
        public static void StatusConfigure(ModelBuilder modelBuilder)
        {
            var etb = modelBuilder.Entity<Status>();
            etb.ToTable("tblStatus").HasKey(x => x.Id);
            etb.Property(x => x.Id).HasMaxLength(8);
            etb.Property(x => x.Name).IsRequired(false).HasMaxLength(15);
        }
        public static void BookConfigure(ModelBuilder modelBuilder)
        {
            var etb = modelBuilder.Entity<Books>();
            etb.ToTable("tblBooks").HasKey(x => x.Id);
            etb.Property(x => x.Id).HasMaxLength(8);
            etb.Property(x => x.Title).IsRequired(false).HasMaxLength(30);
            etb.Property(x => x.Description).IsRequired(false).HasMaxLength(50);
            etb.Property(x => x.Author).IsRequired(false).HasMaxLength(30);
            etb.Property(x => x.Quantity);
        }
        public static void IssueBookConfigure(ModelBuilder modelBuilder)
        {
            var etb = modelBuilder.Entity<IssueBook>();
            etb.ToTable("tblIssueBook").HasKey(x => new { x.Id, x.StuId, x.BookId, x.UserId, x.StatusId });
            etb.Property(x => x.Id).HasMaxLength(8);
            etb.Property(x => x.StuId).HasMaxLength(8);
            etb.Property(x => x.BookId).HasMaxLength(8);
            etb.Property(x => x.UserId).HasMaxLength(8);
            etb.Property(x => x.Quantity);
            etb.Property(x => x.IssueDate);
            etb.Property(x => x.StatusId).HasMaxLength(8);

            etb.HasKey(x => x.Id);
            etb.HasOne(x => x.Students).WithMany(x => x.IssueBooks).HasForeignKey(x => x.StuId).OnDelete(DeleteBehavior.NoAction);
            etb.HasOne(x => x.Books).WithMany(x => x.IssueBooks).HasForeignKey(x => x.BookId).OnDelete(DeleteBehavior.NoAction);
            etb.HasOne(x => x.Users).WithMany(x => x.IssueBooks).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            etb.HasOne(x => x.Status).WithMany(x => x.IssueBooks).HasForeignKey(x => x.StatusId).OnDelete(DeleteBehavior.NoAction);
        }
        public static void ReturnBookConfigure(ModelBuilder modelBuilder)
        {
            var etb = modelBuilder.Entity<ReturnBook>();
            etb.ToTable("tblReturnBook").HasKey(x => new { x.Id, x.StuId, x.BookId, x.UserId });
            etb.Property(x => x.Id).HasMaxLength(8);
            etb.Property(x => x.StuId).HasMaxLength(8);
            etb.Property(x => x.BookId).HasMaxLength(8);
            etb.Property(x => x.UserId).HasMaxLength(8);
            etb.Property(x => x.Quantity);
            etb.Property(x => x.ReturnDate);

            etb.HasKey(x => x.Id);
            etb.HasOne(x => x.Students).WithMany(x => x.ReturnBook).HasForeignKey(x => x.StuId).OnDelete(DeleteBehavior.NoAction);
            etb.HasOne(x => x.Books).WithMany(x => x.ReturnBook).HasForeignKey(x => x.BookId).OnDelete(DeleteBehavior.NoAction);
            etb.HasOne(x => x.Users).WithMany(x => x.ReturnBook).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
