namespace LibraryWebAPI.Model
{
    public class Users
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public byte? Age { get; set; }
        public string? Contact { get; set; }
        public ICollection<IssueBook> IssueBooks { get; set; }
        public ICollection<ReturnBook> ReturnBook { get; set; }
    }
}
