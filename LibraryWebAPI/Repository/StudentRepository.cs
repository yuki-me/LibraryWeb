using LibraryWebAPI.Data;
using LibraryWebAPI.Model;

namespace LibraryWebAPI.Repository
{
    public class StudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }
        public IQueryable<Students> GetStudents()
        {
            return (IQueryable<Students>)_context.Students.AsQueryable();
        }
        public Students? GetStudent(string id)
        {
            return _context.Students.Find(id);
        }
        public string? CreateStudent(Students student)
        {
            if (student.Id.Trim() == null) throw new Exception("Student's id must be empty!");
            Students? found = GetStudent(student.Id);
            if (found != null) throw new Exception($"Student's with this id {student.Id} does already exist.");
            try
            {
                _context.Students.Add(student);
                return _context.SaveChanges() == 0 ? null : student.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateStudent(Students student)
        {
            var found = GetStudent(student.Id);
            if (found == null) throw new Exception($"Student with this id {student.Id} does not exist");
            found.Name = student.Name;
            found.Age = student.Age;
            found.Gender = student.Gender;
            found.Contact = student.Contact;
            try
            {
                _context.Students.Update(found);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteStudent(Students student)
        {
            try
            {
                _context.Students.Remove(student);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteStudent(string id)
        {
            Students? found = GetStudent(id);
            if (found == null) throw new Exception($"Student with id {id} does not exist");
            return DeleteStudent(found);
        }
    }
}
