using LibraryWebAPI.Data;
using LibraryWebAPI.Model;

namespace LibraryWebAPI.Repository
{
    public class UserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public IQueryable<Users> GetUsers()
        {
            return (IQueryable<Users>)_context.Users.AsQueryable();
        }
        public Users? GetUser(string id)
        {
            return _context.Users.Find(id);
        }
        public string? CreateUser(Users user)
        {
            if (user.Id.Trim() == null) throw new Exception("User's id must be empty.");
            Users? found = GetUser(user.Id);
            if (found != null) throw new Exception($"User's with this id {user.Id} already exist");
            try
            {
                _context.Users.Add(user);
                return _context.SaveChanges() == 0 ? null : user.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateUser(Users user)
        {
            var found = GetUser(user.Id);
            if (found == null) throw new Exception($"User's with this id {user.Id} dose not exist");

            found.Name = user.Name;
            found.UserName = user.UserName;
            found.Email = user.Email;
            found.Password = user.Password;
            found.Age = user.Age;
            found.Contact = user.Contact;
            try
            {
                _context.Users.Update(found);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteUser(Users user)
        {
            try
            {
                _context.Users.Remove(user);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteUser(string id)
        {
            var found = GetUser(id);
            if (found == null) throw new Exception($"User's with this id {id} does not exist");
            return DeleteUser(found);
        }
    }
}
