namespace LibraryWebAPI.Model
{
    public class Students
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public byte? Age { get; set; }
        public string? Contact { get; set; }
        public ICollection<IssueBook> IssueBooks { get; set; }
        public ICollection<ReturnBook> ReturnBook { get; set; }
    }
}
